using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using model; 




namespace Gmapsapp
{
    public partial class Form1 : Form
    {
        private FAA faa;
        public Form1()
        {
            InitializeComponent();
            faa = new FAA("Federal Aviation Administration");
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("Cali, Colombia");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            faa.load();
            Console.WriteLine("El tamaño de la lista es: "+faa.getFlight().Count());
            Console.WriteLine("El tamaño de la lista es: " + faa.getFlight().ElementAt(0).getDistance()+" "+ faa.getFlight().ElementAt(0).getOriginState()+" "+ faa.getFlight().ElementAt(0).getDestState());

        }
    }
}
