namespace WeatherAppp.Weather
{
    public class Main
    {
        private double _temp;

        public double temp
        {
            get { return _temp; }
            set { _temp = value - 271.15; } //получаем цельсии
        }

        private double _pressure;

        public double pressure
        {
            get { return _pressure; }
            set { _pressure = value / 1.3332239; }
        }

        public double humidity;

        private double _tempMin;

        public double tempMin
        {
            get { return _tempMin; }
            set { _tempMin = value - 271.15; } //получаем цельсии
        }

        private double _tempMax;

        public double tempMax
        {
            get { return _tempMax; }
            set { _tempMax = value - 271.15; } //получаем цельсии
        }
    }
}