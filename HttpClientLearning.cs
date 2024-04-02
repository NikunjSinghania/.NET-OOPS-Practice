using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace OOPS
{
    class HttpClientLearning
    {
        public static async Task getData()
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.Timeout = TimeSpan.FromSeconds(1);


            var response = await httpClient.GetAsync("https://reqres.in/api/users?page=2");
            //var response = await client.GetAsync(request);
                //response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<Rootobject>(body);
            Console.WriteLine(jsonData.page);
            
            var d = new Rootobject();
            d.page = 100;
            d.per_page = 1;
            d.total_pages = 100;
            d.total = 100;

            d.data = new Datum[1];
            d.data[0] = new Datum()
            {
                id = 1,
                avatar = "avatar",
                email = "email",
                first_name = "first_name",
                last_name = "last_name"
        };


            d.support = new Support();
            d.support.text = "text";
            d.support.url = "url";

            Console.WriteLine(JsonConvert.SerializeObject(d));
            //            {
            //            "page": 2,
            //"per_page": 6,
            //"total": 12,
            //"total_pages": 2,
            //"data": [
            //    {
            //                "id": 12,
            //        "email": "rachel.howell@reqres.in",
            //        "first_name": "Rachel",
            //        "last_name": "Howell",
            //        "avatar": "https://reqres.in/img/faces/12-image.jpg"
            //    }
            //],
            //"support": {
            //                "url": "https://reqres.in/#support-heading",
            //    "text": "To keep ReqRes free, contributions towards server costs are appreciated!"
            //}
            //        }
        }
    }
}
