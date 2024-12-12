using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juwelMaster.Service
{
    public class ClientRep : IClientRep
    {
        private readonly B1kolychevaDemContext _context = new B1kolychevaDemContext();

        public async Task<Client> AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public Task<List<Client>> GetClient()
        {
            return _context.Clients.ToListAsync();
        }

        public Task<Client> GetClientId(int clientId)
        {
            return _context.Clients.FirstOrDefaultAsync(x => x.ClientId == clientId);
        }
    }
}
