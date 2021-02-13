using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VentaRealApp.Interfaces;
using VentaRealApp.Services;
using VentaRealApp.Views;

namespace VentaRealApp
{
   public class DIConfiguration
   {
      public static IContainer Configure()
      {
         var builder = new ContainerBuilder();
         builder.RegisterType<LoginService>().As<ILoginService>();
         builder.RegisterType<ClientService>().As<IClientService>();
         builder.RegisterType<LoginPage>();
         builder.RegisterType<ClientPage>();
         builder.RegisterType<ClientAddEditPopupPage>();

         return builder.Build();
      }
   }
}
