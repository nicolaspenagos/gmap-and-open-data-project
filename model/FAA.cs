using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class FAA
    {
        private string name;
        private List<Flight> flights;

        public FAA(String name) {
            this.name = name;
            flights = new List<Flight>();
        }

      
        public List<Flight> getFlight() {
            return flights;
        }


        public void load() {
            string relativePath = "..\\..\\Properties\\dataSet.csv";
            StreamReader sr = new StreamReader(relativePath);
            string line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null) {
                String[] parts = line.Split(';');
                if (parts.Length != 1)
                {
                    int month = int.Parse(parts[2]);
                    int dayOFTheMonth = int.Parse(parts[3]);
                    int dayOFTheWeek = int.Parse(parts[4]);
                    string flightDate = parts[5];
                    int airlineId = int.Parse(parts[7]);
                    string airline = parts[8];
                    int flightNumber = int.Parse(parts[10]); 
                    int originAirport = int.Parse(parts[11]);
                    int destAirport = int.Parse(parts[20]);
                    string originState = parts[15];
                    string destState = parts[24];
                    bool cancelled = (parts[47].Equals("")) ? false : true;
                    double distance = double.Parse(parts[53]);

                    flights.Add(new Flight(month, dayOFTheMonth, dayOFTheWeek, flightDate, airlineId, airline, flightNumber, originAirport, destAirport, originState, destState, cancelled, distance));


                }

            }

            sr.Close();
            Console.WriteLine("TODOS LOS DATOS HAN SIDO CARGADOS");


        }
    }
}
