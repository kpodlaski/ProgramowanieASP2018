using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<String> CreatePersonAsync(Person person)
        {
            Console.WriteLine(person.AsJSON());

            HttpContent content = new StringContent(person.AsJSON(),
                                    Encoding.UTF8,
                                    "application/json");
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync(
                "api/Person", content);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Content.ToString();
        }

        static async Task<String> GetPersonAsync(string path)
        {
            Person product = null;
            String sPerson = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                sPerson = await response.Content.ReadAsStringAsync();
            }
            //Do Dorobienia Konwersja json na Person i zwóc Person 
            return sPerson;
        }

        
        static async Task<String> UpdatePersonAsync(Person person)
        {
            HttpContent content = new StringContent(person.AsJSON(),
                                    Encoding.UTF8,
                                    "application/json");
            HttpResponseMessage response = await client.PutAsync(
                $"api/Person/{person.ID}", content);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            String s = await response.Content.ReadAsStringAsync();
            return s;
        }

        
        static async Task<HttpStatusCode> DeletePersonAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Person/{id}");
            return response.StatusCode;
        }

        
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:39967/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                List<Phone> phones = new List<Phone>();
                phones = new List<Phone>() {
                    new Phone {ID=0, Number="7777"},
                    new Phone {ID=1, Number="8888"},
                };

                Person p = new Person
                {
                    ID = -1,
                    Name = "Pankracy",
                    Organization = "TVP",
                    Phones = phones
                };
                var url = await CreatePersonAsync(p);
                Console.WriteLine($"Created at {url}");

                
                // Get the product
                String s = await GetPersonAsync("api/Person");
                Console.WriteLine("Response ");
                Console.WriteLine(s);
                
                // Update the product
                Console.WriteLine("Updating Person Organization...");
                p.Organization = "Polsat";
                p.ID = 3;
                await UpdatePersonAsync(p);

                // Get the updated product
                s = await GetPersonAsync("api/Person/3");
                Console.WriteLine("Response ");
                Console.WriteLine(s);

                
                // Delete the product
                var statusCode = await DeletePersonAsync("0");
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                // Get All products
                s = await GetPersonAsync("api/Person");
                Console.WriteLine("After Delete ");
                Console.WriteLine(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
