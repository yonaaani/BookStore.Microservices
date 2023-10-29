using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Genre")]
        public string Genre { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("NumberOfPages")]
        public int NumberOfPages { get; set; }

        [BsonElement("Cover")]
        public string Cover { get; set; }

        [BsonElement("PublishDate")]
        public DateTime PublishDate { get; set; }

        [BsonElement("LanguageName")]
        public string LanguageName { get; set; }

        [BsonElement("PublisherName")]
        public string PublisherName { get; set; }

        [BsonElement("AuthorName")]
        public string AuthorName { get; set; }
    }
}