using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NoSQL_Project.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        [BsonElement("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [BsonElement("email")]
        public string Email { get; set; }

        [Phone]
        [BsonElement("phone")]
        public string Phone { get; set; }

        [Required]
        [BsonElement("roleId")]
        public string RoleId { get; set; } // "Employee" or "ServiceDesk" for now

        [Required]
        [BsonElement("status")]
        public string Status { get; set; } = "Active"; // Active, Inactive

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [BsonElement("passwordHash")]
        public string PasswordHash { get; set; }

        // Helper property for display (not stored in DB)
        [BsonIgnore]
        public string FullName => $"{FirstName} {LastName}";
    }
}