using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Services
{
    public interface IOrderService
    {
        void CreateOrder();

        void EmptyOrder();



    }
}
