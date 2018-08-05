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
        public ActionResult Index()
        {
           var data =  GetStudentsAsync();
            return View(data);
        }
        public ActionResult SaveStudent()
        {
            //SaveStudentsAsync(new Student { ID = 1, Name = "abc", FatherName = "def", Address = "ghi", Standerd = "1" });

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
            string url = "http://localhost:49875/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
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
            string url = "http://localhost:49875/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url+ "api/data");
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
            string url = "http://localhost:49875/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
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
            string url = "http://localhost:49875/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
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
