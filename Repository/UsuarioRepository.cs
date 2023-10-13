using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Configuration;
using TesteEsig.Model;

namespace TesteEsig.Repository
{
    public class UsuarioRepository
    {
        private readonly IDbConnection _connection;
        public UsuarioRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["esigConnectionString"].ConnectionString);
        }
        public async Task<Usuario> Obter(string login)
        {
            var sql = @"SELECT pessoa_id PessoaId,
	                           login Login, 
	                           senha Senha 
                        FROM usuario 
                        WHERE login = @Login";

            var parametros = new DynamicParameters();
            parametros.Add("@Login", login);

            var usuario = await _connection.QueryFirstOrDefaultAsync<Usuario>(sql, parametros);

            return usuario;
        }

        public async Task<bool> Inserir(Usuario usuario)
        {
            var sql = @"INSERT usuario
                        (pessoa_id, login, senha)
                        VALUES
                        (@PessoaId, @Login, @Senha)";

            var parametros = new DynamicParameters();
            parametros.Add("@PessoaId", usuario.PessoaId);
            parametros.Add("@Login", usuario.Login);
            parametros.Add("@Senha", usuario.Senha);

            var insert = await _connection.ExecuteAsync(sql, parametros) > 0;

            return insert;
        }
    }
}