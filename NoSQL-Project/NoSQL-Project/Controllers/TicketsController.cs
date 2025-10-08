using Microsoft.AspNetCore.Mvc;
using NoSQL_Project.Models;
using NoSQL_Project.Services;
using NoSQL_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoSQL_Project.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;
        private readonly EmployeeService _employeeService;

        public TicketsController(TicketService ticketService, EmployeeService employeeService)
        {
            _ticketService = ticketService;
            _employeeService = employeeService;
        }

        /// GET: /Tickets - Display all tickets
        public async Task<IActionResult> Index()
        {
            List<Ticket> allTickets = await _ticketService.GetAllTicketsAsync();
            return View(allTickets);
        }

        /// GET: /Tickets/Create - Show create ticket form
        public async Task<IActionResult> Create()
        {
            List<Employee> allEmployees = await _employeeService.GetAllEmployeesAsync();
            ViewBag.Employees = allEmployees;
            return View();
        }

        /// POST: /Tickets/Create - Handle ticket creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel to Model
                Ticket newTicket = new Ticket
                {
                    Subject = ticketViewModel.Subject,
                    Description = ticketViewModel.Description,
                    OwnerId = ticketViewModel.OwnerId,
                    Priority = ticketViewModel.Priority,
                    Type = ticketViewModel.Type,
                    Status = "Open",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Comments = new List<TicketComment>()
                };

                await _ticketService.CreateTicketAsync(newTicket);
                TempData["SuccessMessage"] = "Ticket created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, reload employees
            List<Employee> allEmployees = await _employeeService.GetAllEmployeesAsync();
            ViewBag.Employees = allEmployees;
            return View(ticketViewModel);
        }

        /// GET: /Tickets/Details - Show ticket details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket foundTicket = await _ticketService.GetTicketByIdAsync(id);
            if (foundTicket == null)
            {
                return NotFound();
            }

            // Get owner details
            Employee ticketOwner = await _employeeService.GetEmployeeByIdAsync(foundTicket.OwnerId);
            ViewBag.Owner = ticketOwner;

            // Get assigned employee details if exists
            if (!string.IsNullOrEmpty(foundTicket.AssignedToId))
            {
                Employee assignedEmployee = await _employeeService.GetEmployeeByIdAsync(foundTicket.AssignedToId);
                ViewBag.AssignedTo = assignedEmployee;
            }

            return View(foundTicket);
        }
    }
}