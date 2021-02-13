using System.ComponentModel;
using VentaRealApp.ViewModels;
using Xamarin.Forms;

namespace VentaRealApp.Views
{
   public partial class ItemDetailPage : ContentPage
   {
      public ItemDetailPage()
      {
         InitializeComponent();
         BindingContext = new ItemDetailViewModel();
      }
   }
}