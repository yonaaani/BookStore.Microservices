using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Book> bookCollection)
        {
            bool existProduct = bookCollection.Find(p => true).Any();
            if (!existProduct)
            {
                bookCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Book> GetPreconfiguredProducts()
        {
            return new List<Book>()
            {
                new Book()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Title = "With You, I Am at Home",
                    Description = "The book is about how a friend loves another while remaining true to himself.",
                    Genre = "Psychology",
                    Price = 1200.00M,
                    NumberOfPages = 350,
                    Cover = "Hard cover",
                    PublishDate = new DateTime(2022),
                    LanguageName = "uk",
                    PublisherName = "Nova knyga",
                    AuthorName = "Olha Prymachenko",
                },
                new Book()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Title = "Pride and Prejudice",
                    Description = "Brief description of the book goes here.",
                    Price = 800.00M,
                    NumberOfPages = 279,
                    Cover = "Hard cover",
                    PublishDate = new DateTime(2011),
                    LanguageName = "en",
                    PublisherName = "Penguin Classics",
                    AuthorName = "Jane Austen",
                },
                new Book()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Title = "To All the Boys I've Loved Before",
                    Description = "Brief description of the book goes here.",
                    Genre = "Young Adult Fiction",
                    Price = 1050.00M,
                    NumberOfPages = 355,
                    Cover = "Paperback",
                    PublishDate = new DateTime(2018),
                    LanguageName = "en",
                    PublisherName = "Scholastic",
                    AuthorName = "Jenny Han",
                },
            };
        }
    }
}

