using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace VentaRealApp.Api
{
   public class ApiRequest
   {
      private readonly HttpClient _httpClient;
      public ApiRequest()
      {
         //var handler = new HttpClientHandler(); 
         _httpClient = new HttpClient();
      }

      public async Task<string> LoginMethod(string parameters)
      {
         try
         {
            //AddHeaders();
            var content = new StringContent(parameters, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri(Constants.BASE_URL + Constants.LOGIN),
               Content    = content,
               Method     = HttpMethod.Post,
            };
            var response = await _httpClient.SendAsync(request);
            
            return await response.Content.ReadAsStringAsync();            
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public async Task<string> GetClients()
      {
         try
         {
            //AddHeaders();            
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri(Constants.BASE_URL + Constants.GET_CLIENT),
               Method     = HttpMethod.Get
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsStringAsync();
            }
            else
            {
               return "";
            }         
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public async Task<string> EditClient(string parameters)
      {
         try
         {
            //AddHeaders();            
            var content = new StringContent(parameters, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri(Constants.BASE_URL + Constants.GET_CLIENT),
               Content    = content,
               Method     = HttpMethod.Put
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsStringAsync();
            }
            else
            {
               return string.Empty;
            }         
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public async Task<string> AddClient(string parameters)
      {
         try
         {
            //AddHeaders();            
            var content = new StringContent(parameters, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri(Constants.BASE_URL + Constants.GET_CLIENT),
               Content    = content,
               Method     = HttpMethod.Post
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsStringAsync();
            }
            else
            {
               return string.Empty;
            }         
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public async Task<string> DeleteClient(int clientId)
      {
         try
         {
            //AddHeaders();                        
            var request = new HttpRequestMessage()
            {
               RequestUri = new Uri(Constants.BASE_URL + Constants.GET_CLIENT + $"/{clientId}"),
               Method     = HttpMethod.Delete
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
               return await response.Content.ReadAsStringAsync();
            }
            else
            {
               return string.Empty;
            }         
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      public void AddHeaders()
      {
         if (!string.IsNullOrEmpty(Constants.Token))
         {
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Constants.Token}");
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
         }
      }
   }
}
