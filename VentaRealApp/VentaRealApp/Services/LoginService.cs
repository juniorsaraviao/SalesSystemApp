using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using VentaRealApp.Api;
using VentaRealApp.Interfaces;
using VentaRealApp.Models;
using Xamarin.Essentials;

namespace VentaRealApp.Services
{
   public class LoginService : ILoginService
   {
      public async Task<GenericResponse> LoginProcess(string username, string password)
      {
         try
         {
            var user        = new User() { Email = username, Password = password };
            var json        = JsonConvert.SerializeObject(user);
            var apiRequest  = new ApiRequest();
            var response    = await apiRequest.LoginMethod(json);
            var deserialize = JsonConvert.DeserializeObject<GenericResponse>(response);

            if (deserialize.Success == 1)
            {
               Preferences.Set("email", username);
               Preferences.Set("password", password);
               var userResponse   = JsonConvert.DeserializeObject<UserResponse>(response);
               Constants.Token    = userResponse.Data.Token;
            }

            return deserialize;
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }         
      }

      public bool ValidateUser(string username, string password)
      {
         return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
      }
   }
}
