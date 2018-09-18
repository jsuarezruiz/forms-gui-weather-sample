using HelloGuiForms.Models;
using HelloGuiForms.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloGuiForms.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private string _zipCode;
        private ICommand _weatherCommand;
        private Weather _weather;

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }

        public Weather Weather
        {
            get { return _weather; }
            set
            {
                _weather = value;
                OnPropertyChanged();
            }
        }

        public ICommand WeatherCommand =>        
            _weatherCommand ??
            (_weatherCommand = new Command(async () => await GetWeatherAsync()));

        public async Task GetWeatherAsync()
        {
            try
            {
                Weather = await WeatherService.Instance.GetWeatherAsync(ZipCode);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}