using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Domain
{
    public class Order
    {
        public Int32 Id { get; set; }

        public string OrderNumber { get; set; }

        public IList<LineItem> LineItems { get; set; }

        public decimal Total { get; set; }

        public decimal TotalWithTax { get; set; }

        public decimal TotalWithoutTax { get; set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpiryDate { get; set; }


    }
}
