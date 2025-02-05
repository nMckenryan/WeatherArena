using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherArena.Models;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ForecastModel> GetWeatherData(string url)
    {
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var weatherData = await response.Content.ReadFromJsonAsync<ForecastModel>();
            if (weatherData != null)
            {
                return weatherData;
            }
            else
            {
                return new ForecastModel();
            }
        }
        else
        {
            return new ForecastModel();
        }
    }
}
