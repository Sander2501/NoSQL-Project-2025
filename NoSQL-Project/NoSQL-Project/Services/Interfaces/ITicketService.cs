using NoSQL_Project.Models;

namespace NoSQL_Project.Services.interfaces
{
    public interface ITicketService
    {
        Task CreateTicketAsync(Ticket ticket);
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketByIdAsync(string id);
        Task UpdateTicketAsync(string id, Ticket updatedTicket);
        Task DeleteTicketAsync(string id);
    }
}
