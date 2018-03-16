using mockapi.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace mockapi.Net.Controllers
{
    public class CursoController : Controller
    {
        private string _endpointMockApiCursos = WebConfigurationManager.AppSettings["endpointMockApiCursos"].ToString();

        // GET: Curso
        public ActionResult Index()
        {
            ViewBag.Message = "Lista de cursos retornados pelo MockAPI.";
            List<Curso> model = new List<Curso>();

            using (var client = new WebClient())
            {
                var jsonReturnMockAPICursos = client.DownloadString(_endpointMockApiCursos);
                model = new JavaScriptSerializer().Deserialize<List<Curso>>(jsonReturnMockAPICursos);
            }

            return View(model);
        }
    }
}