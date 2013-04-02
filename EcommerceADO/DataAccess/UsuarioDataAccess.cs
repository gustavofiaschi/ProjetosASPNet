using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using Common;

namespace DataAccess
{
    public class UsuarioDataAccess : Conexao
    {
        public UsuarioDataAccess()
            : base()
        {
            
        }

        public void Salvar(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand("Insert into Usuario (Login, Status, Senha, PessoaId) values (@Login, @Status, @Senha, @PessoaId)", this.Connection);

            cmd.Parameters.AddWithValue("@Login", usuario.Login);
            cmd.Parameters.AddWithValue("@Status", (short)usuario.Status);
            cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@PessoaId", usuario.PessoaId);

            this.Connect();
            int linhas = cmd.ExecuteNonQuery();
            this.Disconnect();
        }
        
        public List<Usuario> RetornaUsuarios()
        {
            SqlCommand cmd = new SqlCommand("Select * From Usuario", this.Connection);

            this.Connect();
            SqlDataReader dr = cmd.ExecuteReader();

            List<Usuario> listaUsuarios = new List<Usuario>();

            while (dr.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = int.Parse(dr["Id"].ToString());
                usuario.Login = dr["Login"].ToString();

                bool status = bool.Parse(dr["Status"].ToString());
                usuario.Status = status ? StatusUsuario.Ativado : StatusUsuario.Inativo;
                usuario.Senha = dr["Senha"].ToString();                    
                usuario.PessoaId = int.Parse(dr["PessoaId"].ToString());

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }
    }
}
