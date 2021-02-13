using System;
using System.Threading.Tasks;
using VentaRealApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VentaRealApp
{
   public partial class AppShell : Xamarin.Forms.Shell
   {
      public AppShell()
      {
         InitializeComponent();
         Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
         Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
      }

      private async void OnMenuItemClicked(object sender, EventArgs e)
      {
         Preferences.Set("email", string.Empty);
         Preferences.Set("password", string.Empty);
         await Shell.Current.GoToAsync("//LoginPage");
         //App.Current.MainPage = new LoginPage();
      }
   }
}
