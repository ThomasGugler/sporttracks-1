using System;
using System.Xml;
using sporttracks.core.tool;

namespace sporttracks.core
{

    public class Weather
    {
        public string Conditions { get; set; }
        public Double? TemperatureCelsius { get;set; }
    }

    public static class WeatherExtensions
    {
        // <Weather conditions="PartClouds" temperatureCelsius="10" />

        public static Weather ToWeather(this XmlElement element)
        {
            var weather = new Weather();

            weather.Conditions = element.GetAttribute("conditions");
            weather.TemperatureCelsius = element.GetAttributeAsDouble("temperatureCelsius");
            return weather;
        }
    }

}