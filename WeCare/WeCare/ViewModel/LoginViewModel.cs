using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeCare.Model;
using WeCare.Services;
using WeCare.Services.Interfaces;
using Xamarin.Forms;

namespace WeCare.ViewModel
{
    public class LoginViewModel : BaseVM
    {
        ILoginService _loginService;
        INavigationService _serviceNavigation;
        public LoginViewModel(INavigationService serviceNavigation, ILoginService loginService)
        {
            _loginService = loginService;
            _serviceNavigation = serviceNavigation;
        }


        public ICommand LogarCommand
        {
            get
            {
                return new Command(() =>
                {

                    Logar();
                });
            }
        }


        public async void Logar()
        {
            LoginModel model = new LoginModel();
            if (!string.IsNullOrEmpty(this.Usuario) && !string.IsNullOrEmpty(this.Senha))
            {
                model.Usuario = this.Usuario;
                model.Senha = this.Senha;
               
                await _serviceNavigation.NavigateToAsync<HomeViewModel>();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro !", "Usuario ou senha nao podem ser vazios", "Ok");
            }
        }

        private string usuario = string.Empty;
        public string Usuario { get { return usuario; } set { this.Set("Usuario", ref usuario, value); } }

        private string senha = string.Empty;
        public string Senha { get { return senha; } set { this.Set("Senha", ref senha, value); } }
    }
}
