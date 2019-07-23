using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeCare.Model;

namespace WeCare.Services.Interfaces
{
    public interface IProntuarioService
    {
        bool Cadastrar(ProntuarioModel model);
        bool Atualizar(ProntuarioModel model);
        ProntuarioModel GetById(Guid id);
        List<ProntuarioModel> GetAll();
    }
}
