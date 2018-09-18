using HelloGuiForms.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace HelloGuiForms.Services
{
    public class WeatherService
    {
        const string WeatherZipUri = "http://api.openweathermap.org/data/2.5/weather?zip={0}&appid=fc9f6c524fc093759cd28d41fda89a1b&units=imperial";

        private static WeatherService _instance;

        public static WeatherService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherService();

                return _instance;
            }
        }

        public async Task<Weather> GetWeatherAsync(string zipCode)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(WeatherZipUri, zipCode);
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();
                dynamic results = JsonConvert.DeserializeObject(json);

                Weather weather = new Weather
                {
                    Title = (string)results["name"],
                    Temperature = (string)results["main"]["temp"] + " F",
                    Wind = (string)results["wind"]["speed"] + " mph",
                    Humidity = (string)results["main"]["humidity"] + " %",
                    Visibility = (string)results["weather"][0]["main"]
                };

                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";

                return weather;
            }
        }
    }
}