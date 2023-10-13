using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TesteEsig.Model;
using TesteEsig.Repository;

namespace TesteEsig
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected async void btnEntrar_Click(object sender, EventArgs e)
        {
            var login = txbLogin.Text.ToUpper();
            var senha = MD5Hash(txbSenha.Text);

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {
                spanError.Text = "Login e senha são obrigatorios";
            }
            else
            {
                var usuarioRepository = new UsuarioRepository();
                var usuario = await usuarioRepository.Obter(login);

                if(usuario.Login == null)
                {
                    spanError.Text = "Usuário não encontrado";
                }
                else
                {
                    if (login == usuario.Login.ToUpper() && senha == usuario.Senha)
                    {
                        Session["id"] = usuario.PessoaId;
                        Session["login"] = usuario.Login;
                        Response.Redirect("~/Default.aspx", false);
                    }
                    else
                    {
                        spanError.Text = "Login ou senha incorretos!";
                    }
                }

            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString().ToUpper();
        }
    }
}