using ConsoleApp;
using System;
using System.Linq;

namespace HelloApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
   
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }
      
            using (ApplicationContext db = new ApplicationContext())
            {               
                var users = db.Users.ToList();
                
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
           
            using (ApplicationContext db = new ApplicationContext())
            {             
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;                  
                    db.SaveChanges();
                }
                             
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            
            using (ApplicationContext db = new ApplicationContext())
            {             
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {                   
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
               
               
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }

            using (ApplicationContext context=new ApplicationContext())
            {
                var user1 = context.Users.FirstOrDefault();
                var user2 = context.Users.LastOrDefault();
                context.RemoveRange(user1, user2);
                context.SaveChanges();
            }
            Console.Read();
        }
    }
}