using Catalog.API.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Catalog.API.Data
{
    public class CatalogContext 
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Book> _booksCollection;

        public CatalogContext(IOptions<DatabaseSetting> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.ConnectionString);
            _database = client.GetDatabase(databaseSettings.Value.DatabaseName);

            // Get the actual collection
            _booksCollection = _database.GetCollection<Book>("book");

            CatalogContextSeed.SeedData(_booksCollection);
        }

        public IMongoDatabase Database => _database;
        public IMongoCollection<Book> Books => _booksCollection;
    }
}
