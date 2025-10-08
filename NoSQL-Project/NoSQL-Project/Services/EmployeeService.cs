using MongoDB.Driver;
using NoSQL_Project.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoSQL_Project.Services.interfaces;

namespace NoSQL_Project.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _employees = mongoDatabase.GetCollection<Employee>(
                mongoDBSettings.Value.EmployeesCollectionName);
        }

        /// CREATE: Insert a new employee into the database
        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _employees.InsertOneAsync(employee);
        }

        /// READ: Get all employees from the database
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            FilterDefinition<Employee> emptyFilter = Builders<Employee>.Filter.Empty;
            return await _employees.Find(emptyFilter).ToListAsync();
        }

        /// READ: Get a single employee by ID
        public async Task<Employee> GetEmployeeByIdAsync(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(employee => employee.Id, id);
            return await _employees.Find(filter).FirstOrDefaultAsync();
        }

        /// READ: Get employee by email (for login purposes)
        public async Task<Employee> GetEmployeeByEmailAsync(string email)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(employee => employee.Email, email);
            return await _employees.Find(filter).FirstOrDefaultAsync();
        }

        /// DELETE: Delete an employee by ID
        public async Task DeleteEmployeeAsync(string id)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(employee => employee.Id, id);
            await _employees.DeleteOneAsync(filter);
        }

        /// UPDATE: Update an employee by ID
        public async Task UpdateEmployeeAsync(string id, Employee updatedEmployee)
        {
            FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq(employee => employee.Id, id);
            await _employees.ReplaceOneAsync(filter, updatedEmployee);
        }
    }
}