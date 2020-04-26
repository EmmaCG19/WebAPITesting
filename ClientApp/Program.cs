using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAlumnosWithAPI();
            PostAlumnosWithAPI();
            Console.ReadLine();
        }

        public static void GetAlumnosWithAPI()
        {
            //GET REQUEST
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50022/api/");
                var responseTask = client.GetAsync("students");
                responseTask.Wait();

                var result = responseTask.Result;

                //Si la request devuelve una response con Status 200(OK), leer los datos
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Student>>();
                    readTask.Wait();

                    var students = readTask.Result;

                    foreach (var student in students)
                    {
                        Console.WriteLine(String.Format("Id:{0} - Name:{1}", student.Id, student.FullName));

                    }

                }
            }
        }

        public static void PostAlumnosWithAPI()
        {

            Console.Write("Ingrese el nombre de un alumno: ");
            var est = new Student() { FullName = Console.ReadLine() };

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:50022/api/");

                var request = cliente.PostAsJsonAsync("students", est);
                request.Wait();

                var response = request.Result;

                if (response.IsSuccessStatusCode)
               {
                    var readTask = response.Content.ReadAsAsync<Student>();
                    readTask.Wait();

                    var estInsertado = readTask.Result;

                    Console.WriteLine(String.Format("El estudiante {0} que tiene la Id {1} se insertó con éxito", estInsertado.FullName, estInsertado.Id));

                }
                else
                {
                    Console.WriteLine(response.StatusCode);

                }

            }


        }

    }
}

