using ExemploValidacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.ObjectModel;

namespace ExemploValidacao.Controllers
{
    public class PessoaController : Controller
    {
        
        public ActionResult Index()
        {
            var pessoa = new Pessoa();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Pessoa pessoa) 
        {
            //if(string.IsNullOrEmpty(pessoa.Nome))
            //{
            //    ModelState.AddModelError("Nome","O campo nome é obrigatório");
            //}
            //if(pessoa.Senha != pessoa.ConfirmarSenha)
            //{
            //    ModelState.AddModelError("","As senha não conferem");
            //}

            if(ModelState.IsValid)
            {
                return View("Resultado" , pessoa);
            }

            return View(pessoa);
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string login) 
        {
            var bancoDeNomesDeExemplo= new Collection<string>
            {
                "Cleyton",
                "Anderson",
                "Thiago",
                "Renata"
            };
            return Json(bancoDeNomesDeExemplo.All(x=>x.ToLower() != login.ToLower()),JsonRequestBehavior.AllowGet);
        }

    }
}
