$(document).ready(function () {
    var usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));
    if (usuario.Perfil.PerfilId == 1)
        document.getElementById("adm_colunista").style.display = "block";
    if (usuario.Perfil.PerfilId == 2)
        document.getElementById("cadastrar_temas").style.display = "none";
    if (usuario.Perfil.Perfil == 2)
        document.getElementById("AddColunista").style.display = "none";
})