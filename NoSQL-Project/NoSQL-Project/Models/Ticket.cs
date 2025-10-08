using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoSQL_Project.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required]
        [BsonElement("ownerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OwnerId { get; set; } // Employee who created the ticket

        [BsonElement("assignedToId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AssignedToId { get; set; } // Service Desk employee (nullable)

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, ErrorMessage = "Subject cannot exceed 100 characters")]
        [BsonElement("subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = "General"; // IT, Facilities, HR, etc.

        [BsonElement("priority")]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High

        [Required]
        [BsonElement("status")]
        public string Status { get; set; } = "Open"; // Open, Resolved, Closed

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [BsonElement("closedAt")]
        public DateTime? ClosedAt { get; set; }

        [BsonElement("comments")]
        public List<TicketComment> Comments { get; set; } = new List<TicketComment>();
    }
}