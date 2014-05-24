<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Chat2.aspx.cs" Inherits="Chat2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblChat2" runat="server" Text=""></asp:Label>
    <asp:TextBox ID="txtChatNome" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtChatId" runat="server"></asp:TextBox>
    <asp:Button ID="btnChatTodos" runat="server" Text="Mostrar Usuários" OnClick="btnChatTodos_Click"/>

</asp:Content>

