using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisTicket.Data
{
    public partial class TicketRepository
    {
        private IDbConnection _conn;

        public TicketRepository(IDbConnection connection)
        {
            _conn = connection;
        }
    }
}
