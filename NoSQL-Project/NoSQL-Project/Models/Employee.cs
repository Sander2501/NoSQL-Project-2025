namespace NoSQL_Project.Models
{
    public class Employee
    {
        public string FirstName { get; internal set; }
        public string Email { get; internal set; }
        public string LastName { get; internal set; }
        public string PasswordHash { get; internal set; }
        public string RoleId { get; internal set; }
        public string Phone { get; internal set; }
        public string Status { get; internal set; }
        public object Id { get; internal set; }

        public Employee()
        {
        }

        public Employee(string firstName, string email, string lastName, string passwordHash, string roleId, string phone, string status, object id)
        {
            FirstName = firstName;
            Email = email;
            LastName = lastName;
            PasswordHash = passwordHash;
            RoleId = roleId;
            Phone = phone;
            Status = status;
            Id = id;
        }
    }
}
