using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string miasto;
            miasto = textBox1.Text;

            WebClient pageInfo = new WebClient();

            string adres = "http://api.openweathermap.org/data/2.5/weather?q=" + miasto + ",pl&APPID=94358ce2861d71ffadb4a10a4fae8d28";
            var dzejson = pageInfo.DownloadString(adres);
            var a = JsonConvert.DeserializeObject<RootObject>(dzejson);

            double stopnie = a.main.temp - 273.15;
            double cisnienie = a.main.pressure;
            string opis_ang = a.weather[0].description;

            string opis_pogody = "Dzisiejsza pogoda - mamy " + stopnie + " stopni Celsjusza. Ciśnienie wynosi  " + cisnienie + " hPa. A jak niebo? " + opis_ang;

            textBox2.Text = opis_pogody;
         }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
