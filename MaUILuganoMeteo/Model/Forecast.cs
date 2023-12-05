using System;
namespace MaUILuganoMeteo.Model
{
	public class WeekForecast
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double generationtime_ms { get; set; }
        public int utc_offset_seconds { get; set; }
        public string timezone { get; set; }
        public string timezone_abbreviation { get; set; }
        public double elevation { get; set; }
        public DailyUnits daily_units { get; set; }
        public Daily daily { get; set; }
    }
    public class Daily
    {
        public List<string> time { get; set; }
        public List<int> weather_code { get; set; }
    }

    public class DailyUnits
    {
        public string time { get; set; }
        public string weather_code { get; set; }
    }
    public struct DailyForecast
    {
        public string time { get; set; }
        public string weather { get; set; }

        public DailyForecast(string _time, string _weather)
        {
            time = _time;
            weather = _weather;
        }
    }
    public enum WeatherCode: int
    {
        CLEAR_SKY = 0,
        MAINLY_CLEAR = 1,
        PARTLY_CLOUD = 2,
        OVERCAST = 3,
        FOG = 45,
        RIME_FOG = 48,
        DRIZZLE_LIGHT = 51,
        DRIZZLE_MODERATE = 53,
        DRIZZLE_DENSE = 55,
        FREEZING_DRIZZLE_LIGHT = 56,
        FREEZING_DRIZZLE_DENSE = 57,
        RAIN_SLIGHT = 61,
        RAIN_MODERATE = 63,
        RAIN_HEAVY = 65,
        FREEZING_RAIN_LIGHT = 71,
        FREEZING_RAIN_MODERATE = 73,
        FREEZING_RAIN_HEAVY = 75,
        SNOW_GRAINS = 77,
        RAIN_SHOWERS_SLIGHT = 80,
        RAIN_SHOWERS_MODERATE = 81,
        RAIN_SHOWERS_VIOLENT = 82,
        SNOW_SHOWERS_SLIGHT = 85,
        SNOW_SHOWERS_HEAVY = 86,
        THUNDERSTORM = 95,
        THUNDERSTORM_HAIL_SLIGHT = 96,
        THUNDERSTORM_HAIL_HEAVY = 99
    }
}

