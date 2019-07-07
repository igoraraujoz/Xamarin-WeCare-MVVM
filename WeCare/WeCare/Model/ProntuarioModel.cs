﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeCare.Model
{
    public class ProntuarioModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public List<EspecialidadeModel> Especialidade { get; set; }
        public string UnidadeClinica { get; set; }
        public string Medico { get; set; }
        public string Descricao { get; set; }
    }
}