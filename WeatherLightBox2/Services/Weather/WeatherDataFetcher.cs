using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using BlyncLightWeatherStation.Models;


namespace BlyncLightWeatherStation.Services.Weather
{
	public class WeatherDataFetcher
	{
		private static readonly HttpClient Client = new HttpClient();
		private static readonly string ApiKey = ConfigurationManager.AppSettings["APIKey"];
		private static readonly string BaseUrl =
			$"https://api.openweathermap.org/data/2.5/weather?mode=xml&APPID={ApiKey}";

		public static async Task<CurrentWeather> GetWeatherAsync()
		{
			string weatherDataInXml = await FetchDataFromApi();
			Current data = DeserializeResponse(weatherDataInXml);

			return new CurrentWeather()
			{
				CityName = data.City.Name,
				Temperature = Convert.ToInt16(Math.Floor(Convert.ToDouble(data.Temperature.Value))),
				Humidity = data.Humidity.Value,
				WindSpeed = data.Wind.Speed.Value,
				WindDirection = data.Wind.Direction.Code,
				CurrentCondition = data.Weather.Value,
				CurrentConditionId = int.Parse(data.Weather.Number),
				CurrentConditionsIconId = data.Weather.Icon,
				SunRise = Convert.ToDateTime(data.City.Sun.Rise).ToLocalTime(),
				SunSet = Convert.ToDateTime(data.City.Sun.Set).ToLocalTime(),
				LastUpdate = Convert.ToDateTime(data.Lastupdate.Value).ToLocalTime(),
				Precipitation = data.Precipitation,
			};
		}

		private static Current DeserializeResponse(string weatherDataInXml)
		{
			var deSerializer = new XmlSerializer(typeof(Current));
			var ms = new MemoryStream(Encoding.UTF8.GetBytes(weatherDataInXml));

			return(Current) deSerializer.Deserialize(ms);
		}

		private static async Task<string> FetchDataFromApi()
		{
			HttpResponseMessage response =
				await Client.GetAsync(new Uri($"{BaseUrl}&zip=74006,us&units=metric&"));

			return await response.Content.ReadAsStringAsync();
		}
	}
}