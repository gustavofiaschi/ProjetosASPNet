using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Common
{
    public enum StatusUsuario : short
    {
        Inativo = 0,
        Ativado = 1        
    }

    public enum ProdutoCategorias : short
    {
        [Description("Todos")]
        Todos = 0,
        [Description("EletroEletrônicos")]
        Eletronicos = 1,
        [Description("Papelaria")]
        Papelaria = 2,
        [Description("Eletrodomésticos")]
        EletroDomesticos = 3,
        [Description("Livros")]
        Livros = 4,
        [Description("Lazer")]
        Lazer = 5
    }
}
