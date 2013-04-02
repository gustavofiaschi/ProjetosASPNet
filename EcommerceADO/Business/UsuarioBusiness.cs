using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataAccess;
using Common;

namespace Business
{
    public class UsuarioBusiness
    {
        /// <summary>
        /// Metodo responsavel pelo cadastro de pessoas
        /// </summary>
        /// <param name="pessoa">pessoa para cadastro</param>
        public void Salvar(Usuario usuario)
        {
            //Validações
            if (usuario == null)
            {
                throw new Exception("Objeto pessoa está nulo.");
            }
            else if (string.IsNullOrWhiteSpace(usuario.Login))
            {
                throw new Exception("Campo Login está vazio.");
            }
            else if (string.IsNullOrWhiteSpace(usuario.Senha))
            {
                throw new Exception("Campo Senha está vazio.");
            }

            UsuarioDataAccess access = new UsuarioDataAccess();
            access.Salvar(usuario);
        }

        public List<Usuario> RetornaUsuarios()
        {
            return new UsuarioDataAccess().RetornaUsuarios();
        }

        public Dictionary<StatusUsuario, string> RetornaStatus()
        {
            Dictionary<StatusUsuario, string> listaStatus = new Dictionary<StatusUsuario, string>();

            foreach (var item in Enum.GetValues(typeof(StatusUsuario)))
            {
                StatusUsuario chave = (StatusUsuario)item;
                string valor = ((StatusUsuario)item).ToString();

                listaStatus.Add(chave, valor);
            }

            return listaStatus;
        }
    }
}
