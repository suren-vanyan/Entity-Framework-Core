using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }
    }
}
