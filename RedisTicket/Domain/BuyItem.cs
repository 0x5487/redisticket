using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedisTicket.Domain
{

    public class BuyItem
    {
        public Int64 EventId { get; set; }

        public Int64 TicketId { get; set; }

        public Int32 Quantity { get; set; }

        public IList<String> StockItems { get; set; }

        public IList<int> StockItemIds { get; set; }


    }
}
