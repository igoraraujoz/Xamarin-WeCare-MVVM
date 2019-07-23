using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeCare.Model;

namespace WeCare.Services.Interfaces
{
    public interface ILoginService
    {
        bool Logar(LoginModel model);
    }
}
