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
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Cardiologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Clinico Geral" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Dermatologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Endocrinologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Gastroenterologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Ginecologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Mastologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Neurologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Oftalmologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Ortopedista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Pediatra" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Pneumologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Reumatologista" },
                    new EspecialidadeModel() { Id = Guid.NewGuid(), Descricao = "Urologista" },
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
