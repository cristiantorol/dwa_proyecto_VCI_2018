using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using VCI_API.Models.DTO;

namespace VCI_API.Models.DAL
{
    public class BaseDAL<T,D> where T : BaseDTO<D>
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

        public T GetById(D id)
        {

        }

    }
}