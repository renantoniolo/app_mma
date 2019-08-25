using System;
using System.Threading.Tasks;

namespace app_mma.Interface
{
    public interface IAlertService
    {
        Task ShowAsync(string title, string message, string buttonOk);

    }
}
