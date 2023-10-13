using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Configuration;
using TesteEsig.Model;

namespace TesteEsig.Repository
{
    public class CargoRepository
    {
        private readonly IDbConnection _connection;
        public CargoRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["esigConnectionString"].ConnectionString);
        }
        public async Task<IEnumerable<Cargo>> ObterTodos()
        {
            var sql = _selectBase + "ORDER BY nome_cargo";
            var cargos = await _connection.QueryAsync<Cargo>(sql);

            return cargos;
        }

        public async Task<Cargo> Obter(int cargoId)
        {
            var sql = _selectBase + "WHERE cargo_id = @CargoId";

            var parametros = new DynamicParameters();
            parametros.Add("@CargoId", cargoId);

            var cargo = await _connection.QueryFirstOrDefaultAsync<Cargo>(sql, parametros);

            return cargo;
        }

        private readonly string _selectBase = @"SELECT cargo_id CargoId,
	                                                   nome_cargo Nome
                                                FROM cargo ";
    }
}