using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeCare.Model
{
    public class ProntuarioModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        [Ignore]
        public string DateTimeString { get; set; }
        [Ignore]
        public List<EspecialidadeModel> Especialidade { get; set; }
        [Ignore]
        public EspecialidadeModel SelectedEspecialidade { get; set; }
        public string UnidadeClinica { get; set; }
        public string Medico { get; set; }
        public string Descricao { get; set; }
        public Guid EspecialidadeId { get; set; }
    }
}
