using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NoSQL_Project.Models
{
    public class TicketComment
    {
        [BsonElement("authorId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AuthorId { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}