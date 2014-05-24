var viewModel = new kendo.data.ObservableObject({
    ListaUsuarios: new Array(),
    Colunista: {},
    Salvar: Salvar

});

// função responsagem de pegar objeto da viewModel, e enviar para o servidor,
//  tb é feito uma validação para ver se os campos de usuario estão preenchidos (ID, e Nome)
function Salvar() {
    if (viewModel.get("Colunista.UsuarioId") !== null && viewModel.get("Colunista.UsuarioId") !== "") {
      Modulo.Colunista.Salvar(viewModel.get("Colunista.UsuarioId"),
            function (sucesso) {
                if (sucesso) {
                    toastr.success("Colunista Cadastrado com sucesso");
                    setTimeout(function () {
                        location.reload();

                    }, 1000);
                } else {
                    toastr.error("Erro ao cadastrar um colunista");
                }

            },
            function (error) {
                toastr.error("Erro ao cadastrar um colunista");

            }
            )
    }
    
}

$(document).ready(function () {


    //METODO PARA RETORNAR OS USUARIOS
   // ESTE METODO UTILIZA O AJAX DO JQUERY PARA COMUNICAR, EO RETORNO (sucesso) É ADICIONADO NA VIEWMODEL, QUE VAI CARREGAR O AUTOCOMPLETE
    Modulo.Usuario.Geral(
        function (sucesso) {
            if (!Utilidades.ChecarNulo(sucesso)) {
                viewModel.set("ListaUsuarios", sucesso.Usuarios);
        
                //METODO PARA INICIALIZAR O AUTOCOMPLETE, NO QUAL PEGA 1 ID HTML ("#Usuarios") E ADICIONA OS ATRIBUTOS A ELE
                $("#Usuarios").kendoAutoComplete({
                    dataTextField: "Nome",
                    dataSource: viewModel.get("ListaUsuarios"),
                    filter: "contains",
                    placeholder: "Busque um usuario",
                    select: function (data) {
                        //CASO UM USUARIO SEJA SELECIONADO, ADICIONA ESSE OBJETO SELECIONADO NA VIEWMODEL, AGORA EU SEI QUEM É O USUARIO SELECIONADO
                        //PARA TRANSFORMAR EM COLUNISTA
                        viewModel.set("Colunista", data.sender.dataItem(data.item.index()));
                    }
                });

            }
        },
        function (error) {
            toastr.error("Ocorreu um erro ao retornar os usuários");
        }
    );

    
   


    //METODO PARA INTERLIGAR UMA ESTRUTURA HTML COM UMA ESTRUTURA JAVASCRIPT
    kendo.bind($("#Content"), viewModel);


})