<%@ Page Async="true" Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TesteEsig.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <section class="h-100">
        <div class="container h-100">
            <div class="row justify-content-sm-center h-100">
                <div class="col-xxl-4 col-xl-5 col-lg-5 col-md-7 col-sm-9">
                    <div class="text-center my-5">
                        <img src="Images/esig.png" alt="logo" width="300" />
                    </div>
                    <div class="card shadow-lg">
                        <div class="card-body p-5">
                            <span class="text-danger">
                                <asp:Literal ID="spanError" runat="server" /></span>
                            <form runat="server">
                                <div class="mb-3">
                                    <label class="mb-2 text-muted" for="txbLogin">Login</label>
                                    <asp:TextBox ID="txbLogin" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label class="mb-2 text-muted" for="txbSenha">Senha</label>
                                    <asp:TextBox ID="txbSenha" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                </div>

                                <div class="d-grid gap-2">
                                    <asp:Button CssClass="btn btn-primary btn-block mb-4" ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</body>
</html>
