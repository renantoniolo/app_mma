using System;
using System.Collections.Generic;
using app_mma.ViewModel;
using Xamarin.Forms;

namespace app_mma.View
{
    public partial class InicioPageView : ContentPage
    {
        public InicioPageView()
        {
            InitializeComponent();

            this.BindingContext = new InicioPageViewModel();
        }
    }
}
