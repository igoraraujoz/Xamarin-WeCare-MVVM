using System;
using System.Collections.Generic;
using System.Text;
using WeCare.Model;

namespace WeCare.Services.Interfaces
{
    public interface IEspecialidadeService
    {
        List<EspecialidadeModel> GetAll();
    }
}
