$(document).ready(function () {
    $(".btn-danger").click(function (e) {
        var result = confirm("Tem certeza que deseja excluir essa categoria?");
        if (!result) {
            e.preventDefault();
        }
    });
});