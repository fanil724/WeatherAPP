using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WeatherAppp.Weather;

namespace WeatherAppp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool cityInput = false;

        private void button1_Click(object sender, EventArgs e)
        {
            except.Visible = false;
            if (city != null)
            {
                cityInput = true;
            }

            if (cityInput)
            {
                url = address + city;
                url += apiKey;
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";
                string answer = string.Empty;
                WebResponse response=null;
                try
                {
                    response = request.GetResponse();
                    using (Stream s = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(s))
                        {
                            answer = reader.ReadToEnd();
                        }
                    }

                    response.Close();
                }
                catch (WebException ex)
                {
                    except.Visible = true;
                    except.Text = "Ошибка соединения или не правильно введен город!" +
                                  " повторите позже! ";
                    textBox1.Text = null;
                    groupBox1.Visible = false;
                    return;
                }
                openWeather(answer);
                groupBox1.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            except.Visible = false;
        }

        private void openWeather(string answer)
        {
            OpenWeather ow = JsonConvert.DeserializeObject<OpenWeather>(answer);
            panel1.BackgroundImage = ow.weather[0].Icon;
            label2.Text = ow.weather[0].main;
            label3.Text = ow.weather[0].description;
            label4.Text = "Средняя температура(°С): " + ow.main.temp.ToString("0.##");
            label7.Text = "Скорость(м/с): " + ow.wind.speed.ToString();
            label8.Text = "Напрваление °: " + ow.wind.deg.ToString();
            label5.Text = "Влажность(%): " + ow.main.humidity.ToString();
            label6.Text = "Давление(мм): " + ((int)ow.main.pressure).ToString();
            label9.Text = ow.name;
            textBox1.Text = null;
        }


        private string city { get; set; } = null;
        private string url = " ";
        private string address = "https://api.openweathermap.org/data/2.5/weather?q=";
        private string apiKey = "&APPID=a16c0f860b821b4591f4b1e8c6ee9fc2";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            city = textBox1.Text;
        }
    }
}