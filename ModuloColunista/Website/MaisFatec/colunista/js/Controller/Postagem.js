var viewModel = new kendo.data.ObservableObject({
    Postagem: new Postagem(),
    TiposPostagens: TipoPostagem(),
    Salvar: Salvar

})
function Salvar() {
    viewModel.set("Postagem.DataPostagem", new Date());
    console.log( JSON.stringify(viewModel.get("Postagem")));
}

$(document).ready(function () {
    $("#editor").kendoEditor();

    kendo.bind($("#conteudo"), viewModel);
});
    
