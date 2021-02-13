using Acr.UserDialogs;
using Autofac;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using VentaRealApp.Interfaces;
using VentaRealApp.Models;
using VentaRealApp.Services;
using VentaRealApp.Util;
using VentaRealApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace VentaRealApp.ViewModels
{
   public class ClientPageViewModel : BaseViewModel
   {
      private readonly IClientService _clientService;
      private readonly ILoginService  _loginService;
      public ClientPageViewModel(ILoginService loginService, IClientService clientService)
      {
         _clientService = clientService;
         _loginService  = loginService;
      }

      public ClientPageViewModel() : this(DIServiceContainer.Container.Resolve<ILoginService>(),
         DIServiceContainer.Container.Resolve<IClientService>())
      {

      }

      private IList<Client> _clientList;

      public IList<Client> ClientList
      {
         get => _clientList;
         set
         {
            _clientList = value;
            OnPropertyChanged("ClientList");
         }
      }

      private INavigation _navigation;

      public INavigation Navigation
      {
         get => _navigation;
         set
         {
            _navigation = value;
            OnPropertyChanged("Navigation");
         }
      }

      private Client _client;

      public Client Client
      {
         get => _client;
         set
         {
            _client = value;
            OnPropertyChanged("Client");
         }
      }

      private string _titlePage;

      public string TitlePage
      {
         get => _titlePage;
         set
         {
            _titlePage = value;
            OnPropertyChanged("TitlePage");
         }
      }


      public string EditIcon   => FontAwesomeIcons.Edit + Environment.NewLine;
      public string DeleteIcon => FontAwesomeIcons.Trash + Environment.NewLine;


      public ICommand AddEditClientCommand => new Command(async () => await AddEditClient());
      public ICommand AddClientPopup       => new Command(async () => await AddPopup());
      public ICommand ClosePopupCommand    => new Command(async () => await ClosePopup());
      public ICommand DeleteCommand        => new Command<Client>(async (client) => await DeleteClient(client));
      public ICommand EditCommand          => new Command<Client>(async (client) => await EditClient(client));


      public async Task GetClients()
      {
         try
         {
            using (UserDialogs.Instance.Loading("Loading"))
            {
               var email = Preferences.Get("email", string.Empty);
               var password = Preferences.Get("password", string.Empty);
               if (_loginService.ValidateUser(email, password))
               {
                  await _loginService.LoginProcess(email, password);
               }

               await GetClientsFromAPI();
            }

            UserDialogs.Instance.Toast("Clients Loaded", new TimeSpan(0, 0, 3));
         }
         catch (Exception ex)
         {
            throw new Exception(ex.Message);
         }
      }

      private async Task GetClientsFromAPI()
      {
         try
         {
            var clients = await _clientService.GetClients();
            ClientList  = clients.OrderByDescending(client => client.IdInt).ToList();
         }
         catch (Exception ex)
         {
            UserDialogs.Instance.Toast(ex.Message, new TimeSpan(0, 0, 3));
         }
         
      }

      private async Task DeleteClient(Client client)
      {
         try
         {
            var isDeleted = await _clientService.DeleteClient(client);
            if (isDeleted.Item1)
            {
               using (UserDialogs.Instance.Loading())
               {
                  await GetClientsFromAPI();
               }
               UserDialogs.Instance.Toast(isDeleted.Item2, new TimeSpan(0, 0, 3));
            }
            else
            {
               UserDialogs.Instance.Toast("Something went wrong, try later", new TimeSpan(0, 0, 3));
            }
         }
         catch (Exception ex)
         {
            UserDialogs.Instance.Toast(ex.Message, new TimeSpan(0, 0, 3));
         }
      }

      private async Task AddPopup()
      {
         Client        = new Client();
         Title         = "Add Client";
         var popupPage = new ClientAddEditPopupPage
         {
            BindingContext = this
         };
         await PopupNavigation.Instance.PushAsync(popupPage);
      }

      private async Task EditClient(Client client)
      {
         Client        = client;
         Title         = "Edit Client";
         var popupPage = new ClientAddEditPopupPage
         {
            BindingContext = this
         };
         await PopupNavigation.Instance.PushAsync(popupPage);
      }

      private async Task AddEditClient()
      {
         try
         {
            if (string.IsNullOrEmpty(Client.Nombre))
            {
               return;
            }

            if (Client.Id != null)
            {
               var isEdited = await _clientService.EditClient(Client);

               if (isEdited.Item1)
               {
                  await ClosePopup();
                  using (UserDialogs.Instance.Loading())
                  {
                     await GetClientsFromAPI();
                  }
                  UserDialogs.Instance.Toast(isEdited.Item2, new TimeSpan(0, 0, 3));
               }
               else
               {
                  UserDialogs.Instance.Toast("Something went wrong, try later", new TimeSpan(0, 0, 3));
               }
            }
            else
            {
               var isAdded = await _clientService.AddClient(Client);

               if (isAdded.Item1)
               {
                  await ClosePopup();
                  using (UserDialogs.Instance.Loading())
                  {
                     await GetClientsFromAPI();
                  }
                  UserDialogs.Instance.Toast(isAdded.Item2, new TimeSpan(0, 0, 3));
               }
               else
               {
                  UserDialogs.Instance.Toast("Something went wrong, try later", new TimeSpan(0, 0, 3));
               }
            }                        
         }
         catch (Exception ex)
         {
            UserDialogs.Instance.Toast(ex.Message, new TimeSpan(0, 0, 3));
         }         
      }

      private async Task ClosePopup()
      {
         await PopupNavigation.Instance.PopAsync();
      }

   }
}
