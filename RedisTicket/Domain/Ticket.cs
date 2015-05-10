using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Domain
{
    public class Ticket
    {
        public Int64 Id { get; set; }

        public string Sku { get; set; }
    }
}
