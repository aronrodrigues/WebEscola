using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEscola.Models;

namespace WebEscola.Controllers
{
    public class AlunoController : Controller
    {
        private static Dictionary<Int32, Aluno> dados = new Dictionary<Int32, Aluno>() {
            { 1111, new Aluno() { ID = 1111, Nome = "Aron Rodrigues" } },
            { 2222, new Aluno() { ID = 2222, Nome = "Angelina Jolie" } }
        };

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.quantidade = dados.Count;
            return View(dados.Values);
        }

        [HttpGet]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (aluno != null && !dados.ContainsKey(aluno.ID))
                {
                    dados[aluno.ID] = aluno;
                    TempData["ListMessage"] = "Novo aluno salvo com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Matrícula já existente.");
                    return View();
                }

            }
            else 
            {
                return View(aluno);
            }

            
        }

        [HttpGet]
        public ActionResult Editar(Int32 ID)
        {
            if (dados.ContainsKey(ID))
            {
                return View(dados[ID]);
            } else {
                return HttpNotFound();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (aluno != null && dados.ContainsKey(aluno.ID))
                {
                    dados[aluno.ID] = aluno;
                    TempData["ListMessage"] = "Alterações do aluno foram salvas com sucesso.";
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(aluno);
            }
        }

        [HttpGet]
        public ActionResult Excluir(Int32 ID)
        {
            if (dados.ContainsKey(ID))
            {
                dados.Remove(ID);
                TempData["ListMessage"] = "Aluno excluído com sucesso.";
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult JsonData()
        {
            return Json(dados.Values, JsonRequestBehavior.AllowGet);
        }
    }
}