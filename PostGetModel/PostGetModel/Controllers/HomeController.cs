using PostGetModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostGetModel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var pessoa = new Pessoa
            {
                PessoaId = 1,
                Nome = "Thiago Henrique",
                Twitter = "Não tenho"
            };
            //ViewBag.PessoaID = pessoa.PessoaId;
            //ViewBag.Nome = pessoa.Nome;
            //ViewData["Twitter"] = pessoa.Twitter;
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Lista(Pessoa pessoa)
        {
           

            return View(pessoa);
        }

    }
}
