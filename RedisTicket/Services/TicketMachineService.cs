using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RedisTicket.Domain;
using StackExchange.Redis;
using JasonSoft.IO;

namespace RedisTicket
{
    public class TicketMachineService
    {
        private IDatabase _db;
        private byte[] _hash;
        private ConnectionMultiplexer _conn;

        public void AddStockItems(Int64 TicketId, string[] values)
        {
            var redisValues = Array.ConvertAll(values, item => (RedisValue)item);
            _db.ListRightPush(TicketId.ToString(), redisValues);
        }

        public string GetStockItems(List<BuyItem> items)
        {
            string json = JsonConvert.SerializeObject(items);
            RedisKey[] keys = { json };

            string result = (string)_db.ScriptEvaluate(_hash, keys);
            return result;
        }

        public bool DeleteTicket(Int64 TicketId)
        {
            return _db.KeyDelete(TicketId.ToString());
        }

        public TicketMachineService(ConnectionMultiplexer conn)
        {
            FileInfo file = new FileInfo("Scripts/checkTicket.lua");
            string checkTicketLua = file.GetText().Replace("\r\n", " ").Replace("\t", " ");

            _conn = conn;
            var server = _conn.GetServer("localhost", 6379);
            //server.FlushAllDatabases();
            //server.ScriptFlush();
            _hash = server.ScriptLoad(checkTicketLua);
            _db = conn.GetDatabase(0);
            
        }

    }
}
