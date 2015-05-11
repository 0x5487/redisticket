using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedisTicket.Data;
using RedisTicket.Domain;

namespace RedisTicket.Services
{
    public class InventoryService
    {
        private TicketRepository _repository;

        public void AddStockItems(Int32 ticketId, Int32 quantity)
        {
            List<StockItem> items = new List<StockItem>();

            for (int i = 0; i < quantity; i++)
            {
                StockItem item = new StockItem()
                {
                    OrderId = 0,
                    TicketId = ticketId,
                    CreatedUserId = 99,
                    CreatedDate = DateTime.UtcNow,
                    LastModifiedUserId = 99,
                    LastModifiedDate = DateTime.UtcNow
                };
                items.Add(item);
            }

            _repository.InsertStockItems(items);
        }

        public void UpdateStockItemOrder()
        {
            
        }

        public InventoryService(TicketRepository repository)
        {
            _repository = repository;
        }


    }
}
