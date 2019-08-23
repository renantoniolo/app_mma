using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app_mma.Model;
using app_mma.Service;

namespace app_mma.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {

        public List<Lutador> List_Lutadores { get; set; }


        public HomePageViewModel(string usuario)
        {

        }

        internal async Task ThisOnAppearing()
        {
            var list_lutadores = await CommunicationService.GetAllLutadores();

            if (list_lutadores != null)
                List_Lutadores = list_lutadores;
        }
    }
}
