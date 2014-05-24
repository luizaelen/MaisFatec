<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administrador.aspx.cs" Inherits="Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="grvUsuario" runat="server" AutoGenerateColumns="False" AllowPaging="True" EnableModelValidation="True" OnPageIndexChanging="grdItens_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="usu_id" HeaderText="ID" />
            <asp:BoundField DataField="perf_nome" HeaderText="Nome" />
            <asp:BoundField DataField="perm_administrador" HeaderText="Administrador" />
            <asp:CheckBoxField DataField="perm_administrador" HeaderText="Administrador" />
        </Columns>
        <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
            PreviousPageText=">>"
            NextPageText="<img src='imagens/seta-direita.png' border='0' title='Próxima Página'/>"
            FirstPageText="<img src='imagens/seta-esquerda-ultima.png' border='0' title='Primeira Página'/>"
            LastPageText="<img src='imagens/seta-direita-ultima.png' border='0' title='Última Página'/>" PageButtonCount="2" />
    </asp:GridView>

</asp:Content>

