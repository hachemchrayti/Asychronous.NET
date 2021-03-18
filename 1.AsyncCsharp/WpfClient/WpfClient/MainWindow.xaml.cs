using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            progress.IsIndeterminate = true;
            progress.Visibility = Visibility.Visible;

            var client = new WebClient();

            var response = await client.DownloadStringTaskAsync("http://localhost:9876/WeatherForecast");

            var forecasts = JsonConvert.DeserializeObject<List<WeatherForecast>>(response);

            tb_result.Text = string.Join(Environment.NewLine, forecasts.Select(f => $"Le {f.Date:dd/MM/yyyy}, il fera {f.TemperatureC}°"));

            progress.IsIndeterminate = false;
            progress.Visibility = Visibility.Hidden;
        }
    }
}
