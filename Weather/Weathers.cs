using System.Drawing;

namespace WeatherAppp.Weather

{
    public class Weathers
    {
        public int id;
        public string main;
        public string description;
        public string icon;

        public Bitmap Icon
        {
            get { return new Bitmap(Image.FromFile($"icons/{icon}.png")); }
        }
    }
}