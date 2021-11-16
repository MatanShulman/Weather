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
            return View();
        }

        /// <summary>
        /// use "api.openweathermap.org" API to get "Tel-Aviv" weather information
        /// </summary>
        /// <returns>Root model</returns>
        [HttpGet]
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
                Response.StatusCode = 500;
                return Json(ex.Message);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
