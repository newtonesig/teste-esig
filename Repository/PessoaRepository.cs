using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TesteEsig.Model;

namespace TesteEsig.Repository
{
    public class PessoaRepository
    {
        private readonly IDbConnection _connection;
        public PessoaRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["esigConnectionString"].ConnectionString);
        }

        public async Task<Pessoa> Obter(int pessoaId)
        {
            var sql = @"SELECT pessoa_id PessoaId, 
	                           nome_pessoa Nome, 
	                           cidade Cidade, 
	                           email Email, 
	                           cep CEP, 
	                           endereco Endereco,
	                           pais Pais,
	                           usuario Usuario,
	                           telefone Telefone,
	                           data_nascimento DataNascimento,
	                           cargo_id CargoId
                        FROM pessoa
                        WHERE pessoa_id = @PessoaId";

            var parametros = new DynamicParameters();
            parametros.Add("@PessoaId", pessoaId);
            var pessoa = await _connection.QueryFirstOrDefaultAsync<Pessoa>(sql, parametros);

            return pessoa;
        }

        public async Task<Pessoa> Obter(string usuario)
        {
            var sql = @"SELECT pessoa_id PessoaId, 
	                           nome_pessoa Nome, 
	                           cidade Cidade, 
	                           email Email, 
	                           cep CEP, 
	                           endereco Endereco,
	                           pais Pais,
	                           usuario Usuario,
	                           telefone Telefone,
	                           data_nascimento DataNascimento,
	                           cargo_id CargoId
                        FROM pessoa
                        WHERE usuario = @Usuario";

            var parametros = new DynamicParameters();
            parametros.Add("@Usuario", usuario);
            var pessoa = await _connection.QueryFirstOrDefaultAsync<Pessoa>(sql, parametros);

            return pessoa;
        }


        public async Task<bool> Atualizar(Pessoa pessoa)
        {
            var sql = @"update pessoa
                        set nome_pessoa = @Nome,
	                        cidade = @Cidade,
	                        email = @Email,
	                        cep = @Cep,
	                        endereco = @Endereco,
	                        pais = @Pais,
	                        telefone = @Telefone,
	                        data_nascimento = @DataNascimento,
	                        cargo_id = @CargoId
                        where pessoa_id = @PessoaId";

            var parametros = new DynamicParameters();
            parametros.Add("@PessoaId", pessoa.PessoaId);
            parametros.Add("@Nome", pessoa.Nome);
            parametros.Add("@Cidade", pessoa.Cidade);
            parametros.Add("@Cep", pessoa.Cep);
            parametros.Add("@Endereco", pessoa.Endereco);
            parametros.Add("@Pais", pessoa.Pais);
            parametros.Add("@Email", pessoa.Email);
            parametros.Add("@Telefone", pessoa.Telefone);
            parametros.Add("@DataNascimento", pessoa.DataNascimento);
            parametros.Add("@CargoId", pessoa.CargoId);

            var update = await _connection.ExecuteAsync(sql, parametros) > 0;

            return update;
        }

        public async Task<bool> Inserir(Pessoa pessoa)
        {
            var sql = @"INSERT pessoa
                        (nome_pessoa, cidade, email, cep, endereco, pais, telefone, data_nascimento, cargo_id, usuario)
                        VALUES
                        (@Nome, @Cidade, @Email, @Cep, @Endereco, @Pais, @Telefone, @DataNascimento, @CargoId, @Usuario)";

            var parametros = new DynamicParameters();
            parametros.Add("@Nome", pessoa.Nome);
            parametros.Add("@Cidade", pessoa.Cidade);
            parametros.Add("@Cep", pessoa.Cep);
            parametros.Add("@Endereco", pessoa.Endereco);
            parametros.Add("@Pais", pessoa.Pais);
            parametros.Add("@Email", pessoa.Email);
            parametros.Add("@Telefone", pessoa.Telefone);
            parametros.Add("@DataNascimento", pessoa.DataNascimento);
            parametros.Add("@CargoId", pessoa.CargoId);
            parametros.Add("@Usuario", pessoa.Usuario);

            var insert = await _connection.ExecuteAsync(sql, parametros) > 0;

            return insert;
        }

    }
}

