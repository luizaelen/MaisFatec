<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Perfil.aspx.cs" Inherits="Perfil" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="perfilTudo">
        <div id="perfilTopo">
            <asp:Image ID="imgPerfilCapa1" runat="server" CssClass="perfilCapa" Width="150px" Height="150px"/>
            <asp:Image ID="imgPerfilCapa2" runat="server" CssClass="perfilCapa" Width="150px" Height="150px" />
            <asp:Image ID="imgPerfilFoto" runat="server" CssClass="perfilFoto" Width="180px" Height="180px" ImageUrl="~/img/DSC01610.jpg" />
            <asp:Image ID="imgPerfilCapa3" runat="server" CssClass="perfilCapa" Width="150px" Height="150px" />
            <asp:Image ID="imgPerfilCapa4" runat="server" CssClass="perfilCapa" Width="150px" Height="150px" />
        </div>
        <div id="perfilNome">
            <asp:Label ID="lblPerfilNome" runat="server"></asp:Label>
        </div>
        <div id="perfilDivVert"></div>
        <div id="perfilConteudo">
            <asp:Label ID="lblDadosPessoais" runat="server" Text="Dados Pessoais"></asp:Label>
            <br /><br />
            <div id="perfilDadosPessoais" class="perfilItens">
                <br />
                Nasceu dia <asp:Label ID="lblDataNasc" runat="server" CssClass="perfilSubItens"></asp:Label> na cidade de <asp:Label ID="lblCidadeNasc" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Sexo <asp:Label ID="lblSexo" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Está <asp:Label ID="lblEstadoCivil" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Mora em <asp:Label ID="lblCidadeAtual" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
            </div>
            <div id="perfilDivHor1" class="perfilDivHor"></div>
            <asp:Label ID="lblInteresses" runat="server" Text="Interesses"></asp:Label>
            <br /><br />
            <div id="perfilInteresses" class="perfilItens">
                <br />
                Gosta de <asp:Label ID="lblHobbies" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Ouve <asp:Label ID="lblMusica" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Gostou de ler <asp:Label ID="lblLivros" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
            </div>
            <div id="perfilDivHor2" class="perfilDivHor"></div>
            <asp:Label ID="lblMiniCv" runat="server" Text="Mini CV"></asp:Label>
            <br /><br />
            <div id="perfilMiniCv" class="perfilItens">
                <br />
                Cursando <asp:Label ID="lblCurso" runat="server" CssClass="perfilSubItens"></asp:Label> na <asp:Label ID="lblInstituicaoEnsino" runat="server" Text="FATEC Guaratinguetá" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Trabalha na empresa <asp:Label ID="lblEmpregoAtual" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Já trabalhou nas empresas <asp:Label ID="lblEmpregosPassados" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
                Já fez curso de <asp:Label ID="lblCursos" runat="server" CssClass="perfilSubItens"></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>
</asp:Content>

