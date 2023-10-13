using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web.Configuration;
using TesteEsig.Model;

namespace TesteEsig.Repository
{
    public class PessoaSalarioRepository
    {
        private readonly IDbConnection _connection;
        public PessoaSalarioRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["esigConnectionString"].ConnectionString);
        }

        public async Task<IEnumerable<PessoaSalario>> ObterTodos()
        {
            var sql = _selectBase + "ORDER BY nome_pessoa";
            var pessoaSalario = await _connection.QueryAsync<PessoaSalario>(sql);

            return pessoaSalario;           
        }

        public async Task<PessoaSalario> Obter(int pessoaId)
        {
            var sql = _selectBase + "WHERE pessoa_id = @PessoaId";

            var parametros = new DynamicParameters();
            parametros.Add("@PessoaId", pessoaId);
            
            var pessoaSalario = await _connection.QueryFirstOrDefaultAsync<PessoaSalario>(sql, parametros);

            return pessoaSalario;
        }
        private readonly string _selectBase = @"SELECT pessoa_id PessoaId, 
	                                                   nome_pessoa Nome, 
	                                                   nome_cargo Cargo, 
	                                                   salario Salario 
                                                FROM pessoa_salario "; 
    }
}

