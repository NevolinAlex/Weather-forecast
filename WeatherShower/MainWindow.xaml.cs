using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace WeatherShower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherLoader WeatherLoader;
        public MainWindow()
        {
            InitializeComponent();
            var json = new WebClient().DownloadString("http://www.meteoservice.ru/location/cities.html?country_id=1");
            var res = JObject.Parse(json);
            foreach(var item in res)
            {
                Cities2.Items.Add(new ComboBoxItem
                {
                    Name = item.Value["name"].ToString(),
                    Value = item.Value["point"].ToString()
                });

            }
            WeatherLoader = new WeatherLoader();
           
        }

        private void Cities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var item = comboBox.Items[comboBox.SelectedIndex] as ComboBoxItem;
            var forecast = WeatherLoader.LoadWeather(item);
            MessageBox.Show(forecast[0].DateTime);

        }

        private void Cities2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ListBox;
            var item = comboBox.Items[comboBox.SelectedIndex] as ComboBoxItem;
            var forecasts = WeatherLoader.LoadWeather(item);
            Forecasts.ItemsSource = forecasts;
            //MessageBox.Show(forecasts[0].DateTime);
        }
    }
}
