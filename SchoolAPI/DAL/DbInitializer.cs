using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SchoolAPI.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<SchoolDBContext>
    {
        public DbInitializer()
        {
            //agregar algo
        }

        protected override void Seed(SchoolDBContext context)
        {
            //Populate the tables with some entries
            Random rnd = new Random(100);

            Standard snd = new Standard() { Name = "StandardExample" };
            context.Standards.Add(snd);

            List<Student> students = new List<Student>()
            {
                new Student(){ Name="John", Surname ="Johnson", DNI= rnd.Next(200,300), StandardId = 1},
                new Student(){ Name="Max", Surname ="Johnson", DNI= rnd.Next(200,300), StandardId = 1},
                new Student(){ Name="Steve", Surname = "Richards",DNI= rnd.Next(200,300), StandardId = 1},
                new Student(){ Name="Luke", Surname = "Skywalker",DNI= rnd.Next(200,300), StandardId = 1 }

            };

            foreach (var est in students)
            {
                context.Students.Add(est);
                context.SaveChanges();
            }


            base.Seed(context);

        }

    }
}