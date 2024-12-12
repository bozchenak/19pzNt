using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    public class UserRep : IUserRep
    {
        private readonly B1kolychevaDemContext _context = new B1kolychevaDemContext();
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int userId)
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

        public Task<List<User>> GetUser()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User> GetUserId(int userId)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<User> UpdateUser(User user)
        {
            if (!_context.Users.Local.Any(o => o.UserId == user.UserId))
            {
                _context.Users.Attach(user);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
