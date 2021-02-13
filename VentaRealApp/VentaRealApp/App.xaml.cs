using System;
using System.Threading.Tasks;
using VentaRealApp.Services;
using VentaRealApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaRealApp
{
   public partial class App : Application
   {
      private readonly LoginService _loginService;
      public App()
      {
         InitializeComponent();
         Device.SetFlags(new[] { "SwipeView_Experimental" });

         DependencyService.Register<MockDataStore>();
         _loginService = new LoginService();
         //MainPage = new LoginPage();
         RedirectPage();
      }

      public void RedirectPage()
      {
         var email    = Preferences.Get("email", string.Empty);
         var password = Preferences.Get("password", string.Empty);
         if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
         {            
            MainPage = new AppShell();            
         }
         else
         {
            MainPage = new LoginPage();
         }
      }

      protected override void OnStart()
      {         
      }

      protected override void OnSleep()
      {
      }

      protected override void OnResume()
      {
      }
   }
}
