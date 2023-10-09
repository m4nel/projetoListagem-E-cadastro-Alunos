/*
 * Define o namespace para objetos e fun��es JavaScript da tela Home.
 */
Europa.Controllers.Exercicio = {};

function AbrirModal() {
    $("#meuModal").modal("show");
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
            location.reload();
            fecharModal();
        },

        error: function (error) {

            alert(error, "N�o foi possivel Cadastrar")
        }
    });

};


function PaginaDetalhamento(alunoId) {

    Europa.Controllers.Exercicio.PaginaDetalhamento(alunoId); 

}
Europa.Controllers.Exercicio.PaginaDetalhamento = function (alunoId) {

    $.get(Europa.Controllers.Exercicio.UrlDetalhamento, { alunoId }, function (res) {
        $("#form-aluno").html(res.Objeto);
    })
} 
