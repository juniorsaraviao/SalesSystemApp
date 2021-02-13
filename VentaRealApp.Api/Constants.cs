using System;
using System.Collections.Generic;
using System.Text;

namespace VentaRealApp.Api
{
   public static class Constants
   {
      public const string BASE_URL    = "https://wsventa.conveyor.cloud";
      public const string LOGIN       = "/api/user/login";
      public const string GET_CLIENT  = "/api/cliente";
      public const string EMPTY_FIELD = "Add email and password";

      public static string Token { get; set; }
   }
}
