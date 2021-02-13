using System;
using System.Collections.Generic;
using System.Text;

namespace VentaRealApp.Models
{
   public class GenericResponse
   {
      public int Success { get; set; }
      public string Message { get; set; }
      public object Data { get; set; }
   }
}
