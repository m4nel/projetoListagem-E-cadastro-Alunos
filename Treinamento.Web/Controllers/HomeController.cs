using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Treinamento.Web.Models;

namespace Treinamento.Web.Controllers
{
    public class HomeController : BaseController
    {
        private static List<Entidade> Entidades { get; set; } = new List<Entidade>();

        public HomeController()
        {
            var objeto = new Entidade
            {
                Id = 1,
                Nome = "Fulano",
                Sobrenome = "da Silva"
            };

            Entidades.Add(objeto);
        }

        public ActionResult Index()
        {
            var entidade = Entidades.First();
            return View(entidade);
        }
    }
}