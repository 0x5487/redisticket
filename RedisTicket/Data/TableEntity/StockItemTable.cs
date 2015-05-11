using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.TableEntity
{
    public class StockItemTable
    {
        public Int64 Id { get; set; }

        public Int64 TicketId { get; set; }

        public Int64 OrderId { get; set; }

        public Int64 CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Int64 LastModifiedUserId { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
