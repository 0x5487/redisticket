using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Domain
{
    public class Order
    {
        public Int64 Id { get; set; }

        public string OrderId { get; set; }

        public LineItem[] LineItems { get; set; }

        public decimal Total { get; set; }

        public decimal Total_With_Tax { get; set; }

        public decimal Total_Without_Tax { get; set; }

        public DateTime Paid_Date_UTC { get; set; }


    }
}
