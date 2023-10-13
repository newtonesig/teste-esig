using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteEsig.Model;
using TesteEsig.Repository;

namespace TesteEsig
{
    public partial class ListagemPessoas : Page
    {
        private PessoaSalarioRepository _pessoaSalarioRepository { get; set; }

        public ListagemPessoas()
        {
            _pessoaSalarioRepository = new PessoaSalarioRepository();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var salvoComSucesso = Convert.ToBoolean(Request.QueryString["salvo"]);

            divSucesso.Visible = salvoComSucesso;
        }

        public async Task<SelectResult> tbListagemPessoas_ObterDados(int startRowIndex, int maximumRows)
        {
            var pessoasSalario = await _pessoaSalarioRepository.ObterTodos();
            return new SelectResult(pessoasSalario.Count(), pessoasSalario.Skip(startRowIndex).Take(maximumRows));
        }

        // O nome do parâmetro id deve corresponder ao valor DataKeyNames definido no controle
        public void tbListagemPessoas_Editar(object sender, CommandEventArgs e)
        {
            var parametro = e.CommandArgument;
            Response.Redirect("~/Pessoas/EditarPessoa.aspx?id="+parametro, false);
        }

        protected async void btnRelatorio_Click(object sender, EventArgs e)
        {
            var relatorio = new ReportDocument();
            relatorio.Load(Server.MapPath(@"~/Relatorios/RelatorioSalario.rpt"));

            var pessoas = await _pessoaSalarioRepository.ObterTodos();
            relatorio.SetDataSource(pessoas);

            CrystalReportViewer.ReportSource = relatorio;

            relatorio.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Relatorio de cargos");
        }

        protected void lbInserir_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("~/Pessoas/InserirPessoa.aspx", false);
        }
    }
}