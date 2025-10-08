using NoSQL_Project.Models;

namespace NoSQL_Project.Services.interfaces
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(string id);
        Task<Employee> GetEmployeeByEmailAsync(string email);
        Task DeleteEmployeeAsync(string id);
        Task UpdateEmployeeAsync(string id, Employee updatedEmployee);
    }
}
