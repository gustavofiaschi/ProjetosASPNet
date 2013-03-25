using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataAccess;

namespace Business
{
    public class PessoaBusiness
    {
        /// <summary>
        /// Metodo responsavel pelo cadastro de pessoas
        /// </summary>
        /// <param name="pessoa">pessoa para cadastro</param>
        public void Salvar(Pessoa pessoa)
        {
            //Validações
            if (pessoa == null)
            {
                throw new Exception("Objeto pessoa está nulo.");
            }
            else if (string.IsNullOrWhiteSpace(pessoa.Nome))
            {
                throw new Exception("Campo Nome está vazio.");
            }

            PessoaDataAccess access = new PessoaDataAccess();
            access.Salvar(pessoa);
        }

        public List<Pessoa> RetornaPessoas()
        {
            return new PessoaDataAccess().RetornaPessoas();
        }
    }
}
