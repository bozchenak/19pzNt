using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    public class RequestRep : IRequestRep
    {
        private readonly B1kolychevaDemContext _context = new B1kolychevaDemContext();

        public async Task<Request> AddRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteRequest(int requestId)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    var order = _context.Orders.Include("OrderItems")
            //        .Include("OrderItems.OrderItemsOptions")
            //        .FirstOrDefault(o => o.Id == orderId);

            //    if (order != null)
            //    {
            //        foreach (OrderItem item in order.OrderItems)
            //        {
            //            foreach (var itemOpt in item.OrderItemOptions)
            //            {
            //                _context.OrderItemOptions.Remove(itemOpt);
            //            }
            //            _context.OrderItems.Remove(item);
            //        }
            //        _context.Orders.Remove(order);
            //    }

            //    await _context.SaveChangesAsync();
            //    scope.Complete();
            //}
        }

        public Task<List<Request>> GetRequest() => _context.Requests.ToListAsync();


        public Task<Request> GetRequestId(int requestId)
        {
            return _context.Requests.FirstOrDefaultAsync(b => b.RequestId == requestId);
        }

        public async Task<Request> UpdateRequest(Request request)
        {
            if (!_context.Requests.Local.Any(o => o.RequestId == request.RequestId))
            {
                _context.Requests.Attach(request);
            }
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
