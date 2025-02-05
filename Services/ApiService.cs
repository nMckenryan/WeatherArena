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
        try
        {
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var weatherData = await response.Content.ReadFromJsonAsync<ForecastModel>();
            return weatherData;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP request error: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"JSON parsing error: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            // handle any other exceptions
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
