<%@ Page Async="true" Title="Editar Pessoa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPessoa.aspx.cs" Inherits="TesteEsig.EditarPessoa" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <svg xmlns="http://www.w3.org/2000/svg" style="display: none;">
        <symbol id="check-circle-fill" fill="currentColor" viewBox="0 0 16 16">
            <path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zm-3.97-3.03a.75.75 0 0 0-1.08.022L7.477 9.417 5.384 7.323a.75.75 0 0 0-1.06 1.06L6.97 11.03a.75.75 0 0 0 1.079-.02l3.992-4.99a.75.75 0 0 0-.01-1.05z" />
        </symbol>
        <symbol id="info-fill" fill="currentColor" viewBox="0 0 16 16">
            <path d="M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16zm.93-9.412-1 4.705c-.07.34.029.533.304.533.194 0 .487-.07.686-.246l-.088.416c-.287.346-.92.598-1.465.598-.703 0-1.002-.422-.808-1.319l.738-3.468c.064-.293.006-.399-.287-.47l-.451-.081.082-.381 2.29-.287zM8 5.5a1 1 0 1 1 0-2 1 1 0 0 1 0 2z" />
        </symbol>
        <symbol id="exclamation-triangle-fill" fill="currentColor" viewBox="0 0 16 16">
            <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />
        </symbol>
    </svg>

    <div class="container">

        <div class="alert alert-success alert-dismissible fade show d-flex  align-items-center" role="alert" runat="server" id="divSucesso">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Success:">
                <use xlink:href="#check-circle-fill" />
            </svg>
            <div>
                Pessoa Atualizada com sucesso!
                 <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        </div>

        <div class="alert alert-danger alert-dismissible fade show d-flex  align-items-center" role="alert" runat="server" id="divErro">
            <svg class="bi flex-shrink-0 me-2" width="24" height="24" role="img" aria-label="Warning:">
                <use xlink:href="#exclamation-triangle-fill" />
            </svg>
            <div>
                Falha ao atualizar Pessoa!
         <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        </div>

        <h2 class="mb-3 text-muted">Editar Pessoa</h2>
        <div class="row">

            <div class="col-md-2">
                <label class="mb-2 text-muted" for="txbId">ID</label>
                <asp:TextBox ID="txbId" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-8">
                <label class="mb-2 text-muted" for="txbNome">Nome</label>
                <asp:TextBox ID="txbNome" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valNome" runat="server" ErrorMessage="Nome é obrigatorio" ControlToValidate="txbNome" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-2">
                <label class="mb-2 text-muted" for="txbDataNascimento">Data De Nascimento</label>
                <asp:TextBox ID="txbDataNascimento" CssClass="form-control" runat="server" TextMode="date"></asp:TextBox>
            </div>

        </div>

        <div class="row">

            <div class="col-md-4">
                <label class="mb-2 text-muted" for="txbDataNascimento">Cargo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlCargo" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cargo é obrigatorio" ControlToValidate="ddlCargo" ForeColor="Red"></asp:RequiredFieldValidator>
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
