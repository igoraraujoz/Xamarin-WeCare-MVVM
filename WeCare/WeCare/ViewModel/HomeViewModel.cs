using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeCare.Model;
using WeCare.Services.Interfaces;
using Xamarin.Forms;

namespace WeCare.ViewModel
{
    public class HomeViewModel : BaseVM
    {
        
        INavigationService _serviceNavigation;
        public HomeViewModel(INavigationService serviceNavigation)
        {
            
            _serviceNavigation = serviceNavigation;
        }

        public ICommand ProntuarioCommand
        {
            get
            {
                return new Command(async (value) =>
                {
                    ProntuarioModel item = value as ProntuarioModel;
                    await _serviceNavigation.NavigateToAsync<ProntuarioViewModel>(item);
                });
            }
        }

        public ICommand HistoricoCommand
        {
            get
            {
                return new Command(async (value) =>
                {
                    ProntuarioModel item = value as ProntuarioModel;
                    await _serviceNavigation.NavigateToAsync<HistoricoViewModel>(item);
                });
            }
        }

        public ICommand AlarmCommand
        {
            get
            {
                return new Command(async (value) =>
                {
                    await Application.Current.MainPage.DisplayAlert("Sem acesso", "Olá, para acessar esta funcionalidade é necessário ser assinante", "Ok");
                });
            }
        }

        public ICommand HelpCommand
        {
            get
            {
                return new Command(async (value) =>
                {                    
                    await _serviceNavigation.NavigateToAsync<HelpViewModel>();
                });
            }
        }
    }
}
