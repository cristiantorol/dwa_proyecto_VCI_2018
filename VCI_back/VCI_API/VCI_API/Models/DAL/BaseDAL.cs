using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VCI_API.Models.DTO;

namespace VCI_API.Models.DAL
{
    public class BaseDAL<T> where T : BaseDTO
    {
        private static IMongoClient Client;
        private IMongoDatabase Database;
        private IMongoCollection<T> Collection;

        private string DatabaseName;
        private string CollectionName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="CollectionName">Nombre de la colección</param>
        public BaseDAL(string CollectionName)
        {
            DatabaseName = ConfigurationManager.AppSettings["DbName"];
            this.CollectionName = CollectionName;

            if (Client == null)
            {
                Client = new MongoClient(ConfigurationManager.AppSettings["DbEndpoint"]);
            }
            Database = Client.GetDatabase(DatabaseName);
            Collection = Database.GetCollection<T>(CollectionName);
        }

        /// <summary>
        /// Obtiene un elemento por el Id
        /// </summary>
        /// <param name="Id">Id del elemento</param>
        /// <returns></returns>
        public async Task<T> GetById(Guid Id)
        {
            FilterDefinition<T> Filter = Builders<T>.Filter.Eq("id", Id);
            FindOptions<T> Options = new FindOptions<T>();
            Options.Limit = 1;
            var Cursor = await Collection.FindAsync(Filter, Options);
            return Cursor.First();
        }

        /// <summary>
        /// Obtiene todos los elementos de la coleccion
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            FilterDefinition<T> Filter = Builders<T>.Filter.Empty;
            var Cursor = Collection.Find(Filter);
            return Cursor.ToList();
        }

        /// <summary>
        /// Inserta un elemento en la coleccion
        /// </summary>
        /// <param name="Element"></param>
        /// <returns></returns>
        public T Insert(T Element)
        {
            Element.Id = Guid.NewGuid();
            Collection.InsertOne(Element);
            return Element;
        }

    }
}