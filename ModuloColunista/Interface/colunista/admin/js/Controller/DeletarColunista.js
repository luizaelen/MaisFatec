var viewModel = new kendo.data.ObservableObject({
    ListaColunistas: new Array(),
    Colunista: {},
    Salvar: Salvar

});

//FUNCAO PARA ENVIAR O ID DO COLUNISTA AO SERVIDOR UTILIZANDO AJAX
function Salvar() {
    if (viewModel.get("Colunista.UsuarioId") !== null) {
   
        Modulo.Colunista.Deletar(viewModel.get("Colunista.UsuarioId"),
            function (sucesso) {
                if(sucesso){
                toastr.success("Colunista excluido com sucesso");
                setTimeout(function () {
                    location.reload();

                }, 1000);
                } else {
                    toastr.error("Erro ao excluir colunista");
                }

            },
            function (error) {
                toastr.error("Erro ao excluir um colunista");

            }
            )
    }

}

$(document).ready(function () {


    //METODO PARA RETORNAR TODOS OS COLUNISTAS E ADICIONAR O RETORNO(SUCESSO) NA VIEWMODEL PARA CARREGAR O AUTOCOMPLETE
    Modulo.Colunista.Geral(2,
        function (sucesso) {
            if (!Utilidades.ChecarNulo(sucesso)) {
                viewModel.set("ListaColunistas", sucesso.Usuarios);
         

            }

            //METODO PARA INICIALIZAR O AUTOCOMPLETE DE COLUNISTAS
            $("#Colunistas").kendoAutoComplete({
                dataTextField: "Nome",
                dataSource: viewModel.get("ListaColunistas"),
                filter: "startswith",
                placeholder: "Busque um colunista",
                select: function (data) {
                    viewModel.set("Colunista", data.sender.dataItem(data.item.index()));
                }
            });

        },
        function (error) {
            toastr.error("Ocorreu um erro ao retornar os colunistas");
        }
    )

   
    //METODO PARA INTERLIGAR UMA ESTRUTURA HTML COM UMA ESTRUTURA JAVASCRIPT
    kendo.bind($("#Content"), viewModel);


})