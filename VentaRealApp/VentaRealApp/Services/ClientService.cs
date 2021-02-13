using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaRealApp.Api;
using VentaRealApp.Interfaces;
using VentaRealApp.Models;

namespace VentaRealApp.Services
{
   public class ClientService : IClientService
   {
      public async Task<List<Client>> GetClients()
      {
         try
         {
            var apiRequest  = new ApiRequest();
            var response    = await apiRequest.GetClients();
            var deserialize = JsonConvert.DeserializeObject<GenericResponse>(response);

            if (deserialize.Success == 1)
            {
               var clientResponse = JsonConvert.DeserializeObject<ClientResponse>(response);
               return clientResponse.Data.ToList();
            }
            else
            {
               throw new Exception("No data retrieved");
            }

         }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      }

      public async Task<Tuple<bool, string>> EditClient(Client client)
      {
         try
         {
            var apiRequest  = new ApiRequest();
            var parameter   = new Dictionary<string, string>()
            {
               { "id", client.Id },
               { "nombre", client.Nombre }
            };
            var serialize   = JsonConvert.SerializeObject(parameter);
            var response    = await apiRequest.EditClient(serialize);
            var deserialize = JsonConvert.DeserializeObject<GenericResponse>(response);

            if (deserialize.Success == 1)
            {
               return new Tuple<bool, string>(true, deserialize.Message);
            }
            else
            {
               return new Tuple<bool, string>(false, "");
            }

         }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      }

      public async Task<Tuple<bool, string>> AddClient(Client client)
      {
         try
         {
            var apiRequest  = new ApiRequest();
            var parameter   = new Dictionary<string, string>()
            {               
               { "nombre", client.Nombre }
            };
            var serialize   = JsonConvert.SerializeObject(parameter);
            var response    = await apiRequest.AddClient(serialize);
            var deserialize = JsonConvert.DeserializeObject<GenericResponse>(response);

            if (deserialize.Success == 1)
            {
               return new Tuple<bool, string>(true, deserialize.Message);
            }
            else
            {
               return new Tuple<bool, string>(true, "");
            }

         }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      }

      public async Task<Tuple<bool, string>> DeleteClient(Client client)
      {
         try
         {
            var apiRequest  = new ApiRequest();
            var response    = await apiRequest.DeleteClient(client.IdInt);
            var deserialize = JsonConvert.DeserializeObject<GenericResponse>(response);

            if (deserialize.Success == 1)
            {
               return new Tuple<bool, string>(true, deserialize.Message);
            }
            else
            {
               return new Tuple<bool, string>(false, "");
            }

         }
         catch (Exception e)
         {
            throw new Exception(e.Message);
         }
      }
   }
}
