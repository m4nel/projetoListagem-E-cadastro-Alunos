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

        private static Aluno Aluno { get; set; } = new Aluno();

        public ExercicioController()
        {
         
        }

        public ActionResult Index()
        {
            return View(Alunos);
        }        
        public ActionResult PaginaDetalhamento()
        {
            return View(Aluno);
        }

        [HttpGet]
        public JsonResult Detalhamento(int? alunoId)
        {
            var json = new JsonResponse();

            var aluno = Alunos.FirstOrDefault(batata => batata.Id == alunoId);

            if (aluno == null)
            {
                json.Sucesso = false;
                json.Mensagens.Add("id de Aluno invalido");
                return Json(json);
            }

            var alunoHtml = RenderRazorViewToString("~/Views/Exercicio/PaginaDetalhamento.cshtml", aluno, false);

            Aluno = aluno;

            json.Objeto = alunoHtml;
            json.Sucesso = true;
            json.Mensagens.Add("aluno passado para pagina");

            return Json(json, JsonRequestBehavior.AllowGet);
        }

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

            json.Objeto = Alunos;
            json.Sucesso = true;
            json.Mensagens.Add("Aluno Inserido com sucesso!");

            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}