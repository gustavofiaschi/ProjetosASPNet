using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Common
{
    public class Enumeradores
    {
        public enum StatusUsuario : short
        {
            Inativo = 0,
            Ativo = 1
        }

        public enum StatusPedido : short
        {
            Cancelado = 0,
            Aberto = 1,
            Pendente = 2,
            Fechado = 3,
            Faturado = 4
        }
    }
}
