using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace app_mma.ViewModel
{
    public class InicioPageViewModel : ViewModelBase
    {

        public string Usuario { get; set; }

        public ICommand EntrarCommand { get; set; }

        public InicioPageViewModel()
        {
            this.EntrarCommand = new Command(async () => await EntrarAsync());
        }

        private async Task EntrarAsync()
        {
            Debug.WriteLine(Usuario);
        }
    }
}
