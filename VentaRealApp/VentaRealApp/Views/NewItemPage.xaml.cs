using System;
using System.Collections.Generic;
using System.ComponentModel;
using VentaRealApp.Models;
using VentaRealApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VentaRealApp.Views
{
   public partial class NewItemPage : ContentPage
   {
      public Item Item { get; set; }

      public NewItemPage()
      {
         InitializeComponent();
         BindingContext = new NewItemViewModel();
      }
   }
}