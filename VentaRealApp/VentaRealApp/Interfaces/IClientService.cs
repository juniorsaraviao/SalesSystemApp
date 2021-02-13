using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentaRealApp.Models;

namespace VentaRealApp.Interfaces
{
   public interface IClientService
   {
      Task<List<Client>> GetClients();
      Task<Tuple<bool, string>> EditClient(Client client);
      Task<Tuple<bool, string>> AddClient(Client client);
      Task<Tuple<bool, string>> DeleteClient(Client client);
   }
}
