using mockapi.Net.Models;
using Newtonsoft.Json;
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
    public class AlunoController : Controller
    {
        private string _endpointMockApiAlunos = WebConfigurationManager.AppSettings["endpointMockApiAlunos"].ToString();

        // GET: Aluno
        public ActionResult Index()
        {
            ViewBag.Message = "Alunos retornados pelo MockAPI.";
            IList<Aluno> model = new List<Aluno>();

            using (var client = new WebClient())
            {
                var jsonReturnMockAPIAlunos = client.DownloadString(_endpointMockApiAlunos);
                model = new JavaScriptSerializer().Deserialize<IList<Aluno>>(jsonReturnMockAPIAlunos);
            }

            return View(model);
        }

        public ActionResult FormularioAddAluno()
        {
            Aluno model = new Aluno();

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveAluno(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    aluno.Id = GerarIdRandomico();
                    string json = new JavaScriptSerializer().Serialize(aluno);
                    client.BaseAddress = new Uri(_endpointMockApiAlunos);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(_endpointMockApiAlunos, content).Result;
                    Task<string> resultContent = result.Content.ReadAsStringAsync();
                    var codigoRetorno = (int)result.StatusCode;
                    var JsonRetorno = resultContent.Result;

                    //Redireciona para a listagem de alunos 
                    return RedirectToRoute(new { contoller = "Aluno", action = "Index" });
                }
            }

            return View("FormularioAddAluno", aluno);
        }

        private int GerarIdRandomico()
        {
            Random r = new Random();
            return r.Next(1, 100);
        }

        public ActionResult Deletar(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(string.Format(_endpointMockApiAlunos + "/{0}", id)).Result;
                
                //Redireciona para a listagem de alunos 
                return RedirectToRoute(new { contoller = "Aluno", action = "Index" });
            }
        }
    }
}