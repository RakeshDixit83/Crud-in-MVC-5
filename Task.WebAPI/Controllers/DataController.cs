using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task.Entity;
using Task.WebApi.Models;

namespace Task.WebApi.Controllers
{
    public class DataController : ApiController
    {
        private IDataRepository _repository;
        public DataController(IDataRepository dataRepository)
        {
            _repository = dataRepository;
        }

        // GET: api/Data
        public List<Student> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Data/5
        public Student Get(int id)
        {
            return _repository.GetAll().Find(x => x.ID == id);
        }

        // POST: api/Data
        public void Post(Student student)
        {
            _repository.Add(student);
        }

        // PUT: api/Data/5
        public void Put(Student student)
        {
            _repository.Update(student);
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
            var student = this.Get(id);
            _repository.Delete(student);
        }
    }
}
