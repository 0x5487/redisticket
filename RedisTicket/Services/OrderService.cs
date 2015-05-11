using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using RedisTicket.Data;
using RedisTicket.Domain;

namespace RedisTicket.Services
{
    public class OrderService
    {
        private TicketRepository _repository;

        public string CreateOrder(IList<BuyItem> items)
        {
            List<LineItem> lineItems = new List<LineItem>();
            List<int> stockItemIds = new List<int>();

            foreach (var buyItem in items)
            {
                LineItem lineItem = new LineItem()
                {
                    Id = 1,
                    EventId = 1,
                    Quantity = buyItem.Quantity,
                    StockItemIds = buyItem.StockItemIds
                };

                stockItemIds.AddRange(buyItem.StockItemIds);
                lineItems.Add(lineItem);
            }

            Order newOrder = new Order()
            {
                OrderNumber = Guid.NewGuid().ToString(),
                LineItems = lineItems
            };

            using (var transactionScope = new TransactionScope())
            {
                _repository.InsertOrder(newOrder);
                _repository.UpdateStockItemOrderId(newOrder.Id, stockItemIds);
                transactionScope.Complete();
            }

            return newOrder.OrderNumber;
        }


        public OrderService(TicketRepository repository)
        {
            _repository = repository;
        }



    }
}
