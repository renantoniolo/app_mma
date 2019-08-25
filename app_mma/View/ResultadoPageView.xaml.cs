using System;
using System.Collections.Generic;
using app_mma.Model;
using app_mma.ViewModel;
using Xamarin.Forms;

namespace app_mma.View
{
    public partial class ResultadoPageView : ContentPage
    {
        public ResultadoPageView(List<Lutador> Campeoes)
        {
            InitializeComponent();

            this.BindingContext = new ResultadoPageViewModel(Campeoes);
        }
    }
}
