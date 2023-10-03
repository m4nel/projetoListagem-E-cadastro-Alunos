/*
 * Define o namespace para objetos e funções JavaScript da tela Home.
 */
Europa.Controllers.Exercicio = {};

function AbrirModal() {
    $("#meuModal").modal("show");
}

function abrirAbaDetalhamento() {

}

function SalvarModal() {
    Europa.Controllers.Exercicio.CadastrarAluno();
};

function fecharModal() {

    $("#meuModal").modal("hide");

}

Europa.Controllers.Exercicio.CadastrarAluno = function () {

    var obj = {
        Nome: $('#nomeModal').val(),
        Matricula: $('#matriculaModal').val(),
        Situacao: $('#situacaoModal').val(),
        CPFaluno: $('#cpfModal').val(),
        NomeMae: $('#nomeMaeModal').val(),
        Curso: $('#cursoModal').val(),
        DataNascimento: $('#dataNascimentoModal').val(),
        Observacoes: $('#obsModal').val(),
    };

    $.ajax({
        type: 'POST',
        url: Europa.Controllers.Exercicio.UrlCadastrarAluno,
        data: JSON.stringify(obj),
        contentType: 'application/json',

        success: function (result) {
            sucesso = true;
            /*location.reload();*/
            fecharModal();
            $("#listaAluno").html(result.Objeto);
        },

        error: function (error) {

            alert(error, "Não foi possivel Cadastrar")
        }
    });
};