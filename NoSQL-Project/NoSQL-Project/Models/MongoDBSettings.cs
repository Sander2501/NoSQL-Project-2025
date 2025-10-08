namespace NoSQL_Project.Models
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TicketsCollectionName { get; set; }
        public string EmployeesCollectionName { get; set; }
    }
}