namespace BlyncLightWeatherStation.Models
{
	public class BlyncLightInstruction
	{
		public BlyncLightInstruction(BlyncLightColor color, TimeDelay displayTime)
		{
			Color = color;
			DisplayTime = displayTime;
		}

		public BlyncLightColor Color {get; set;}

		public TimeDelay DisplayTime {get; set;}
	}
}