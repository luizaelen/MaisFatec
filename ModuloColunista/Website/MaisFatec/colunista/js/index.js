var viewModel = new kendo.data.ObservableObject({
ListaPostagem : new Array(),

})
var DataSourcePostagem;
var Colunistas;
var wnd;

function filtrar(valor) {
    var base = viewModel.get("ListaPostagem");
    var dataSourceFiltro = new kendo.data.DataSource({
        data: base,
        filter: { field: "Titulo", operator: "contains", value: valor },
        sort: [{ field: "Titulo", dir: "asc" }]
    });
    dataSourceFiltro.fetch(function () {
        var view = dataSourceFiltro.view();
        DataSourcePostagem.data(view);
    });

    $("#pagerPostagem").data("kendoPager").dataSource.page(1);


}
$(document).ready(function(){
    var chave = localStorage.getItem("Chave");

    setTimeout(function(){
        $.ajax({
            url: 'https://api.everlive.com/v1/eA9DgzMTcA6Adsgo/Colunista',
            type: "GET",
            headers: {"Authorization" : "Bearer "+ chave},
            success: function(data){
              var  dataSource = new kendo.data.DataSource({
                    data: data.Result,
                    pageSize: 4
                });

                $("#pager").kendoPager({
                    dataSource: dataSource
                });

                $("#listView").kendoListView({
                    dataSource: dataSource,
                    template: kendo.template($("#template").html())
                });

            },
            error: function(error){
                alert(JSON.stringify(error));
            }
        });

    }, 100);

    setTimeout(function(){
        $.ajax({
            url: 'https://api.everlive.com/v1/eA9DgzMTcA6Adsgo/Tema',
            type: "GET",
            headers: {"Authorization" : "Bearer "+ chave},
            success: function(data){
                var  dataSource = new kendo.data.DataSource({
                    data: data.Result,
                    pageSize: 4
                });

                Colunistas = $("#menu_temas").kendoListView({
                    dataSource: dataSource,
					selectable: true,
					change: function(e){
						 var data = e.sender.dataSource.view();
						var selecionado =	$.map(e.sender.select(), function (item) {
							return data[$(item).index()];				
						});
						var postagens = viewModel.get("ListaPostagem");
						var newArray = new Array();
						for (var i = 0; i < postagens.length; i ++){
							if (postagens[i].Tema == selecionado[0].Id)
							{
								newArray.push(postagens[i]);
							}
						}
						DataSourcePostagem.data(newArray);
						//Colunistas.refresh();
					},
                    template: kendo.template($("#templateTema").html())
                });

            },
            error: function(error){
                alert(JSON.stringify(error));
            }
        });

    }, 100);

    setTimeout(function(){
        $.ajax({
            url: 'https://api.everlive.com/v1/eA9DgzMTcA6Adsgo/Postagem',
            type: "GET",
            headers: {"Authorization" : "Bearer "+ chave},
            success: function(data){
			viewModel.set("ListaPostagem", data.Result);
                  DataSourcePostagem = new kendo.data.DataSource({
                    data: data.Result,
                    pageSize: 5
                });
                $("#listPostagem").kendoListView({
                    dataSource: DataSourcePostagem,
                    selectable: true,
                    change: function (e){
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        wnd.title(selecionado[0].Titulo);
                        $("#window").html(selecionado[0].Conteudo);
                        //document.getElementById("window").innerHTML = selecionado[0].Conteudo;
                          wnd.open().center()
                
                       
                    },
                    template: kendo.template($("#templatePostagem").html())
                });
                $("#pagerPostagem").kendoPager({
                    dataSource: DataSourcePostagem
                });

            },
            error: function(error){
                alert(JSON.stringify(error));
            }
        });

    }, 100);

    wnd = $("#window").kendoWindow({
        modal: true,
        pinned: true,
        position: { top: 100 },
        visible: false,
        resizable: true,
        draggable: false,
        width: "40%",
        heigth: "80%"
    }).data("kendoWindow");
    wnd.element.scrollTop(0);
})