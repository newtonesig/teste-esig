using CrystalDecisions.Web;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsig.Model;
using TesteEsig.Repository;

namespace TesteEsig
{
    public partial class InserirPessoa : Page
    {
        private PessoaRepository _pessoaRepository { get; set; }
        private CargoRepository _cargoRepository { get; set; }
        private UsuarioRepository _usuarioRepository { get; set; }

        public InserirPessoa()
        {
            _pessoaRepository = new PessoaRepository();
            _cargoRepository = new CargoRepository();
            _usuarioRepository = new UsuarioRepository();
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if(ddlCargo.Items.Count == 0)
            {
                ddlCargo.DataSource = await _cargoRepository.ObterTodos();
                ddlCargo.DataTextField = "Nome";
                ddlCargo.DataValueField = "CargoId";
                ddlCargo.DataBind();
                ddlCargo.Items.Insert(0, "");
                ddlCargo.SelectedIndex = 0;
            }
        }


        protected async void btnSalvar_Click(object sender, EventArgs e)
        {
            spanErrorLogin.Text = "";

            if (txbLogin.Text.Trim() == "")
            {
                spanErrorLogin.Text = "Login é obrigatório";
            }
            else
            {
                var loginJaExiste = await _usuarioRepository.Obter(txbLogin.Text) != null;

                if (loginJaExiste)
                {
                    spanErrorLogin.Text = "Login já existente";
                }
                else
                {
                    var pessoa = new Pessoa()
                    {
                        Nome = txbNome.Text,
                        Cidade = txbCidade.Text,
                        Email = txbEmail.Text,
                        Cep = txbCep.Text,
                        Endereco = txbEndereco.Text,
                        Pais = txbPais.Text,
                        Telefone = txbTelefone.Text,
                        Usuario = txbLogin.Text,
                        DataNascimento = Convert.ToDateTime(txbDataNascimento.Text),
                        CargoId = Convert.ToInt32(ddlCargo.SelectedValue)
                    };

                    await _pessoaRepository.Inserir(pessoa);
                    pessoa = await _pessoaRepository.Obter(pessoa.Usuario);

                    var usuario = new Usuario()
                    {
                        PessoaId = pessoa.PessoaId,
                        Login = txbLogin.Text,
                        Senha = txbSenha.Text
                    };

                    await _usuarioRepository.Inserir(usuario);

                    Response.Redirect("~/Pessoas/ListagemPessoas.aspx?salvo=true", false);

                }
            }
            
        }

    }
}