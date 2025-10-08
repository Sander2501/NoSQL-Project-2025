namespace NoSQL_Project.Models
{
    public class Ticket
    {
        public string Subject { get; internal set; }
        public string Description { get; internal set; }
        public string OwnerId { get; internal set; }
        public string Priority { get; internal set; }
        public string Type { get; internal set; }
        public string Status { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdatedAt { get; internal set; }
        public DateTime? ClosedAt { get; internal set; }
        public List<TicketComment> Comments { get; internal set; }
        public string? AssignedToId { get; internal set; }
        public object Id { get; internal set; }

        public Ticket()
        {
        }

        public Ticket(string subject, string description, string ownerId, string priority, string type, string status, DateTime createdAt, DateTime updatedAt, List<TicketComment> comments, string? assignedToId, object id)
        {
            Subject = subject;
            Description = description;
            OwnerId = ownerId;
            Priority = priority;
            Type = type;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Comments = comments;
            AssignedToId = assignedToId;
            Id = id;
        }
    }
}
