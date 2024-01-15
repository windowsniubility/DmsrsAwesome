using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApiAwesome.Controllers;

/// <summary>
/// The weather forecast controller.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
	/// </summary>
	/// <param name="logger">The logger.</param>
	public WeatherForecastController(ILogger<WeatherForecastController> logger)
	{
		this.logger = logger;
	}

	/// <summary>
	/// Gets a list of weatherforecasts.
	/// </summary>
	/// <returns>A list of weatherforecasts.</returns>
	[HttpGet(Name = "GetWeatherForecast")]
	public IEnumerable<WeatherForecast> Get()
	{
		return Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		})
		.ToArray();
	}
}
