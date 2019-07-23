using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeCare.Model;
using WeCare.Services.Interfaces;
using Xamarin.Forms.Internals;

namespace WeCare.Services
{
    public class LoginService : ILoginService
    {
        public bool Logar(LoginModel model)
        {

            bool result = false;
            try
            {
                result = true;

            }

            catch (Exception ex)
            {
                Log.Warning("Erro", ex.Message);
            }

            return result;
        }
    }
}
