using System;
using System.Collections.Generic;
using System.Text;

namespace VentaRealApp.Models
{
   public class Client
   {
      public string Id { get; set; }
      public int IdInt => int.Parse( Id );
      public string Nombre { get; set; }
      public object[] Venta { get; set; }
   }

   public class ClientResponse
   {
      public int Success { get; set; }
      public string Message { get; set; }
      public IList<Client> Data { get; set; }
   }
}
