<%@ Page Async="true" Title="Editar Pessoa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserirPessoa.aspx.cs" Inherits="TesteEsig.InserirPessoa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">        
    <h2 class="mb-3 text-muted">Cadastrar Pessoa</h2>
        <div class="row">
            <div class="col-md-8">
                <label class="mb-2 text-muted" for="txbNome">Nome</label>
                <asp:TextBox ID="txbNome" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valNome" runat="server" ErrorMessage="Nome é obrigatorio" ControlToValidate="txbNome" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-4">
                <label class="mb-2 text-muted" for="txbDataNascimento">Data De Nascimento</label>
                <asp:TextBox ID="txbDataNascimento" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDataNascimento" runat="server" ErrorMessage="Data de nascimento é obrigatorio" ControlToValidate="txbDataNascimento" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

        </div>

        <div class="row">
            <div class="col-md-6">
                <label class="mb-2 text-muted" for="txbLogin">Login</label>
                <asp:TextBox ID="txbLogin" CssClass="form-control" runat="server"></asp:TextBox>
                <span class="text-danger">
                    <asp:Literal ID="spanErrorLogin" runat="server" /></span>
                <div class="row">
                </div>
            </div>

            <div class="col-md-6">
                <label class="mb-2 text-muted" for="txbSenha">Senha</label>
                <asp:TextBox ID="txbSenha" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valSenha" runat="server" ErrorMessage="Senha é obrigatorio" ControlToValidate="txbSenha" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">

            <div class="col-md-4">
                <label class="mb-2 text-muted" for="ddlCargo">Cargo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCargo" />
                <asp:RequiredFieldValidator ErrorMessage="Cargo é obrigatorio" ControlToValidate="ddlCargo" InitialValue="" runat="server" ForeColor="Red" />
            </div>

            <div class="col-md-6">
                <label class="mb-2 text-muted" for="txbEmail">E-mail</label>
                <asp:TextBox ID="txbEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
            </div>

            <div class="col-md-2">
                <label class="mb-2 text-muted" for="txbTelefone">Telefone</label>
                <asp:TextBox ID="txbTelefone" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>

        </div>

        <div class="row">

            <div class="col-md-3">
                <label class="mb-2 text-muted" for="txEmail">CEP</label>
                <asp:TextBox ID="txbCep" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <label class="mb-2 text-muted" for="txbCidade">Cidade</label>
                <asp:TextBox ID="txbCidade" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <label class="mb-2 text-muted" for="txbEndereco">Endereço</label>
                <asp:TextBox ID="txbEndereco" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <label class="mb-2 text-muted" for="txbPais">Pais</label>
                <asp:TextBox ID="txbPais" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row" style="margin-top: 10px;">
            <div class="col-md-2">
                <asp:Button CssClass="btn btn-primary mb-4" ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />

                <a class="btn btn-secondary mb-4" href="javascript:history.back()">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
