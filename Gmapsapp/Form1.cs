using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
           gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
           GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;

            gmap.Zoom = 10;
            gmap.MinZoom = 5;
            gmap.MaxZoom = 100;
            gmap.SetPositionByKeywords("Cali, Colombia");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            faa.load();
            List<Flight> currentFlights = faa.getFlight();

            for (int i = 0; i < 5000; i++)
            {

                Flight currentFlight = currentFlights.ElementAt(i);
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = currentFlight.getYear();
                dataGridView1.Rows[n].Cells[1].Value = currentFlight.getFlightDate();
                dataGridView1.Rows[n].Cells[2].Value = currentFlight.getFlightNumber();
                dataGridView1.Rows[n].Cells[3].Value = currentFlight.getAirlineId();
                dataGridView1.Rows[n].Cells[4].Value = currentFlight.getAirline();
                dataGridView1.Rows[n].Cells[5].Value = currentFlight.getOriginState();
                dataGridView1.Rows[n].Cells[6].Value = currentFlight.getDestState();
                dataGridView1.Rows[n].Cells[7].Value = currentFlight.getCancelled();
                dataGridView1.Rows[n].Cells[8].Value = currentFlight.getDistance();

            }
            Console.WriteLine("El tamaño de la lista es: "+faa.getFlight().Count());
            Console.WriteLine("El tamaño de la lista es: " + faa.getInfo(0));
            Console.WriteLine("El tamaño de la lista es: " + faa.getInfo(1));
            Console.WriteLine("El tamaño de la lista es: " + faa.getInfo(2));

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GMapOverlay markers = new GMapOverlay("markers");
            //markers.Clear();
            int n = e.RowIndex;

            if (n!=-1) {

                textBox1.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox2.Text = (string)dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox4.Text = (string)dataGridView1.Rows[n].Cells[4].Value.ToString();
                textBox3.Text = (string)dataGridView1.Rows[n].Cells[3].Value.ToString();
                textBox6.Text = (string)dataGridView1.Rows[n].Cells[5].Value.ToString();
                textBox5.Text = (string)dataGridView1.Rows[n].Cells[6].Value.ToString();
            }

           // Coordenate c;
           // double x1 = 25.793333;        
           // double y1 = -80.290556;
          //  double x2 = 33.9425;
           // double y2 = -118.408056;

          
        //    GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(x2, y2), GMarkerGoogleType.blue_dot);

         

            GeoCoderStatusCode statusCode;
            var pointLatLng = OpenStreetMapProvider.Instance.GetPoint(textBox6.Text.Trim(), out statusCode);

            
            string lat = pointLatLng?.Lat.ToString();
            string lon = pointLatLng?.Lng.ToString();

            MessageBox.Show(textBox6.Text.Trim() + lat +" " +lon);

            double x1 = double.Parse(lat);
                double y1 = double.Parse(lon);
                GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(x1, y1), GMarkerGoogleType.blue_dot);
                Console.WriteLine(lat + "  " + lon);
                markers.Markers.Add(marker1);

                gmap.Overlays.Add(markers);
         
            

        }
    }
}
