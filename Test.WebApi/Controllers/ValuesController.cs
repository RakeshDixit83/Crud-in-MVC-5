using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Models;

namespace Test.WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        private List<Student> _students;
        public ValuesController()
        {
            _students = new List<Student>();
            _students.Add(new Student { ID=1, Name="John", FatherName="Michael", Address="Los Angels", Standerd="10" });
            _students.Add(new Student { ID = 2, Name = "Jack", FatherName = "David", Address = "Los Angels", Standerd = "11" });
        }
        // GET api/values
        public List<Student> Get()
        {
            return _students;
        }

        // GET api/values/5
        public List<Student> Get(int id)
        {
            return _students.Where(x => x.ID == id).ToList();
        }

        // POST api/values
        public void Add(string value)
        {
        }

        
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
