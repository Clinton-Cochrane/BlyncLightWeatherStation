namespace BlyncLightWeatherStation.Models
{
	public enum TimeDelay
	{
		TemperatureColor = 30000,
		Condition = 1500,
		Warning = 250,
		Off = Warning / 2,
	}
}