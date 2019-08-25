using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using app_mma.Model;
using app_mma.View;
using Xamarin.Forms;

namespace app_mma.ViewModel
{
    public class ResultadoPageViewModel : ViewModelBase
    {

        #region Propriedades

        private ObservableCollection<Lutador> lutadores_Finalistas;
        public ObservableCollection<Lutador> Lutadores_Finalistas
        {
            get { return lutadores_Finalistas; }
            set
            {
                lutadores_Finalistas = value;
                this.Notify(nameof(Lutadores_Finalistas));
            }
        }

        public ICommand FecharCommand { get; set; }

        #endregion

        #region Cosntrutor
        public ResultadoPageViewModel(List<Lutador> Campeoes)
        {
            Lutadores_Finalistas = new ObservableCollection<Lutador>(Campeoes);
            this.FecharCommand = new Command(() => FecharAsync());
        }

        #endregion

        #region Metodos

        private void FecharAsync()
        {
            Application.Current.MainPage = new InicioPageView();

        }

        #endregion
    }
}
