using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using app_mma.Interface;
using app_mma.Model;
using app_mma.Service;
using app_mma.View;
using Xamarin.Forms;

namespace app_mma.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {

        #region Propriedades

        private ObservableCollection<Lutador> list_Lutadores;
        public ObservableCollection<Lutador> List_Lutadores
        {
            get { return list_Lutadores; }
            set
            {
                list_Lutadores = value;
                this.Notify(nameof(List_Lutadores));
            }
        }

        private bool isload = true;
        public bool IsLoad
        {
            get { return isload; }
            set
            {
                isload = value;
                this.Notify(nameof(IsLoad));
            }
        }

        private List<Lutador> _lutadores_Selecionados;

        public string Usuario { get; set; }

        public int CountLutadores { get; set; }

        private IAlertService alertService;

        public ICommand IniciarCombateCommand { get; set; }

        #endregion

        #region Construtor

        public HomePageViewModel(string usuario)
        {
            Usuario = usuario;
            CountLutadores = 0;
            

            this.alertService = DependencyService.Get<IAlertService>();
            _lutadores_Selecionados = new List<Lutador>();
            this.IniciarCombateCommand = new Command(() => IniciarCombateAsync());
        }

        #endregion

        #region Metodos

        internal async Task ThisOnAppearing()
        {
            var list = await CommunicationService.GetAllLutadores();

            if (list == null)
                return;

            List_Lutadores = new ObservableCollection<Lutador>(list);

            IsLoad = false;

        }

        private Lutador lutadorSelecionado;
        public Lutador LutadorSelecionado
        {
            get { return lutadorSelecionado; }
            set
            {
                try
                {
                    var lutador = (Lutador)value;

                    if (lutador == null)
                        return;

                    if(_lutadores_Selecionados.Count < 20)
                    {
                        CountLutadores++;
                        _lutadores_Selecionados.Add(lutador);
                        List_Lutadores.Remove(lutador);
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private void IniciarCombateAsync()
        {
            if (_lutadores_Selecionados.Count < 20)
            {
                alertService.ShowAsync("Informativo", "Ainda falta escolher " +
                                      (20 - _lutadores_Selecionados.Count).ToString()  + " Lutadores!!", "Ok");
                return;
            }

            InicioCombates();
        }

        private void InicioCombates()
        {
            
            List<Lutador> grupo = new List<Lutador>(); 
            List<List<Lutador>> Lista_Grupos = new List<List<Lutador>>();
            List<Lutador> Lutadores = new List<Lutador>(_lutadores_Selecionados.OrderBy(i => i.Idade));

            // Ordem por grupo
            for (int cont = 0; cont < Lutadores.Count; cont ++)
            {
                Lutador lutador = Lutadores[cont];

                if (grupo.Count < 5)
                {
                    grupo.Add(lutador);
                
                }
                else
                {
                    Lista_Grupos.Add(grupo);
                    grupo = new List<Lutador>();
                    grupo.Add(lutador);
                }

                if(cont == Lutadores.Count - 1) Lista_Grupos.Add(grupo);
            }

            // Fase de Grupos
            for(int cont = 0; cont < Lista_Grupos.Count; cont++)
            {
                var grupoLutadores = Lista_Grupos[cont];

                for(int i=0; i < grupoLutadores.Count; i++)
                {
                    Lutador lutador = grupoLutadores[i];

                    var lutadorindiceVitoria = lutador.Vitorias / lutador.Lutas;

                    for(int j= i+1; j < grupoLutadores.Count; j++)
                    {
                        Lutador desafinate = grupoLutadores[j];

                        var desafianteindiceVitoria = lutador.Vitorias / lutador.Lutas;

                        if (lutadorindiceVitoria > desafianteindiceVitoria)
                            lutador.Pontucao++;
                        else
                            desafinate.Pontucao++;

                    }
                }
                
            }

            // Quartas de Finais 
            List<Lutador> quartasFinal = new List<Lutador>();

            for(int k = 0; k < Lista_Grupos.Count; k++)
            {
                var grupoResult = Lista_Grupos[k];

                List<Lutador> newGrupo = new List<Lutador>(grupoResult.OrderByDescending(i => i.Pontucao));

                quartasFinal.Add(newGrupo[0]);
                quartasFinal.Add(newGrupo[1]);
            }

            List<Lutador> SemiFinal = new List<Lutador>();

            // jogo 01
            if ((quartasFinal[0].Vitorias / quartasFinal[0].Lutas) > (quartasFinal[3].Vitorias / quartasFinal[3].Lutas))
                SemiFinal.Add(quartasFinal[0]);
            else
                SemiFinal.Add(quartasFinal[3]);
            // jogo 02
            if ((quartasFinal[1].Vitorias / quartasFinal[1].Lutas) > (quartasFinal[2].Vitorias / quartasFinal[2].Lutas))
                SemiFinal.Add(quartasFinal[1]);
            else
                SemiFinal.Add(quartasFinal[2]);
            // jogo 03
            if ((quartasFinal[4].Vitorias / quartasFinal[4].Lutas) > (quartasFinal[6].Vitorias / quartasFinal[6].Lutas))
                SemiFinal.Add(quartasFinal[4]);
            else
                SemiFinal.Add(quartasFinal[6]);
            // jogo 04
            if ((quartasFinal[5].Vitorias / quartasFinal[5].Lutas) > (quartasFinal[7].Vitorias / quartasFinal[7].Lutas))
                SemiFinal.Add(quartasFinal[5]);
            else
                SemiFinal.Add(quartasFinal[7]);

            // Semi Final

            List<Lutador> Final = new List<Lutador>();
            List<Lutador> DisputaTerceiro = new List<Lutador>();

            if ((SemiFinal[0].Vitorias / SemiFinal[0].Lutas) > (SemiFinal[1].Vitorias / SemiFinal[1].Lutas))
            {
                Final.Add(SemiFinal[0]);
                DisputaTerceiro.Add(SemiFinal[1]);
            }
            else
            {
                Final.Add(SemiFinal[1]);
                DisputaTerceiro.Add(SemiFinal[0]);
            }

            if ((SemiFinal[2].Vitorias / SemiFinal[2].Lutas) > (SemiFinal[3].Vitorias / SemiFinal[3].Lutas))
            {
                Final.Add(SemiFinal[2]);
                DisputaTerceiro.Add(SemiFinal[3]);
            }
            else
            {
                Final.Add(SemiFinal[3]);
                DisputaTerceiro.Add(SemiFinal[2]);
            }

            // Final

            List<Lutador> Campeoes = new List<Lutador>();

            if ((Final[0].Vitorias / Final[0].Lutas) > (Final[1].Vitorias / Final[1].Lutas))
            {
                Campeoes.Add(Final[0]);
                Campeoes.Add(Final[1]);
            }
            else
            {
                Campeoes.Add(Final[1]);
                Campeoes.Add(Final[0]);
            }

            // Terceiro Colcoado
            if ((DisputaTerceiro[0].Vitorias / DisputaTerceiro[0].Lutas) > (DisputaTerceiro[1].Vitorias / DisputaTerceiro[1].Lutas))
                Campeoes.Add(DisputaTerceiro[0]);
            else
                Campeoes.Add(DisputaTerceiro[1]);

            // Abre a view de campeoes
            Application.Current.MainPage = new NavigationPage(new ResultadoPageView(Campeoes));

        }

        #endregion
    }

}
