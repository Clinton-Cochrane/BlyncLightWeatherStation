using System.Collections.Generic;

using BlyncLightWeatherStation.Models;
using BlyncLightWeatherStation.Services.BlyncLight;


namespace BlyncLightWeatherStation.Controllers
{
	public class ColorController
	{
		private readonly List<BlyncLightInstruction> _recipe = new List<BlyncLightInstruction>();

		public ColorController(int temp, int currentCondition)
		{
			_recipe.Add(MapTempToColor(temp));
			_recipe.AddRange(MapConditionToColor(currentCondition));
		}

		public void SetColors()
		{
			var blyncController = new BlyncController();
			blyncController.InitBlyncDevices();
			blyncController.PlayRecipe(_recipe);
		}

		//Numbers come from openWeatherMap api. I have mapped them into these categories.
		private IEnumerable<BlyncLightInstruction> MapConditionToColor(int currentCondition)
		{
			var lightThunderstorm = new List<int> { 200, 210, 230 };
			var mediumThunderstorm = new List<int> { 201, 211, 231 };
			var heavyThunderstorm = new List<int> { 202, 212, 221, 232 };

			var lightRain = new List<int> { 300, 310, 500, 301, 520, 701 };
			var mediumRain = new List<int> { 311, 313, 321, 501, 521 };
			var heavyRain = new List<int> { 302, 312, 314, 502, 503, 504, 522, 531 };

			var lightSnow = new List<int> { 511, 600, 615, 620 };
			var mediumSnow = new List<int> { 601, 611, 612, 621 };
			var heavySnow = new List<int> { 602, 622 };

			var conditionInstructions = new List<BlyncLightInstruction>
			{
				new BlyncLightInstruction(BlyncLightColor.Off, TimeDelay.Off)
			};
			if(lightThunderstorm.Contains(currentCondition))
			{
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Yellow, TimeDelay.Condition));
			} else if(mediumThunderstorm.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Yellow, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
			} else if(heavyThunderstorm.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Yellow, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
			} else if(lightRain.Contains(currentCondition))
			{
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
			} else if(mediumRain.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
			} else if(heavyRain.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Blue, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
			} else if(lightSnow.Contains(currentCondition))
			{
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Cyan, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.White, TimeDelay.Condition));
			} else if(mediumSnow.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Cyan, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.White, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Yellow));
			} else if(heavySnow.Contains(currentCondition))
			{
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Cyan, TimeDelay.Condition));
				conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.White, TimeDelay.Condition));
				conditionInstructions.AddRange(getWarning(BlyncLightColor.Red));
			}
			conditionInstructions.Add(new BlyncLightInstruction(BlyncLightColor.Off, TimeDelay.Off));
			if(conditionInstructions.Count <= 2)
			{
				conditionInstructions.Clear();
			}

			return conditionInstructions;
		}

		private IEnumerable<BlyncLightInstruction> getWarning(BlyncLightColor color)
		{
			var warningList = new List<BlyncLightInstruction>();
			for(var i = 0; i < 4; i++)
			{
				warningList.Add(new BlyncLightInstruction(BlyncLightColor.Off, TimeDelay.Off));
				warningList.Add(new BlyncLightInstruction(color, TimeDelay.Warning));
			}

			return warningList;
		}

		private static BlyncLightInstruction MapTempToColor(int temp)
		{
			var color = new BlyncLightColor();
			if(temp <= -5)
			{
				color = BlyncLightColor.Purple;
			} else if(temp >= -4 && temp <= 4)
			{
				color = BlyncLightColor.White;
			} else if(temp >= 5 && temp <= 12)
			{
				color = BlyncLightColor.Blue;
			} else if(temp >= 13 && temp <= 18)
			{
				color = BlyncLightColor.Cyan;
			} else if(temp >= 19 && temp <= 26)
			{
				color = BlyncLightColor.Green;
			} else if(temp >= 27 && temp <= 34)
			{
				color = BlyncLightColor.Yellow;
			} else if(temp >= 35) { color = BlyncLightColor.Red; }

			return new BlyncLightInstruction(color, TimeDelay.TemperatureColor);
		}
	}
}