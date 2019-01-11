using System;
using System.Threading;
using System.Windows.Forms;

using BlyncLightWeatherStation.Controllers;
using BlyncLightWeatherStation.Models;
using BlyncLightWeatherStation.Services.Weather;

using Timer = System.Windows.Forms.Timer;


namespace BlyncLightWeatherStation
{
	public partial class Form1 : Form
	{
		private static readonly Timer Timer = new Timer();
		private Thread _lightControlThread;
		private const int DelayTime = 60000 * 1;

		public Form1() { InitializeComponent(); }

		private void Form1_Load(object sender, EventArgs e)
		{
			TimerEventProcessor(sender, e);
			Timer.Tick += (TimerEventProcessor);
			Timer.Interval = DelayTime;
			Timer.Start();
		}

		private async void TimerEventProcessor(object sender, EventArgs e)
		{
			_lightControlThread?.Abort();
			CurrentWeather currentWeather = await WeatherDataFetcher.GetWeatherAsync();
			SetUi(currentWeather);
			var colorController = new ColorController(currentWeather.Temperature, currentWeather.CurrentConditionId);
			_lightControlThread = new Thread(new ThreadStart(colorController.SetColors)) { IsBackground = true };
			_lightControlThread.Start();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if(WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon1.Visible = true;
			}
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
		}

		private void SetUi(CurrentWeather currentWeather)
		{
			currentCityValue.Text = currentWeather.CityName;
			lastUpdateValue.Text = currentWeather.LastUpdate.ToString();
			currentConditionValue.Text = $"{currentWeather.CurrentCondition.ToUpper()}";
			currentTempValue.Text = $"{currentWeather.Temperature}°";
			percipitationValue.Text = currentWeather.Precipitation.Mode;
			humidityValue.Text = $"{currentWeather.Humidity} %";
			windValue.Text = $"{currentWeather.WindDirection} @ {currentWeather.WindSpeed} MPH ";
			feelsLikeValue.Text = $"{currentWeather.FeelsLikeTemperature}°";
			sunriseValue.Text = currentWeather.SunRise.TimeOfDay.ToString();
			sunsetValue.Text = currentWeather.SunSet.TimeOfDay.ToString();
			weatherIcon.LoadAsync($"http://openweathermap.org/img/w/{currentWeather.CurrentConditionsIconId}.png");
		}


	}
}
