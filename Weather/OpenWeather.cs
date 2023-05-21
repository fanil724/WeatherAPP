using System;
using Newtonsoft.Json;

namespace WeatherAppp.Weather
{
    public class OpenWeather
    {
        public Coords coord;
        public Weathers[] weather;
        [JsonProperty("base")] public string Base;
        public Main main;
        public double visibility;
        public Wind wind;
        public Clouds clouds;
        public double dt;
        public Sys sys;
        public UInt32 id;
        public string name;
        public double cod;
    }
}