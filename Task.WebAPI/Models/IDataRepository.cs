using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task.Entity;

namespace Task.WebApi.Models
{
    public interface IDataRepository
    {
        List<Student> GetAll();
        bool Add(Student student);

        bool Update(Student student);

        bool Delete(Student student);


    }
}