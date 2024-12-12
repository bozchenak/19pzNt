using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    interface IClientRep
    {
        Task<List<Client>> GetClient();

        Task<Client> GetClientId(int ClientId);

        Task<Client> AddClient(Client client);
    }
}
