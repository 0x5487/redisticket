using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisTicket.Data;
using RedisTicket.Domain;
using RedisTicket.Services;

namespace RedisTicket.Tests
{
    public class OrderTest
    {
        private OrderService _orderService;
        private SqlConnection _connection;


        public void CreateOrderTest()
        {
            List<BuyItem> items = new List<BuyItem>();

            var buyItem = new BuyItem()
            {
                EventId = 1,
                Quantity = 3
            };
            buyItem.StockItemIds = new List<int>() {1, 2, 3};

            items.Add(buyItem);
            _orderService.CreateOrder(items);
        }

        public OrderTest()
        {
            _connection = new SqlConnection("Server=localhost;Database=Ticketdb;Trusted_Connection=True;");
            _connection.Open();

            TicketRepository repository = new TicketRepository(_connection);
            _orderService = new OrderService(repository);
        }
    }
}
