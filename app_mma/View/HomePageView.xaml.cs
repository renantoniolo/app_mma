using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app_mma.ViewModel;
using Xamarin.Forms;

namespace app_mma.View
{
    public partial class HomePageView : ContentPage
    {
        private HomePageViewModel _homePageViewModel;

        public HomePageView(string usuario)
        {
            InitializeComponent();

            _homePageViewModel = new HomePageViewModel(usuario);
            this.BindingContext = _homePageViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await _homePageViewModel.ThisOnAppearing();

        }
    }
}
