using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Treinamento.Web.Models;
using TreinamentoWeb.Models;

namespace Treinamento.Web.Controllers
{
    public class ExercicioController : BaseController
    {
        private static List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public ExercicioController()
        {
            var aluno = new Aluno
            {
                Id = 1,
                Nome = "Fulano",
                Sobrenome = "da Silva"
            };

            Alunos.Add(aluno);
        }

        public ActionResult Index()
        {
            var aluno = Alunos.First();
            return View();
        }
    }
}