using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using app_mma.Interface;
using app_mma.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_mma.ViewModel
{
    public class InicioPageViewModel : ViewModelBase
    {

        #region Propiedade

        public string Usuario { get; set; }

        public ICommand EntrarCommand { get; set; }

        private IAlertService alertService;

        #endregion

        #region Construtor

        public InicioPageViewModel()
        {
            this.alertService = DependencyService.Get<IAlertService>();
            this.EntrarCommand = new Command(() => EntrarAsync());
        }

        #endregion

        #region Metodos

        private void EntrarAsync()
        {
            if (String.IsNullOrEmpty(Usuario))
            {
                alertService.ShowAsync("Atenção", "Por favor informe um nome!","Ok");
                return;
            }

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                Application.Current.MainPage = new NavigationPage(new HomePageView(Usuario));
            }
            else { 
                alertService.ShowAsync("Atenção", "Por favor, verifique sua conexão internet!", "Ok");
                return;
            }
            
        }

        #endregion

    }
}
