using System;


namespace BlyncLightWeatherStation.Models
{
	public class CurrentWeather
	{
		public string CityName {get; set;}

		public int Temperature {get; set;}

		public string Humidity {get; set;}

		public string WindSpeed {get; set;}

		public string WindDirection {get; set;}

		public string CurrentCondition {get; set;}

		public int CurrentConditionId {get; set;}

		public string CurrentConditionsIconId {get; set;}

		public DateTime SunRise {get; set;}

		public DateTime SunSet {get; set;}

		public DateTime LastUpdate {get; set;}

		public Precipitation Precipitation {get; set;}
	}
}