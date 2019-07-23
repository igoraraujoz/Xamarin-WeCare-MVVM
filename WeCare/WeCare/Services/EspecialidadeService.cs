using System;
using System.Collections.Generic;
using System.Text;
using WeCare.Data;
using WeCare.Model;
using WeCare.Services.Interfaces;

namespace WeCare.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        EspecialidadeData _db;

        public List<EspecialidadeModel> GetAll()
        {
            _db = new EspecialidadeData();

            var lista = _db.GetAll();

            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                //Carga inicial da tabela
                var carga = new List<EspecialidadeModel>() {
                    new EspecialidadeModel() {  Id = new Guid("6009f71f-11db-4f1d-b2f7-2c2bfe859a74"), Descricao = "Clinico Geral" },
                    new EspecialidadeModel() {Id= new Guid("1bb1ee8d-9b06-48bd-8417-2f405cf539bb"), Descricao = "Dermatologista" }
                };

                foreach (var item in carga)
                {
                    _db.Save(item);
                }

                return _db.GetAll();
            }
        }
    }
}
