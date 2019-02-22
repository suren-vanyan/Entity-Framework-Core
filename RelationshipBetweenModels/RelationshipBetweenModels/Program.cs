using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipBetweenModels
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Student s1 = new Student { Name = "James" };
                Student s2 = new Student { Name = "Bob" };
                Student s3 = new Student { Name = "Tomas" };
                db.Students.AddRange(new List<Student> { s1, s2, s3 });

                Course c1 = new Course { Name = "Course SQL" };
                Course c2 = new Course { Name = "OOP With C#" };
                db.Courses.AddRange(new List<Course> { c1, c2 });

                db.SaveChanges();


                s1.StudentCourses.Add(new StudentCourse { CourseId = c1.Id, StudentId = s1.Id });
                s2.StudentCourses.Add(new StudentCourse { CourseId = c1.Id, StudentId = s2.Id });
                s2.StudentCourses.Add(new StudentCourse { CourseId = c2.Id, StudentId = s2.Id });
                db.SaveChanges();

                var courses = db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).ToList();

                foreach (var c in courses)
                {
                    Console.WriteLine($"\n Course: {c.Name}");

                    var students = c.StudentCourses.Select(sc => sc.Student).ToList();
                    foreach (Student s in students)
                        Console.WriteLine($"{s.Name}");
                }
            }

            using (ApplicationContext db=new ApplicationContext())
            {
                var student = db.Students.Include(s => s.StudentCourses).FirstOrDefault(s => s.Name == "Tomas");
                var course = db.Courses.FirstOrDefault(c => c.Name == "Course SQL");
                if (student != null && course != null)
                {
                    var studentCourse = student.StudentCourses.FirstOrDefault(sc => sc.CourseId == course.Id);
                    student.StudentCourses.Remove(studentCourse);
                    db.SaveChanges();
                }
            }
        }
    }
}
