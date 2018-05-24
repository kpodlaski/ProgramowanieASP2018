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
        

        
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            RestClient client = RestClient.NewInstance("http://localhost:39967/");
            
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
                var url = await client.CreatePersonAsync(p);
                Console.WriteLine($"Created at {url}");

                
                // Get the product
                String s = await client.GetPersonAsync("api/Person");
                Console.WriteLine("Response ");
                Console.WriteLine(s);
                
                // Update the product
                Console.WriteLine("Updating Person Organization...");
                p.Organization = "Polsat";
                p.ID = 3;
                await client.UpdatePersonAsync(p);

                // Get the updated product
                s = await client.GetPersonAsync("api/Person/3");
                Console.WriteLine("Response ");
                Console.WriteLine(s);

                
                // Delete the product
                var statusCode = await client.DeletePersonAsync("0");
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                // Get All products
                s = await client.GetPersonAsync("api/Person");
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
