using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaRealApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaRealApp.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ClientPage : ContentPage
   {
      public ClientPage()
      {
         InitializeComponent();
      }

      protected override async void OnAppearing()
      {
         try
         {
            base.OnAppearing();
            var vm = (ClientPageViewModel) BindingContext;
            vm.Navigation = Navigation;
            await vm.GetClients();
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
         
      }
   }
}