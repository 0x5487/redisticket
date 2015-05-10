local x = function (buyItem)
	local result = true
		for key,value in pairs(buyItem) do
			local count = redis.call('LLEN', value.TicketId)
			if count < value.Quantity then
				result = "NoTicket"
			return result
		end
	end
	return result
end

local z = function (value)
	local buyItem = cjson.decode(value)
	local checkQ = x(buyItem)
	
	if checkQ ~= true then
		return checkQ
	end

	for key,value in pairs(buyItem) do
		local length = value.Quantity - 1
		buyItem[key].StockItems = redis.call('LRANGE', value.TicketId, 0, length)
		redis.call('LTRIM', value.TicketId, value.Quantity, -1)
	end
	
	local result = cjson.encode(buyItem)
	return result
end 

return (z(KEYS[1]))