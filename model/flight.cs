using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Flight
    {
        private int year;
        private int month;
        private int dayOfTheMonth;
        private int dayOfTheWeek;
        private string flightDate;
        private int airlineId;
        private string airline;
        private int flightNumber;
        private int originAirport;
        private int destAirport;
        private string originState;
        private string destState;
        private bool cancelled;
        private double distance;

        public Flight(int year, int month, int dayOFTheMonth, int dayOFTheWeek, string flightDate, int airlineId, string airline, int flightNumber, int originAirport, int destAirport, string originState, string destState, bool cancelled, double distance)
        {
            this.year = year;
            this.month = month;
            this.dayOfTheMonth = dayOFTheMonth;
            this.dayOfTheWeek = dayOFTheWeek;
            this.flightDate = flightDate;
            this.airlineId = airlineId;
            this.airline = airline;
            this.flightNumber = flightNumber;
            this.originAirport = originAirport;
            this.destAirport = destAirport;
            this.originState = originState;
            this.destState = destState;
            this.cancelled = cancelled;
            this.distance = distance;
        }

        public int getMonth() {
            return month;
        }

        public int getDayOfTheMonth() {
            return dayOfTheMonth;
        }

        public int getDayOfTheWeek() {
            return dayOfTheWeek;
        }

        public int getAirlineId()
        {
            return airlineId;
        }

        public string getFlightDate() {
            return flightDate;
        }

        public string getAirline() {
            return airline;
        }

        public int getFlightNumber() {
            return flightNumber;
        }

        public int getOriginAirport() {
            return originAirport;
        }

        public int getDestAirport() {
            return destAirport;
        }

        public string getOriginState() {
            return originState;
        }

        public string getDestState() {
            return destState;
        }

        public bool getCancelled() {
            return cancelled;
        }

        public double getDistance() {
            return distance;
        }

        public int getYear() {
            return year;
        }
        public string getInfo() {
            String msg = " FLIGHT INFO    Year:"+year+"  Month:"+month+"  Day of the month:"+dayOfTheMonth+"  Day of the week:"+dayOfTheWeek+"  Flight date:"+flightDate+"  AirlineId:"+airlineId+"  Airline:"+airline+"  Flight number:"+flightNumber+"  Origin airport:"+originAirport+"  Destiny airport:"+destAirport+"  Origin State:"+originState+"  Destiny State:"+destState+"  Cancelled:"+cancelled+"  Distance:"+distance;
            return msg;
        }


       

    }
}
