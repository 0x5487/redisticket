using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Domain
{
    public class LineItem
    {
        public Int64 Id { get; set; }

        public Int64 EventId { get; set; }

        public Int64 TicketId { get; set; }

        public Int32 Quantity { get; set; }

        public List<StockItem> StockItems { get; set; }
    }
}
