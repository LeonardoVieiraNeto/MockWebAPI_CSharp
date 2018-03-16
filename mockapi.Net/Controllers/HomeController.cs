using mockapi.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace mockapi.Net.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Alunos()
        //{
        //    ViewBag.Message = "Alunos retornados pelo MockAPI.";
        //    IList<Aluno> model = new List<Aluno>();
            
        //    using (var client = new WebClient())
        //    {
        //        var jsonReturnMockAPIAlunos = client.DownloadString(_endpointMockApiAlunos);
        //        model = new JavaScriptSerializer().Deserialize<IList<Aluno>>(jsonReturnMockAPIAlunos);
        //    }

        //    return View(model);
        //}

        //public ActionResult Cursos()
        //{
        //    ViewBag.Message = "Lista de cursos retornados pelo MockAPI.";
        //    List<Curso> model = new List<Curso>();

        //    using (var client = new WebClient())
        //    {
        //        var jsonReturnMockAPICursos = client.DownloadString(_endpointMockApiCursos);
        //        model = new JavaScriptSerializer().Deserialize<List<Curso>>(jsonReturnMockAPICursos);
        //    }

        //    return View(model);
        //}

        //public ActionResult FormularioAddAluno()
        //{
        //    Aluno model = new Aluno();
            
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult SaveAluno(Aluno aluno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            string json = new JavaScriptSerializer().Serialize(aluno);
        //            client.BaseAddress = new Uri(_endpointMockApiAlunos);
        //            var content = new StringContent(json, Encoding.UTF8, "application/json");
        //            var result = client.PostAsync(_endpointMockApiAlunos, content).Result;
        //            Task<string> resultContent = result.Content.ReadAsStringAsync();
        //            var codigoRetorno = (int)result.StatusCode;
        //            var JsonRetorno = resultContent.Result;

        //            //Redireciona para a listagem de alunos 
        //            return RedirectToRoute(new { contoller = "Home", action = "Alunos" });
        //        }
        //    }

        //    return View("FormularioAddAluno", aluno);
        //}
    }
}