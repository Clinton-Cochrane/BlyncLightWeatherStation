namespace BlyncLightWeatherStation
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.weatherIcon = new System.Windows.Forms.PictureBox();
			this.lastUpdateValue = new System.Windows.Forms.Label();
			this.currentConditionValue = new System.Windows.Forms.Label();
			this.currentTempValue = new System.Windows.Forms.Label();
			this.lblPrecipitation = new System.Windows.Forms.Label();
			this.currentCityValue = new System.Windows.Forms.Label();
			this.sunsetValue = new System.Windows.Forms.Label();
			this.lblSunset = new System.Windows.Forms.Label();
			this.sunriseValue = new System.Windows.Forms.Label();
			this.lblSunrise = new System.Windows.Forms.Label();
			this.windValue = new System.Windows.Forms.Label();
			this.humidityValue = new System.Windows.Forms.Label();
			this.lblWind = new System.Windows.Forms.Label();
			this.lblHumidity = new System.Windows.Forms.Label();
			this.percipitationValue = new System.Windows.Forms.Label();
			this.lblLastUpdate = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.weatherIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// weatherIcon
			// 
			this.weatherIcon.ErrorImage = ((System.Drawing.Image)(resources.GetObject("weatherIcon.ErrorImage")));
			this.weatherIcon.Location = new System.Drawing.Point(34, 104);
			this.weatherIcon.Name = "weatherIcon";
			this.weatherIcon.Size = new System.Drawing.Size(64, 64);
			this.weatherIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.weatherIcon.TabIndex = 0;
			this.weatherIcon.TabStop = false;
			// 
			// lastUpdateValue
			// 
			this.lastUpdateValue.AutoSize = true;
			this.lastUpdateValue.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lastUpdateValue.Location = new System.Drawing.Point(90, 43);
			this.lastUpdateValue.Name = "lastUpdateValue";
			this.lastUpdateValue.Size = new System.Drawing.Size(59, 13);
			this.lastUpdateValue.TabIndex = 2;
			this.lastUpdateValue.Text = "updating...";
			// 
			// currentConditionValue
			// 
			this.currentConditionValue.AutoSize = true;
			this.currentConditionValue.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.currentConditionValue.Location = new System.Drawing.Point(12, 78);
			this.currentConditionValue.Name = "currentConditionValue";
			this.currentConditionValue.Size = new System.Drawing.Size(99, 23);
			this.currentConditionValue.TabIndex = 3;
			this.currentConditionValue.Text = "updating...";
			// 
			// currentTempValue
			// 
			this.currentTempValue.AutoSize = true;
			this.currentTempValue.Font = new System.Drawing.Font("Roboto", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.currentTempValue.Location = new System.Drawing.Point(104, 101);
			this.currentTempValue.Name = "currentTempValue";
			this.currentTempValue.Size = new System.Drawing.Size(0, 58);
			this.currentTempValue.TabIndex = 4;
			// 
			// lblPrecipitation
			// 
			this.lblPrecipitation.AutoSize = true;
			this.lblPrecipitation.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPrecipitation.Location = new System.Drawing.Point(328, 83);
			this.lblPrecipitation.Name = "lblPrecipitation";
			this.lblPrecipitation.Size = new System.Drawing.Size(97, 18);
			this.lblPrecipitation.TabIndex = 5;
			this.lblPrecipitation.Text = "Percipitation:";
			// 
			// currentCityValue
			// 
			this.currentCityValue.AutoSize = true;
			this.currentCityValue.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.currentCityValue.Location = new System.Drawing.Point(14, 9);
			this.currentCityValue.Name = "currentCityValue";
			this.currentCityValue.Size = new System.Drawing.Size(142, 33);
			this.currentCityValue.TabIndex = 6;
			this.currentCityValue.Text = "updating...";
			// 
			// sunsetValue
			// 
			this.sunsetValue.AutoSize = true;
			this.sunsetValue.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sunsetValue.Location = new System.Drawing.Point(76, 220);
			this.sunsetValue.Name = "sunsetValue";
			this.sunsetValue.Size = new System.Drawing.Size(77, 18);
			this.sunsetValue.TabIndex = 7;
			this.sunsetValue.Text = "updating...";
			// 
			// lblSunset
			// 
			this.lblSunset.AutoSize = true;
			this.lblSunset.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSunset.Location = new System.Drawing.Point(12, 220);
			this.lblSunset.Name = "lblSunset";
			this.lblSunset.Size = new System.Drawing.Size(58, 18);
			this.lblSunset.TabIndex = 8;
			this.lblSunset.Text = "Sunset:";
			// 
			// sunriseValue
			// 
			this.sunriseValue.AutoSize = true;
			this.sunriseValue.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sunriseValue.Location = new System.Drawing.Point(76, 188);
			this.sunriseValue.Name = "sunriseValue";
			this.sunriseValue.Size = new System.Drawing.Size(77, 18);
			this.sunriseValue.TabIndex = 9;
			this.sunriseValue.Text = "updating...";
			// 
			// lblSunrise
			// 
			this.lblSunrise.AutoSize = true;
			this.lblSunrise.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSunrise.Location = new System.Drawing.Point(12, 188);
			this.lblSunrise.Name = "lblSunrise";
			this.lblSunrise.Size = new System.Drawing.Size(62, 18);
			this.lblSunrise.TabIndex = 10;
			this.lblSunrise.Text = "Sunrise:";
			// 
			// windValue
			// 
			this.windValue.AutoSize = true;
			this.windValue.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.windValue.Location = new System.Drawing.Point(379, 136);
			this.windValue.Name = "windValue";
			this.windValue.Size = new System.Drawing.Size(77, 18);
			this.windValue.TabIndex = 11;
			this.windValue.Text = "updating...";
			// 
			// humidityValue
			// 
			this.humidityValue.AutoSize = true;
			this.humidityValue.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.humidityValue.Location = new System.Drawing.Point(406, 108);
			this.humidityValue.Name = "humidityValue";
			this.humidityValue.Size = new System.Drawing.Size(77, 18);
			this.humidityValue.TabIndex = 12;
			this.humidityValue.Text = "updating...";
			// 
			// lblWind
			// 
			this.lblWind.AutoSize = true;
			this.lblWind.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWind.Location = new System.Drawing.Point(328, 136);
			this.lblWind.Name = "lblWind";
			this.lblWind.Size = new System.Drawing.Size(45, 18);
			this.lblWind.TabIndex = 13;
			this.lblWind.Text = "Wind:";
			// 
			// lblHumidity
			// 
			this.lblHumidity.AutoSize = true;
			this.lblHumidity.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHumidity.Location = new System.Drawing.Point(328, 109);
			this.lblHumidity.Name = "lblHumidity";
			this.lblHumidity.Size = new System.Drawing.Size(72, 18);
			this.lblHumidity.TabIndex = 14;
			this.lblHumidity.Text = "Humidity:";
			// 
			// percipitationValue
			// 
			this.percipitationValue.AutoSize = true;
			this.percipitationValue.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.percipitationValue.Location = new System.Drawing.Point(431, 83);
			this.percipitationValue.Name = "percipitationValue";
			this.percipitationValue.Size = new System.Drawing.Size(77, 18);
			this.percipitationValue.TabIndex = 15;
			this.percipitationValue.Text = "updating...";
			// 
			// lblLastUpdate
			// 
			this.lblLastUpdate.AutoSize = true;
			this.lblLastUpdate.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastUpdate.Location = new System.Drawing.Point(17, 43);
			this.lblLastUpdate.Name = "lblLastUpdate";
			this.lblLastUpdate.Size = new System.Drawing.Size(67, 13);
			this.lblLastUpdate.TabIndex = 16;
			this.lblLastUpdate.Text = "Last Update";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(562, 263);
			this.Controls.Add(this.lblLastUpdate);
			this.Controls.Add(this.percipitationValue);
			this.Controls.Add(this.lblHumidity);
			this.Controls.Add(this.lblWind);
			this.Controls.Add(this.humidityValue);
			this.Controls.Add(this.windValue);
			this.Controls.Add(this.lblSunrise);
			this.Controls.Add(this.sunriseValue);
			this.Controls.Add(this.lblSunset);
			this.Controls.Add(this.sunsetValue);
			this.Controls.Add(this.currentCityValue);
			this.Controls.Add(this.lblPrecipitation);
			this.Controls.Add(this.currentTempValue);
			this.Controls.Add(this.currentConditionValue);
			this.Controls.Add(this.lastUpdateValue);
			this.Controls.Add(this.weatherIcon);
			this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Blynclight Weather Station";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			((System.ComponentModel.ISupportInitialize)(this.weatherIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.PictureBox weatherIcon;
		private System.Windows.Forms.Label lastUpdateValue;
		private System.Windows.Forms.Label currentConditionValue;
		private System.Windows.Forms.Label currentTempValue;
		private System.Windows.Forms.Label lblPrecipitation;
		private System.Windows.Forms.Label currentCityValue;
		private System.Windows.Forms.Label sunsetValue;
		private System.Windows.Forms.Label lblSunset;
		private System.Windows.Forms.Label sunriseValue;
		private System.Windows.Forms.Label lblSunrise;
		private System.Windows.Forms.Label windValue;
		private System.Windows.Forms.Label humidityValue;
		private System.Windows.Forms.Label lblWind;
		private System.Windows.Forms.Label lblHumidity;
		private System.Windows.Forms.Label percipitationValue;
		private System.Windows.Forms.Label lblLastUpdate;
	}
}

