﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using VCI_API.Models.DTO;

namespace VCI_API.Models.DAL
{
    public abstract class BaseDAL<T> where T : BaseDTO
    {
        private static IMongoClient client;
        private IMongoDatabase database;
        protected IMongoCollection<T> collection;

        private string databaseName;
        private string collectionName;
        protected ProjectionDefinition<T> projection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collectionName">Nombre de la colección</param>
        public BaseDAL(string collectionName)
        {
            databaseName = ConfigurationManager.AppSettings["DbName"];
            this.collectionName = collectionName;

            if (client == null)
            {
                client = new MongoClient(ConfigurationManager.AppSettings["DbEndpoint"]);
            }
            database = client.GetDatabase(databaseName);
            collection = database.GetCollection<T>(collectionName);
            SetBasicProjection();
        }

        /// <summary>
        /// Obtiene un elemento por el Id,  usa la proyeccion basica
        /// </summary>
        /// <param name="id">Id del elemento</param>
        /// <returns></returns>
        public async Task<T> GetById(Guid id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("id", id);
            FindOptions<T> options = new FindOptions<T>();
            options.Limit = 1;
            options.Projection = projection;
            var cursor = await collection.FindAsync(filter, options);
            return cursor.First();
        }

        /// <summary>
        /// Obtiene todos los elementos de la coleccion,  usa la proyeccion basica
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAll()
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Empty;
            FindOptions<T> options = new FindOptions<T>();
            options.Projection = projection;
            var cursor = await collection.FindAsync(filter, options);
            return cursor.ToList();
        }

        /// <summary>
        /// Obtiene un objeto por una propiedad, usa la proyeccion basica
        /// </summary>
        /// <param name="name">nombre de la propiedad</param>
        /// <param name="value">valor. Se sugiere que sea un valor unico por objeto</param>
        /// <returns>Primer objeto que coincida con ese valor</returns>
        public async Task<T> GetByProperty<G>(string name, G value)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(name, value);
            FindOptions<T> options = new FindOptions<T>();
            options.Projection = projection;
            options.Limit = 1;
            var cursor = await collection.FindAsync(filter, options);
            return cursor.First();
        }

        /// <summary>
        /// Obtiene el primer elemento que coincida con el filtro
        /// </summary>
        /// <param name="filter">filtro</param>
        /// <returns>primer elemento que coincidio</returns>
        public async Task<T> GetByFilter(FilterDefinition<T> filter)
        {
            FindOptions<T> options = new FindOptions<T>();
            options.Projection = projection;
            options.Limit = 1;
            var cursor = await collection.FindAsync(filter, options);
            return cursor.First();
        }

        /// <summary>
        /// Inserta un elemento en la coleccion
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected T Insert(T element)
        {
            element.id = Guid.NewGuid();
            collection.InsertOne(element);
            return element;
        }

        /// <summary>
        /// Asigna la proyección basica para las consultas
        /// </summary>
        /// <returns></returns>
        public abstract void SetBasicProjection();

        public abstract T Create(T element);
        public abstract T Update(T element);

    }
}