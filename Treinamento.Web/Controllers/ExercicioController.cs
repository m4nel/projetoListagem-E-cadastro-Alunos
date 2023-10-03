using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Treinamento.Web.Models;
using TreinamentoWeb.Enum;

namespace Treinamento.Web.Controllers
{
    public class ExercicioController : BaseController
    {
        private static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        private static int IncrementaId = 1;

        public ExercicioController()
        {
         
        }

        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult ListarAlunos()
        //{
        //    return JsonResult();
        //    // Listar Alunos na tela que foram adicionado a lista de Alunos -incompleto 
        //}

        [HttpPost]
        public JsonResult CadastrarAluno(Aluno aluno)
        {
            var json = new JsonResponse();

            if (aluno is null)
            {
                json.Sucesso = false;
                json.Mensagens.Add("Aluno Invalido não cadastrado");
                return Json(json, JsonRequestBehavior.AllowGet);
            }

            aluno.Id = IncrementaId++;
            Alunos.Add(aluno);

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/Index.cshtml", aluno, false);

            json.Objeto = alunoHtml;
            json.Sucesso = true;
            json.Mensagens.Add("Aluno Inserido com sucesso!");

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}