using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public StatusUsuario Status { get; set; }
    }
}
