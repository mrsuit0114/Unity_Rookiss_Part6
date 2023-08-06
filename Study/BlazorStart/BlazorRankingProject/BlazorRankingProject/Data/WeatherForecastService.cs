using Newtonsoft.Json;
using SharedData.Models;

namespace BlazorRankingProject.Data
{
    public class WeatherForecastService
    {
        HttpClient _httpClient;

        public WeatherForecastService(HttpClient client)
        {
            // dependency injection
            _httpClient = client;
        }

        // Read

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {
            var result = await _httpClient.GetAsync("https://localhost:7098/WeatherForecast");

            var resultContent = await result.Content.ReadAsStringAsync();
            List<WeatherForecast> resWeatherResults = JsonConvert.DeserializeObject<List<WeatherForecast>>(resultContent);
            return resWeatherResults;

        }

    }

    /*public class WeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
		{
			return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = startDate.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			}).ToArray());
		}
	}*/
}