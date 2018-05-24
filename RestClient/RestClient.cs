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
    class RestClient
    {
        private HttpClient client = new HttpClient();

        private RestClient()
        {

        }

        public async Task<String> CreatePersonAsync(Person person)
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

        public async Task<String> GetPersonAsync(string path)
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


        public async Task<String> UpdatePersonAsync(Person person)
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


        public async Task<HttpStatusCode> DeletePersonAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Person/{id}");
            return response.StatusCode;
        }

        public static RestClient NewInstance(String url)
        {
            RestClient rc = new RestClient();
            rc.client.BaseAddress = new Uri(url);
            rc.client.DefaultRequestHeaders.Accept.Clear();
            rc.client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return rc;
        }
    }
}
