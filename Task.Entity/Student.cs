using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Entity
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Standerd { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { ID = 1, Name = "Michael", Standerd = "10", Address = "Los Angels", FatherName = "John" });
            students.Add(new Student { ID = 2, Name = "Michael", Standerd = "11", Address = "Los Angels", FatherName = "John" });
            students.Add(new Student { ID = 3, Name = "Michael", Standerd = "9", Address = "Los Angels", FatherName = "John" });
            students.Add(new Student { ID = 4, Name = "Michael", Standerd = "12", Address = "Los Angels", FatherName = "John" });
            students.Add(new Student { ID = 5, Name = "Michael", Standerd = "11", Address = "Los Angels", FatherName = "John" });

            return students;
        }

    }
}