using System;
using System.Collections.Generic;
using System.Text;

namespace VentaRealApp.Models
{
   public class UserResponse
   {
      public int Success { get; set; }
      public string Message { get; set; }
      public Data Data { get; set; }
   }

   public class Data
   {
      public string Token { get; set; }
   }
}
