using Acr.UserDialogs;
using Autofac;
using System;
using System.Threading.Tasks;
using VentaRealApp.Api;
using VentaRealApp.Interfaces;
using VentaRealApp.Services;
using Xamarin.Forms;

namespace VentaRealApp.ViewModels
{
   public class LoginViewModel : BaseViewModel
   {
      private readonly ILoginService _loginService;

      public Command LoginCommand { get; }

      private string _email;
      private string _password;
      private string _message;
      private bool   _messageVisible;

      public string Email
      {
         get => _email;
         set 
         { 
            _email = value;
            OnPropertyChanged("Email");
         }
      }

      public string Password
      {
         get => _password;
         set
         {
            _password = value;
            OnPropertyChanged("Password");
         }
      }

      public string Message
      {
         get => _message;
         set
         {
            _message = value;
            OnPropertyChanged("Message");
         }
      }

      public bool MessageVisible
      {
         get => _messageVisible;
         set
         {
            _messageVisible = value;
            OnPropertyChanged("MessageVisible");
         }
      }

      public LoginViewModel(ILoginService loginService)
      {
         _loginService  = loginService;
         LoginCommand   = new Command( async () => await OnLoginClicked() );
         MessageVisible = false;
      }

      public LoginViewModel() : this( DIServiceContainer.Container.Resolve<ILoginService>() )
      {        
      }

      private async Task OnLoginClicked()
      {
         try
         {
            using (UserDialogs.Instance.Loading("Loading"))
            {               
               if (_loginService.ValidateUser(Email, Password))
               {                  
                  var response = await _loginService.LoginProcess(Email, Password);

                  if (response.Success == 1)
                  {
                     Application.Current.MainPage = new AppShell();
                  }
                  else
                  {
                     MessageVisible = true;
                     Message        = response.Message;
                  }                  
               }
               else
               {
                  MessageVisible = true;
                  Message        = Constants.EMPTY_FIELD;
               }
            }
         }
         catch (Exception e)
         {
            MessageVisible = true;
            Message        = e.Message;
         }
         
         
         // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
         //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");         
      }
   }
}
