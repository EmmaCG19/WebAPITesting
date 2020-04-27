using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSchool.Models;
using System.Net.Http;

namespace MVCSchool.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentVM model = new StudentVM();
            using (var cliente = new HttpClient())
            {
                //Debemos obtener todos los estudiantes y mostrarlos en una lista
                cliente.BaseAddress = new Uri("http://localhost:50022/api/");
                var request = cliente.GetAsync("students");
                request.Wait();

                var response = request.Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsAsync<List<StudentVM>>();
                    result.Wait();

                    model.Students = result.Result;
                }
            }

            ViewBag.Title = "MVC with WEB API";

            return View(model);
        }
    }
}