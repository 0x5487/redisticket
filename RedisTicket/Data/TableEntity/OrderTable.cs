using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.TableEntity
{
    public class OrderTable
    {
        public Int64 Id { get; set; }

        public string OrderNumber { get; set; }

        public string Data { get; set; }

        public Int64 CreatedUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Int64 LastModifiedUserId { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
