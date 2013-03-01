using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database;

namespace Ecommerce.Business
{
    public class UsuarioBusiness
    {
        private EcommerceDatabaseContainer contexto;

        public UsuarioBusiness()
        {
            this.contexto = new EcommerceDatabaseContainer();
        }

        public List<Usuario> ListarUsuarios()
        {
            return this.contexto.Usuario.ToList();
        }
    }
}
