using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Task.Entity;

namespace Task.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _url = "http://localhost:56925/";
        public ActionResult Index()
        {
           var data =  GetStudentsAsync();
            return View(data);
        }
        public ActionResult SaveStudent()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Edit(int id)
        {
            var data = GetStudentsAsync();
            var student = data.Find(x => x.ID == id);
            EditStudentsAsync(student);
            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteStudentsAsync(id);

            return RedirectToAction("Index");
        }
        private List<Student> GetStudentsAsync()
        {
            List<Student> returnData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                //HTTP GET
                var responseTask = client.GetAsync("api/data").GetAwaiter().GetResult();

                if (responseTask.IsSuccessStatusCode)
                {
                    returnData = responseTask.Content.ReadAsAsync<List<Student>>().GetAwaiter().GetResult();
                }
                else //web api sent error response 
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                }
            }
            return returnData;
        }

        private void SaveStudentsAsync(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url+ "api/data");
                //HTTP GET
                var putTask = client.PutAsJsonAsync<Student>("data",student).GetAwaiter().GetResult();

                if (putTask.IsSuccessStatusCode)
                {
                    //var readTask = responseTask.Content.ReadAsAsync<IList<Student>>().GetAwaiter().GetResult();
                }
                else //web api sent error response 
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                }
            }
        }

        private Student EditStudentsAsync(Student student)
        {
            Student returnData = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                //HTTP GET
                var putTask = client.PutAsJsonAsync<Student>("data", student).GetAwaiter().GetResult();

                if (putTask.IsSuccessStatusCode)
                {
                    returnData = putTask.Content.ReadAsAsync<Student>().GetAwaiter().GetResult();
                }
                else //web api sent error response 
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                }
            }

            return returnData;
        }
        private void DeleteStudentsAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                //HTTP GET
                var responseTask = client.DeleteAsync("api/data/" + id.ToString()).GetAwaiter().GetResult();

                if (responseTask.IsSuccessStatusCode)
                {
                }
                else //web api sent error response 
                {
                    ModelState.AddModelError(string.Empty, "Error.");
                }
            }
        }
    }

}
