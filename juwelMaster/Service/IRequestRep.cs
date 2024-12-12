using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    public interface IRequestRep
    {
        Task<List<Request>> GetRequest();

        //получить заявку по id
        Task<Request> GetRequestId(int RequestId);

        //обновлять заяки
        Task<Request> UpdateRequest(Request request);

        //удаление заявки по id
        Task DeleteRequest(int requestId);

        //создание новой заявки
        Task<Request> AddRequest(Request request);
    }
}
