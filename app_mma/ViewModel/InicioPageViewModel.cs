using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using app_mma.View;
using Xamarin.Forms;

namespace app_mma.ViewModel
{
    public class InicioPageViewModel : ViewModelBase
    {

        public string Usuario { get; set; }

        public ICommand EntrarCommand { get; set; }

        public InicioPageViewModel()
        {
            this.EntrarCommand = new Command(() => EntrarAsync());
        }

        private void EntrarAsync()
        {
            if (Usuario == null)
                return;

            Application.Current.MainPage = new NavigationPage(new HomePageView(Usuario));
        }
    }
}
