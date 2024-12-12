using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    interface IUserRep
    {
        Task<List<User>> GetUser();

        //получить работника по id
        Task<User> GetUserId(int UserId);

        //обновлять список работников
        Task<User> UpdateUser(User user);

        //удаление заявки по id
        Task DeleteUser(int UserId);

        //добавление нового работника
        Task<User> AddUser(User user);
    }
}
