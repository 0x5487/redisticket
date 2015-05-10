using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Domain
{
    public class StockItem
    {
        public Int64 Id { get; set; }

        public Int64 TicketId { get; set; }

        public bool IsPurchaseable { get; set; }
    }
}
