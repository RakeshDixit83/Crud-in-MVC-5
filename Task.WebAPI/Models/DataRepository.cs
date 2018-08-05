using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Task.Entity;

namespace Task.WebApi.Models
{
    public class DataRepository : IDataRepository
    {

        List<Student> _students;
        public DataRepository()
        {
            LoadJson();
        }

        private void LoadJson()
        {
            using (StreamReader sr = new StreamReader(AppContext.BaseDirectory + "/App_Data/Students.json"))
            {
                var json = sr.ReadToEnd();
                _students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
        }

        private void UpdateJson()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(AppContext.BaseDirectory + "/App_Data/Students.json"))
                {
                    var json = JsonConvert.SerializeObject(_students);
                    sr.Write(json);
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Add(Student student)
        {
            _students.Add(student);
            UpdateJson();
            return true;
        }

        public bool Delete(Student student)
        {
           var result = _students.Remove(student);
            if (result)
                UpdateJson();
            return result;
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public bool Update(Student student)
        {
            var oldStu =_students.Find(x => x.ID == student.ID);
            oldStu.Name = student.Name;
            oldStu.FatherName = student.FatherName;
            oldStu.Address = student.Address;
            oldStu.Standerd = student.Standerd;

            UpdateJson();

            return true;
        }
    }
}