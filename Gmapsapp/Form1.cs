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
        private int currentPage;
        private bool load;
        public Form1()
        {
            InitializeComponent();
            faa = new FAA("Federal Aviation Administration");
            currentPage = 1;
            txtBoxCurrentPage.Text = currentPage + "";
            load = false;

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
            load = true;
            List<Flight> currentFlights = faa.getFlight();

            showFlights();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GMapOverlay markers = new GMapOverlay("markers");
            //markers.Clear();
            int n = e.RowIndex;

            if (n != -1)
            {

                textBox1.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox2.Text = (string)dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox4.Text = (string)dataGridView1.Rows[n].Cells[5].Value.ToString();
                textBox3.Text = (string)dataGridView1.Rows[n].Cells[4].Value.ToString();
                textBox6.Text = (string)dataGridView1.Rows[n].Cells[6].Value.ToString();
                textBox5.Text = (string)dataGridView1.Rows[n].Cells[7].Value.ToString();
            }

            // Coordenate c;
            // double x1 = 25.793333;        
            // double y1 = -80.290556;
            //  double x2 = 33.9425;
            // double y2 = -118.408056;


            //    GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(x2, y2), GMarkerGoogleType.blue_dot);



            GeoCoderStatusCode statusCode;
            var pointLatLng = OpenStreetMapProvider.Instance.GetPoint(textBox6.Text.Trim(), out statusCode);

            var pointLatLng2 = OpenStreetMapProvider.Instance.GetPoint(textBox5.Text.Trim(), out statusCode);

            string lat1 = pointLatLng?.Lat.ToString();
            string lon1 = pointLatLng?.Lng.ToString();
            string lat2 = pointLatLng2?.Lat.ToString();
            string lon2 = pointLatLng2?.Lng.ToString();


            //  MessageBox.Show(textBox6.Text.Trim() + lat1 +" " +lon1);

            double x1 = double.Parse(lat1);
            double y1 = double.Parse(lon1);
            double x2 = double.Parse(lat2);
            double y2 = double.Parse(lon2);

            GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(x1, y1), GMarkerGoogleType.blue_dot);
            GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(x2, y2), GMarkerGoogleType.blue_dot);
            Console.WriteLine(lat1 + "  " + lon1);
            markers.Markers.Add(marker1);
            markers.Markers.Add(marker2);
            gmap.Overlays.Add(markers);

            GMapOverlay ruta = new GMapOverlay("CP");
            List<PointLatLng> puntos = new List<PointLatLng>();

            puntos.Add(new PointLatLng(x1, y1));
            GMapRoute puntosRuta = new GMapRoute(puntos, "Ruta");
            ruta.Routes.Add(puntosRuta);
            gmap.Overlays.Add(ruta);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPage > 1 && load)
            {
                currentPage--;
                txtBoxCurrentPage.Text = currentPage + "";
                showFlights();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentPage < 8 && load)
            {
                currentPage++;
                txtBoxCurrentPage.Text = currentPage + "";
                showFlights();
            }
        }

        public void showFlights()
        {

            dataGridView1.Rows.Clear();

            int i, j;

            if (currentPage == 1)
            {
                i = 0;
                j = 5000;
            }
            else if (currentPage == 2)
            {
                i = 5001;
                j = 10000;
            }
            else if (currentPage == 3)
            {
                i = 10001;
                j = 15000;
            }
            else if (currentPage == 4)
            {
                i = 15001;
                j = 20000;
            }
            else if (currentPage == 5)
            {
                i = 20001;
                j = 25000;
            }
            else if (currentPage == 6)
            {
                i = 25001;
                j = 30000;
            }
            else if (currentPage == 7)
            {
                i = 30001;
                j = 35000;
            }
            else
            {
                i = 35001;
                j = 40000;
            }

            List<Flight> currentFlights = faa.getFlight();

            for (int k = i; k < j; k++)
            {

                Flight currentFlight = currentFlights.ElementAt(k);
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = (k + 1) + "";
                dataGridView1.Rows[n].Cells[1].Value = currentFlight.getYear();
                dataGridView1.Rows[n].Cells[2].Value = currentFlight.getFlightDate();
                dataGridView1.Rows[n].Cells[3].Value = currentFlight.getFlightNumber();
                dataGridView1.Rows[n].Cells[4].Value = currentFlight.getAirlineId();
                dataGridView1.Rows[n].Cells[5].Value = currentFlight.getAirline();
                dataGridView1.Rows[n].Cells[6].Value = currentFlight.getOriginState();
                dataGridView1.Rows[n].Cells[7].Value = currentFlight.getDestState();
                dataGridView1.Rows[n].Cells[8].Value = currentFlight.getCancelled();
                dataGridView1.Rows[n].Cells[9].Value = currentFlight.getDistance();

            }


        }

        public void showFlights(List<Flight> flights)
        {
            /*
            int i, j;

            if (currentPage == 1)
            {
                i = 0;
                j = 5000;
            }
            else if (currentPage == 2)
            {
                i = 5001;
                j = 10000;
            }
            else if (currentPage == 3)
            {
                i = 10001;
                j = 15000;
            }
            else if (currentPage == 4)
            {
                i = 15001;
                j = 20000;
            }
            else if (currentPage == 5)
            {
                i = 20001;
                j = 25000;
            }
            else if (currentPage == 6)
            {
                i = 25001;
                j = 30000;
            }
            else if (currentPage == 7)
            {
                i = 30001;
                j = 35000;
            }
            else
            {
                i = 35001;
                j = 40000;
            }
            */
            dataGridView1.Rows.Clear();

            for (int k = 0; k < flights.Count; k++)
            {
                Flight currentFlight = flights.ElementAt(k);
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = (k + 1) + "";
                dataGridView1.Rows[n].Cells[1].Value = currentFlight.getYear();
                dataGridView1.Rows[n].Cells[2].Value = currentFlight.getFlightDate();
                dataGridView1.Rows[n].Cells[3].Value = currentFlight.getFlightNumber();
                dataGridView1.Rows[n].Cells[4].Value = currentFlight.getAirlineId();
                dataGridView1.Rows[n].Cells[5].Value = currentFlight.getAirline();
                dataGridView1.Rows[n].Cells[6].Value = currentFlight.getOriginState();
                dataGridView1.Rows[n].Cells[7].Value = currentFlight.getDestState();
                dataGridView1.Rows[n].Cells[8].Value = currentFlight.getCancelled();
                dataGridView1.Rows[n].Cells[9].Value = currentFlight.getDistance();
            }
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals("") && comboBox1.Text != null)
            {
                if (!textBox7.Text.Equals("") && textBox7.Text != null)
                {
                    string toCompare = textBox7.Text;
                    string parameter = comboBox1.Text;

                    showFlights(faa.toFilter(toCompare, parameter));

                }
            }

        }

      
    }
}
