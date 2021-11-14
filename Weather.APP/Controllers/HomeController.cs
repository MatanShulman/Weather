using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.APP.Models;

namespace Weather.APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        public HomeController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
           // var s = await GetData();
            return View();
        }

        public async Task<JsonResult> GetData()
        {

            try
            {
                var httpResponse = await _client.GetAsync("http://api.openweathermap.org/data/2.5/forecast?lat=32.0853&lon=34.7818&appid=4ce97563e2ccf5dc64513ebb6aba9faa&units=metric");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }
                var content = await httpResponse.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<Root>(content);

                return Json(tasks);
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Main
        {
            public double temp { get; set; }
            //public double feels_like { get; set; }
            //public double temp_min { get; set; }
            //public double temp_max { get; set; }
            //public int pressure { get; set; }
            //public int sea_level { get; set; }
            //public int grnd_level { get; set; }
            //public int humidity { get; set; }
            //public double temp_kf { get; set; }
        }

        //public class Weather
        //{
        //    public int id { get; set; }
        //    public string main { get; set; }
        //    public string description { get; set; }
        //    public string icon { get; set; }
        //}

        //public class Clouds
        //{
        //    public int all { get; set; }
        //}

        //public class Wind
        //{
        //    public double speed { get; set; }
        //    public int deg { get; set; }
        //    public double gust { get; set; }
        //}

        //public class Sys
        //{
        //    public string pod { get; set; }
        //}

        public class info
        {
            //public int dt { get; set; }
            public Main main { get; set; }
            //public List<Weather> weather { get; set; }
            //public Clouds clouds { get; set; }
            //public Wind wind { get; set; }
            //public int visibility { get; set; }
            //public int pop { get; set; }
            //public Sys sys { get; set; }
            public string dt_txt { get; set; }
         //   public DateTime dt_txt { get; set; }
        }

        public class Coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class City
        {
            //public int id { get; set; }
            public string name { get; set; }
            //public Coord coord { get; set; }
            //public string country { get; set; }
            //public int population { get; set; }
            //public int timezone { get; set; }
            //public int sunrise { get; set; }
            //public int sunset { get; set; }
        }

        public class Root
        {
            //public string cod { get; set; }
            //public int message { get; set; }
            //public int cnt { get; set; }
            public List<info> list { get; set; }
            public City city { get; set; }
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
