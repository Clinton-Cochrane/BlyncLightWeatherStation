using System;


namespace BlyncLightWeatherStation.Models
{
	public class CurrentWeather
	{
		private int _feelsLikeTemperature;

		public string CityName {get; set;}

		public int Temperature {get; set;}

		public int Humidity {get; set;}

		public int WindSpeed {get; set;}

		public string WindDirection {get; set;}

		public string CurrentCondition {get; set;}

		public int CurrentConditionId {get; set;}

		public string CurrentConditionsIconId {get; set;}

		public DateTime SunRise {get; set;}

		public DateTime SunSet {get; set;}

		public DateTime LastUpdate {get; set;}

		public Precipitation Precipitation {get; set;}

		public int FeelsLikeTemperature
		{
			get => _feelsLikeTemperature;
			set =>
				_feelsLikeTemperature =
					Temperature >= 27 ? CalculateHeatIndex() :
					(Temperature <= 5) ? CalculateWindChill() : Temperature;
		}

		//current formula for calculating wind chill. There is one that uses m/s and C°, but it is much more difficult to type out
		//first I convert to fahrenheit, and the wind speed comes in to this class in MPH if calculation seems off check this part
		//then move it back to Celsius
		//finally round it down and return as an int
		private int CalculateWindChill()
		{
			int tempInFahrenheit = (9 / 5) * Temperature + 32;
			double windChill = 35.74 +
								(0.6215 * tempInFahrenheit) -
								(35.75 * Math.Pow(WindSpeed, 0.16)) +
								(0.4275 * tempInFahrenheit * Math.Pow(WindSpeed, 0.16));

			windChill = (5 / 9) * (windChill - 32);
			windChill = Convert.ToInt16(Math.Floor(windChill));

			return(int) windChill;
		}

		//the formula below is the Rothfusz regression. This is the first step there are ways to get more precision
		private int CalculateHeatIndex()
		{
			double[] constant =
			{
				-42.379, 2.04901523, 10.14333127, -0.22475541, -0.00683783, -0.05481717, 0.00122874, 0.00085282,
				-0.00000199
			};
			int temperature = (9 / 5) * Temperature + 32;
			var tempSquared = Math.Pow(temperature, 2);
			int humidity = Humidity;
			var humiditySquared = Math.Pow(humidity, 2);

			var heatIndex =
				(constant[1])                                 +
				(constant[2]               * temperature)     +
				(constant[3]               * humidity)        +
				(constant[4] * temperature * humidity)        +
				(constant[5]               * tempSquared)     +
				(constant[6]               * humiditySquared) +
				(constant[7] * tempSquared * humidity)        +
				(constant[8] * temperature * humiditySquared) +
				(constant[9] * tempSquared * humiditySquared);

			heatIndex = (5 / 9) * (heatIndex - 32);
			heatIndex = Convert.ToInt16(Math.Floor(heatIndex));

			return(int) heatIndex;
		}
	}
}