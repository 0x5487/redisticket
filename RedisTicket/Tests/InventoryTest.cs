using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisTicket.Data;
using RedisTicket.Services;

namespace RedisTicket.Tests
{
    public class InventoryTest
    {
        private InventoryService _inventoryService;
        private SqlConnection _connection;

        public void Add500Tickets()
        {
            _inventoryService.AddStockItems(1, 500);
            _connection.Close();
        }


        public InventoryTest()
        {
            _connection = new SqlConnection("Server=localhost;Database=Ticketdb;Trusted_Connection=True;");
            _connection.Open();

            TicketRepository repository = new TicketRepository(_connection);
            _inventoryService = new InventoryService(repository);
        }
    }
}
