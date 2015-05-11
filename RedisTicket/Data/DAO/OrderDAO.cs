using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json;
using RedisTicket.Domain;
using RedisTicket.TableEntity;

namespace RedisTicket.Data
{
    public partial class TicketRepository
    {

        public Order InsertOrder(Order source)
        {

            OrderTable target = new OrderTable();
            target.OrderNumber = source.OrderNumber;
            target.Data = JsonConvert.SerializeObject(source);
            target.CreatedDate = DateTime.UtcNow;
            target.CreatedUserId = 99;
            target.LastModifiedUserId = 99;
            target.LastModifiedDate = DateTime.UtcNow;

            try
            {
                source.Id = _conn.Query<int>(@"insert [dbo].[Order]([OrderNumber],[Data],[CreatedUserId],[CreatedDate],[LastModifiedUserId],[LastModifiedDate])
                            values(@OrderNumber, @Data, @CreatedUserId, @CreatedDate, @LastModifiedUserId, @LastModifiedDate)
                            SELECT CAST(SCOPE_IDENTITY() as int)", target).Single();
            }
            catch (Exception ex)
            {

                throw;
            }

            return source;
        }


    }
}
