using System;
using System.Threading.Tasks;
using app_mma.Interface;

namespace app_mma.Service
{
    public class AlertService : IAlertService
    {
        public async Task ShowAsync(string title, string message, string buttonOk)
        {
            await App.Current.MainPage.DisplayAlert(title, message, buttonOk);
        }

    }
}
