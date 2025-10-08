using MongoDB.Driver;
using NoSQL_Project.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoSQL_Project.Services.interfaces;

namespace NoSQL_Project.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;

        public TicketService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient mongoClient = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _tickets = mongoDatabase.GetCollection<Ticket>(
                mongoDBSettings.Value.TicketsCollectionName);
        }

        /// CREATE: Insert a new ticket into the database
        public async Task CreateTicketAsync(Ticket ticket)
        {
            await _tickets.InsertOneAsync(ticket);
        }

        /// READ: Get all tickets from the database
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            FilterDefinition<Ticket> emptyFilter = Builders<Ticket>.Filter.Empty;
            return await _tickets.Find(emptyFilter).ToListAsync();
        }


        /// READ: Get a single ticket by ID
        public async Task<Ticket> GetTicketByIdAsync(string id)
        {
            FilterDefinition<Ticket> filter = Builders<Ticket>.Filter.Eq(ticket => ticket.Id, id);
            return await _tickets.Find(filter).FirstOrDefaultAsync();
        }

        /// DELETE: Delete a ticket by ID

        public async Task DeleteTicketAsync(string id)
        {
            FilterDefinition<Ticket> filter = Builders<Ticket>.Filter.Eq(ticket => ticket.Id, id);
            await _tickets.DeleteOneAsync(filter);
        }
        /// UPDATE: Update a ticket by ID
        public async Task UpdateTicketAsync(string id, Ticket updatedTicket)
        {
            FilterDefinition<Ticket> filter = Builders<Ticket>.Filter.Eq(ticket => ticket.Id, id);
            await _tickets.ReplaceOneAsync(filter, updatedTicket);
        }
    }
}