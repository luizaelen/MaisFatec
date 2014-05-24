<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contato.aspx.cs" Inherits="colunista_admin_publicacao_solicitar_tema_contato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../../css/estilo.css" rel="stylesheet" />
    <link href="../../css/estilo_lista_postagem.css" rel="stylesheet" />
    <link href="../../css/kendo.common.min.css" rel="stylesheet" />
    <link href="../../css/kendo.default.min.css" rel="stylesheet" />
    <link href="../../css/toastr.css" rel="stylesheet" />


    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 250px;
        }
        .auto-style2 {
        }
        .auto-style3 {
            width: 282px;
        }
        .auto-style5 {
            font-family: Verdana, Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #000;
            margin-left: 5px;
            height: 71px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style5" style="font-weight:bold; text-align:center;" colspan="2">Preencha as informações abaixo para enviar sua solicitação para cadastramento de Temas para o Administrador do Módulo Colunistas.</td>
            </tr>
            <tr>
                <td class="solicita_tema">Nome do colunista:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtNome" runat="server" class="k-textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="solicita_tema">E-mail:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server" class="k-textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="solicita_tema">Digite sua solicitação para cadastramento de tema:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtMensagem" runat="server" Height="77px" TextMode="MultiLine" Width="240px" class="k-textbox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <br />
                    <br />
                    <asp:Button ID="btnEnviar" class="k-button" runat="server" Text="Enviar Solicitação" OnClick="btnEnviar_Click" Width="143px" />
                    <br />
                    <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
