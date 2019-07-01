using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeCare.ViewModel;

namespace WeCare.Services.Interfaces
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseVM;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseVM;

        Task NavigateToAsync(Type viewModelType);
    }
}

