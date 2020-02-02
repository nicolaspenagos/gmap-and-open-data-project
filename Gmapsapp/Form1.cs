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
            int n = e.RowIndex;

            if (n!=-1) {

                textBox1.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox2.Text = (string)dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox4.Text = (string)dataGridView1.Rows[n].Cells[4].Value.ToString();
                textBox3.Text = (string)dataGridView1.Rows[n].Cells[3].Value.ToString();
                textBox6.Text = (string)dataGridView1.Rows[n].Cells[5].Value.ToString();
                textBox5.Text = (string)dataGridView1.Rows[n].Cells[6].Value.ToString();
            }
        }
    }
}
