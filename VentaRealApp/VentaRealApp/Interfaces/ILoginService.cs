using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentaRealApp.Models;

namespace VentaRealApp.Interfaces
{
   public interface ILoginService
   {
      bool ValidateUser(string username, string password);
      Task<GenericResponse> LoginProcess(string username, string password);
   }
}
