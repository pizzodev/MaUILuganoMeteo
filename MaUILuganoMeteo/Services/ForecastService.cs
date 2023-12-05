using System.Diagnostics;
using System.Text.Json;
using MaUILuganoMeteo.Model;

namespace MaUILuganoMeteo.Services
{
    public interface IForecastService
    {
        public Task<List<DailyForecast>> GetForecastsData();
    }

    public class ForecastService: IForecastService
	{
        string baseUrl = "https://api.open-meteo.com/v1/forecast?latitude=46.0101&longitude=8.96&daily=weather_code";

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<DailyForecast> forecasts { get; private set; }

        public ForecastService()
		{
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<DailyForecast>> GetForecastsData()
        {
            Uri uri = new Uri(string.Format(baseUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    WeekForecast weekForecast = JsonSerializer.Deserialize<WeekForecast>(await response.Content.ReadAsStringAsync(), _serializerOptions);
                    List<DailyForecast> dailyForecast = new List<DailyForecast>();

                    foreach (var day in weekForecast.daily.time.Select((name, index) => (name, index)))
                    {
                        dailyForecast.Add(
                            new DailyForecast(
                                day.name,
                                ((WeatherCode) weekForecast.daily.weather_code.ElementAt(day.index)).ToString()
                            )
                        );
                    }

                    forecasts = dailyForecast;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return forecasts;
        }

    }
}

