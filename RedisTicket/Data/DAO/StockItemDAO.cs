using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RedisTicket.Domain;

namespace RedisTicket.Data
{
    public partial class TicketRepository
    {

        public void InsertStockItems(IList<StockItem> items)
        {
            var trans = _conn.BeginTransaction();

            try
            {
                _conn.Execute(@"insert [dbo].[Inventory]([TicketId],[OrderId],[CreatedUserId],[CreatedDate],[LastModifiedUserId],[LastModifiedDate])
                            values(@TicketId, @OrderId, @CreatedUserId, @CreatedDate, @LastModifiedUserId, @LastModifiedDate)", items, transaction: trans);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }

            trans.Commit();
        }

        public void UpdateStockItemOrderId(Int32 orderId, IList<Int32> stockItemIds)
        {
            try
            {
                _conn.Execute(@"update [dbo].[Inventory]
                                set [OrderId] = @OrderId
                                where [Id] in @Ids", new { OrderId = orderId, Ids = stockItemIds });
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
