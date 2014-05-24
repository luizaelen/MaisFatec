<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditarPerfil.aspx.cs" Inherits="EditarPerfil" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="perfilTudo">
        <div style="text-align: center">
            <asp:Label ID="lblDadosPessoais" runat="server" Text="Dados Pessoais"></asp:Label>
            <br />
            <br />
        </div>
        <div id="editarPerfilConteudo">
            <div id="perfilDadosPessoaisP" class="perfilItens" style="float: left; width: 1024px;">
                <div id="dadosPessoaisEsq" style="float: left; margin-left:20px; margin-top:20px; margin-bottom:20px;">
                    <div>
                        <div class="edtPerfilLinha">
                            Nome:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfNome" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />                    
                    <div>
                        <div class="edtPerfilLinha">
                            Sobrenome:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfSobrenome" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Data de Nascimento:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfDtNasc" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Sexo:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:DropDownList ID="ddlEdtPerfSexo" runat="server">
                                <asp:ListItem>Masculino</asp:ListItem>
                                <asp:ListItem>Feminino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Cidade Natal:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfCidadeNatal" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Cidade Atual:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfCidadeAtual" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <br /><br />
                    <div>
                        <div class="edtPerfilLinha">
                            Relacionamento:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:DropDownList ID="ddlEdtPerfRelacionamento" runat="server">
                                <asp:ListItem>Solteiro</asp:ListItem>
                                <asp:ListItem>Namorando</asp:ListItem>
                                <asp:ListItem>Noivo</asp:ListItem>
                                <asp:ListItem>Casado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br /><br />
                    <div style="margin-bottom:100px;">
                        <div class="edtPerfilLinha">
                            Sobre você:
                        </div>
                        <div class="edtPerfilTxt">
                            <asp:TextBox ID="txtEdtPerfSobreVoce" runat="server" Height="75px" TextMode="MultiLine" Width="395px"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnEdtPerfSalvarDadosBasicos" runat="server" Text="Salvar" OnClick="btnEdtPerfSalvarDadosBasicos_Click" />
                </div>
                <div id="dadosPessoaisDir" style="float: right; margin-right: 20px; margin-top: 20px;">
                    <div style="margin-left:210px">
                        <asp:Image ID="imgPerfilUsuario" runat="server" Width="180px" Height="180px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"/>
                    </div>
                    <br />
                    <asp:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern" CompleteBackColor="White" UploadingBackColor="#CCFFFF" OnUploadedComplete="FileUploadComplete" />
                </div>
            </div>

            <div id="perfilDivHor1" class="perfilDivHor"></div>
            <asp:Label ID="lblInteresses" runat="server" Text="Interesses"></asp:Label>
            
            <div id="perfilInteressesP" class="perfilItens">
                <br />
                <table>
                    <tr>
                        <td colspan="2">O que você gosta de fazer para se distrair?</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td id="Lazer1" runat="server">
                            <asp:TextBox ID="txtLazer1" runat="server"></asp:TextBox><asp:ImageButton ID="ibtLazer1" runat="server" OnClick="ibtLazer1_Click" />
                            </td>                            
                        <td id="Lazer2" runat="server" visible="false">
                            <asp:TextBox ID="txtLazer2" runat="server"></asp:TextBox><asp:ImageButton ID="ibtLazer2" runat="server" OnClick="ibtLazer2_Click" />
                        </td>
                        <td id="Lazer3" runat="server" visible="false">
                            <asp:TextBox ID="txtLazer3" runat="server"></asp:TextBox><asp:ImageButton ID="ibtLazer3" runat="server" OnClick="ibtLazer3_Click" />
                        </td>
                        <td id="Lazer4" runat="server" visible="false">
                            <asp:TextBox ID="txtLazer4" runat="server"></asp:TextBox><asp:ImageButton ID="ibtLazer4" runat="server" OnClick="ibtLazer4_Click" />
                        </td>
                        <td id="Lazer5" runat="server" visible="false">
                            <asp:TextBox ID="txtLazer5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr>
                        <td colspan="2">Quais os seus livros prediletos?</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td id="edtPerfLivro1" runat="server">
                            <asp:TextBox ID="txtEdtPerfLivro1" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfLivro1" runat="server" OnClick="ibtEdtPerfLivro1_Click"/>
                        </td>                            
                        <td id="edtPerfLivro2" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfLivro2" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfLivro2" runat="server" OnClick="ibtEdtPerfLivro2_Click"/>
                        </td>
                        <td id="edtPerfLivro3" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfLivro3" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfLivro3" runat="server" OnClick="ibtEdtPerfLivro3_Click"/>
                        </td>
                        <td id="edtPerfLivro4" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfLivro4" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfLivro4" runat="server" OnClick="ibtEdtPerfLivro4_Click"/>
                        </td>
                        <td id="edtPerfLivro5" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfLivro5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr>
                        <td colspan="2">Que tipo de música gosta de ouvir?</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td id="edtPerfMusica1" runat="server">
                            <asp:TextBox ID="txtEdtPerfMusica1" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfMusica1" runat="server" OnClick="ibtEdtPerfMusica1_Click"/>
                        </td>                            
                        <td id="edtPerfMusica2" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfMusica2" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfMusica2" runat="server" OnClick="ibtEdtPerfMusica2_Click"/>
                        </td>
                        <td id="edtPerfMusica3" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfMusica3" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfMusica3" runat="server" OnClick="ibtEdtPerfMusica3_Click"/>
                        </td>
                        <td id="edtPerfMusica4" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfMusica4" runat="server"></asp:TextBox><asp:ImageButton ID="ibtEdtPerfMusica4" runat="server" OnClick="ibtEdtPerfMusica4_Click"/>
                        </td>
                        <td id="edtPerfMusica5" runat="server" visible="false">
                            <asp:TextBox ID="txtEdtPerfMusica5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                </table>
                <asp:Button ID="btnEdtPerfSalvarInteresses" runat="server" Text="Salvar" OnClick="btnEdtPerfSalvarInteresses_Click" />
            </div>

            <div id="edtPerfDivHor2" class="perfilDivHor"></div>

            <asp:Label ID="lblEdtPerfMiniCv" runat="server" Text="Mini CV"></asp:Label>
            <br />
            <br />
            <div id="edtPerfMiniCv" class="perfilItens">
                <br />
                <table>
                    <tr>
                        <td colspan="2">Você está fazendo algum curso de formação acadêmica?</td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="Tr1" runat="server">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="ttbCursandoNome" runat="server"></asp:TextBox></td>
                        <td>Instituição: </td>
                        <td>
                            <asp:TextBox ID="ttbCursandoInstituicao" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr>
                        <td colspan="2">Onde você trabalha?</td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="EmpregoAtual" runat="server">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtEmpregoAtualFuncao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtEmpregoAtualEmpresa" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr>
                        <td colspan="2">Onde você já trabalhou?</td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="ExpProf1" runat="server">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf1Funcao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf1Empresa" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ibtExpProf1" runat="server" OnClick="ibtExpProf1_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="ExpProf2" runat="server" visible="false">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf2Funcao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf2Empresa" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ibtExpProf2" runat="server" OnClick="ibtExpProf2_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="ExpProf3" runat="server" visible="false">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf3Funcao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf3Empresa" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ibtExpProf3" runat="server" OnClick="ibtExpProf3_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="ExpProf4" runat="server" visible="false">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf4Funcao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf4Empresa" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:ImageButton ID="ibtExpProf4" runat="server" OnClick="ibtExpProf4_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="ExpProf5" runat="server" visible="false">
                        <td>Função: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf5Funcao" runat="server"></asp:TextBox></td>
                        <td>Empresa: </td>
                        <td>
                            <asp:TextBox ID="txtExpProf5Empresa" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr>
                        <td colspan="2">Você tem cursos complementares?</td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="CurComp1" runat="server">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="txtCurComp1" runat="server"></asp:TextBox><asp:ImageButton ID="imbCurComp1" runat="server" OnClick="imbCurComp1_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="CurComp2" runat="server" visible="false">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="txtCurComp2" runat="server"></asp:TextBox><asp:ImageButton ID="imbCurComp2" runat="server" OnClick="imbCurComp2_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="CurComp3" runat="server" visible="false">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="txtCurComp3" runat="server"></asp:TextBox><asp:ImageButton ID="imbCurComp3" runat="server" OnClick="imbCurComp3_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="CurComp4" runat="server" visible="false">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="txtCurComp4" runat="server"></asp:TextBox><asp:ImageButton ID="imbCurComp4" runat="server" OnClick="imbCurComp4_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"><br /></td>
                    </tr>
                    <tr id="CurComp5" runat="server" visible="false">
                        <td>Curso: </td>
                        <td>
                            <asp:TextBox ID="txtCurComp5" runat="server"></asp:TextBox></td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</asp:Content>

