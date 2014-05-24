<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Theme1/Style.css" rel="stylesheet" />
    <style type="text/css">
        .modalBackground {
            background: #cdcdcd;
            opacity: 0.8;
            top: 0px;
            left: 0px;
            position: absolute;
            z-index: 1;
        }

        .modalPopup {
            background-color: #FFF;
            padding: 3px;
            z-index: 10001;
        }
    </style>
    <script type="text/javascript">

        function mensagemErro(stringMensagem, Pagina) {
            alert(stringMensagem);
            location.href = Pagina;

        }

    </script>

</head>
<body style="width:1024px; margin:0 auto;">
    <form id="form1" runat="server">
    <div id="LoginTudo">

        <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>

        <div id="loginEsq">
            <asp:Image ID="imgLogin" runat="server" ImageUrl="~/img/imgblocoEsq.png"/>
        </div>
        <div id="loginDir">
            <div id="loginControle">
                <div id="login1">
                <asp:Login ID="Login1" runat="server" Width="235px" OnAuthenticate="Login1_Authenticate" BackColor="#E22122" Font-Names="Verdana" Font-Size="12px" ForeColor="#333333" LoginButtonText="Ok" PasswordLabelText="Senha:" TextLayout="TextOnTop" TitleText="Entrar no Sistema" UserNameLabelText="Nome de usuário:" Visible="true">
                    <CheckBoxStyle Font-Names="Verdana" Font-Size="12px" ForeColor="White" Height="50px" />
                    <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                    <LabelStyle Font-Names="Verdana" Font-Size="12px" ForeColor="White" Height="20px" HorizontalAlign="Left" />
                    <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" Font-Names="Verdana" Font-Size="12px" ForeColor="Black" Height="25px" Width="70px" />
                    <TextBoxStyle Font-Names="Verdana" Font-Size="12px" />
                    <TitleTextStyle Font-Bold="False" Font-Names="Verdana" Font-Size="14px" ForeColor="White" Height="100px" HorizontalAlign="Left" />
                    <ValidatorTextStyle Font-Names="Verdana" Font-Size="12px" />
                </asp:Login>

                    <div id="logCadastro" runat="server" visible="false">
                        E-mail: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Registro: <asp:TextBox ID="txtRegistro" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        RG: <asp:TextBox ID="txtRg" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Senha: <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        Confirmar Senha: <asp:TextBox ID="txtConfirmarSenha" runat="server"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>

                    </div>
                <div id="login2">
                    <asp:Button ID="btnCadastro" runat="server" Text="Cadastre-se" OnClick="btnCadastro_Click" />
                </div>
            </div>
            <div id="loginInfo">
                <div id="loginInfo1">Comunidade Colaborativa da Fatec Guaratinguetá</div>
                <div id="loginInfo2">Projeto dos Alunos do 5º Semestre do curso de Análise e Desenvolvimento de Sistemas.</div>
            </div>
            <div id="loginLinks">
                <div id="LinkSeparador">____________________________</div>
                <div id="LinkComoUtilizar">Como Utilizar?</div>
                <div id="LinkSobre">Sobre o +Fatec</div>
                <div id="LinkContato">Contato</div>
            </div>
            <div id="loginApoio"><img src="img/cps_gesp.png" /></div>
        </div>
    </div>
    </form>
</body>
</html>
