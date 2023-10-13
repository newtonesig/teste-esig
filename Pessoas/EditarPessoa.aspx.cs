using System;
using System.Web.UI;
using TesteEsig.Model;
using TesteEsig.Repository;

namespace TesteEsig
{
    public partial class EditarPessoa : Page
    {
        private PessoaRepository _pessoaRepository { get; set; }
        private CargoRepository _cargoRepository { get; set; }

        public EditarPessoa()
        {
            _pessoaRepository = new PessoaRepository();
            _cargoRepository = new CargoRepository();
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            divSucesso.Visible = false;
            divErro.Visible = false;

            if (!IsPostBack)
            {
                var pessoaId = Convert.ToInt32(Request.QueryString["id"]);

                if (pessoaId != 0)
                {                   
                    var pessoa = await _pessoaRepository.Obter(pessoaId);

                    txbId.Text = pessoa.PessoaId.ToString();
                    txbNome.Text = pessoa.Nome;
                    txbCidade.Text = pessoa.Cidade;
                    txbEmail.Text = pessoa.Email;
                    txbCep.Text = pessoa.Cep;
                    txbEndereco.Text = pessoa.Endereco;
                    txbPais.Text = pessoa.Pais;
                    txbTelefone.Text = pessoa.Telefone;
                    txbDataNascimento.Text = pessoa.DataNascimento.ToString("yyyy-MM-dd");

                    ddlCargo.DataSource = await _cargoRepository.ObterTodos();
                    ddlCargo.DataTextField = "Nome";
                    ddlCargo.DataValueField = "CargoId";
                    ddlCargo.SelectedValue = pessoa.CargoId.ToString();
                    ddlCargo.DataBind();

                }
                else
                {
                    Response.Redirect("~/Pessoas/ListagemPessoas.aspx", false);
                }
            }
        }

        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            var pessoa = new Pessoa()
            {
                PessoaId = Convert.ToInt32(txbId.Text),
                Nome = txbNome.Text,
                Cidade = txbCidade.Text,
                Email = txbEmail.Text,
                Cep = txbCep.Text,
                Endereco = txbEndereco.Text,
                Pais = txbPais.Text,
                Telefone = txbTelefone.Text,
                DataNascimento = Convert.ToDateTime(txbDataNascimento.Text),
                CargoId = Convert.ToInt32(ddlCargo.SelectedValue)
            };

            var sucesso = await _pessoaRepository.Atualizar(pessoa);
            divSucesso.Visible = sucesso;
            divErro.Visible = !sucesso;
        }

    }
}