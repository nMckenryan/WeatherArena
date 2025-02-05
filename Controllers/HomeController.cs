using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherArena.Models;

namespace WeatherArena.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
            DotNetEnv.Env.Load();
        }

        public async Task<IActionResult> Index()
        {
            var lat = 37.8136;
            var lon = 144.9631;
            var key = Environment.GetEnvironmentVariable("OPEN_WEATHER_API_KEY");
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}&units=metric";

            //https://api.openweathermap.org/data/2.5/weather?lat=37.8136&lon=144.9631&appid=ea3f09569a6ba8de648ced6aa4a5bbba&units=metric

            var weatherData = await _apiService.GetWeatherData(url);

            return View(weatherData);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
