using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeCare.Data;
using WeCare.Model;
using WeCare.Services.Interfaces;

namespace WeCare.Services
{
    public class ProntuarioService : IProntuarioService
    {
        ProntuarioData _db;       

        public bool Cadastrar(ProntuarioModel model)
        {
            _db = new ProntuarioData();

            var save = _db.Save(model);

            if (save > 0)
                return true;
            else
                return false;
        }
        public bool Atualizar(ProntuarioModel model)
        {
            _db = new ProntuarioData();

            var updated = _db.Update(model);

            if (updated > 0)
                return true;
            else
                return false;
        }

        public ProntuarioModel GetById(Guid id)
        {
            _db = new ProntuarioData();

            return _db.GetById(id);
        }

        public List<ProntuarioModel> GetAll()
        {
            _db = new ProntuarioData();

            return _db.GetAll();
        }
    }
}
