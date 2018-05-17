using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadKey();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("http://localhost:58264/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/amigo");
                if (response.IsSuccessStatusCode)
                {
                    //GET
                    var amigo = await response.Content.ReadAsAsync<List<Amigo>>();
                    string objName = null;
                    string objLastName = null;
                    amigo.ForEach(x =>
                    {
                        objName = x.Name;
                        objLastName = x.LastName;
                    });
                    Console.WriteLine("Dados de amigo");
                    Console.WriteLine("{0}\t{1}\t", objName, objLastName);
                    Console.WriteLine("Amigo acessado e exibido. ");
                    Console.ReadKey();
                }
            }
        }
    }
}

