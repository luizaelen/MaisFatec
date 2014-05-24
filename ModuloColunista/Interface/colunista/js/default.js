$(document).ready(function () {
    /**
     funcaoes para pegar os dados do cookie e tratar
    */
    //function OnLoad() {
    //    var userId = getCookie('UserdID');
    //    if (userId == null)
    //        window.location = "http://localhost:53566/Default.aspx";
    //}

    function deleteCookie(cookieName) {
        document.cookie = name +
        '=; expires=Thu, 01-Jan-70 00:00:01 GMT;';
    }

    function getCookie(cookieName) {
        var cookieValue = document.cookie;
        var cookieStart = cookieValue.indexOf(" " + cookieName + "=");
        if (cookieStart == -1) {
            cookieStart = cookieValue.indexOf("=");
        }
        if (cookieStart == -1) {
            cookieValue = null;
        }
        else {
            cookieStart = cookieValue.indexOf("=", cookieStart) + 1;
            var cookieEnd = cookieValue.indexOf(";", cookieStart);
            if (cookieEnd == -1) {
                cookieEnd = cookieValue.length;
            }
            cookieValue = unescape(cookieValue.substring(cookieStart, cookieEnd));
        }
        return cookieValue;
    }

    var url = "http://localhost:3716/Api/"
    $.ajax({
        url: url + "Postagem/ultimas",
        type: "GETS",
        success: function (data) {
            $("#ListaPostagens").kendoListView({
                dataSource: data,
                selectable: true,
                change: function (e) {
                    window.location.href = "Colunista.aspx";
                },
                template: kendo.template($("#templatePostagem").html())
            });

        },
        error: function (error) {
            alert(JSON.stringify(error));
        }

    });
    //aqui eu pego o id do perfil no cookie e busco o usuario na base na pagina html
    var userId = getCookie('UserdID');
    $.ajax({
        // aqui busco o usuario passando o id do perfil dele
        url: url + "usuario/" + userId,
        type: "GETS",
        success: function (data) {
            var x = data;
            x.Postagens = [];
            x.Comentarios = [];
            delete x.Perfil.Usuarios;

            console.log(JSON.stringify(data));
            //aqui eu gravo no localStorage o json do usuario logado encodado em base 64
            localStorage.setItem("Usuario", Utilidades.Encrypt(data));
            deleteCookie(userId);

        },
        error: function (error) {
            alert(JSON.stringify(error));
        }

    });



})
