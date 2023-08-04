using System.ComponentModel.DataAnnotations;

namespace BlazorStudy.Data
{
	public class WeatherForecast
	{
		public DateOnly Date { get; set; }

		[Required(ErrorMessage = "Need TempC!")]
		[Range(typeof(int), "-100","100")]
		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		[Required(ErrorMessage = "Need Sum!")]
		[StringLength(10,MinimumLength = 0, ErrorMessage = "3~10")]
		public string? Summary { get; set; }
	}
}