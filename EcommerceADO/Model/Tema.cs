using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Tema
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public static List<Tema> RetornaTemas()
        {
            List<Tema> listaTemas = new List<Tema>();
            
            listaTemas.Add(new Tema() { Id = "Padrao", Nome = "Tema Padrão" });

            Tema blue = new Tema();
            blue.Id = "Blue";
            blue.Nome = "Tema Azul";
            listaTemas.Add(blue);

            listaTemas.Add(new Tema() { Id = "Red", Nome = "Tema Vermelho" });
            listaTemas.Add(new Tema() { Id = "Green", Nome = "Tema Green" });

            return listaTemas;
        }
    }
}
