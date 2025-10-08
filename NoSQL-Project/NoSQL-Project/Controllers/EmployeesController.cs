using Microsoft.AspNetCore.Mvc;
using NoSQL_Project.Models;
using NoSQL_Project.Services;
using NoSQL_Project.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoSQL_Project.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// GET: /Employees - Display all employees
        public async Task<IActionResult> Index()
        {
            List<Employee> allEmployees = await _employeeService.GetAllEmployeesAsync();
            return View(allEmployees);
        }

        /// GET: /Employees/Create - Show create employee form
        public IActionResult Create()
        {
            return View();
        }

        /// POST: /Employees/Create - Handle employee creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Model
                Employee newEmployee = new Employee
                {
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    Email = employeeViewModel.Email,
                    PasswordHash = employeeViewModel.Password,
                    RoleId = employeeViewModel.RoleId,
                    Phone = employeeViewModel.Phone,
                    Status = "Active"
                };

                await _employeeService.CreateEmployeeAsync(newEmployee);
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(employeeViewModel);
        }
        /// GET: /Employees/Delete/{id} - Show delete confirmation
        public IActionResult Delete()
        {
            return View();
        }

        /// POST: /Employees/Delete/{id} - Handle employee deletion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError(string.Empty, "Invalid employee ID.");
                return View();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            TempData["SuccessMessage"] = "Employee deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}