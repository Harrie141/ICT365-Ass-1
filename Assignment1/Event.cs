using System;
using System.Collections.Generic;
using System.Linq;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1
{
    class Event
    {
        public string EventID { get; set; }

        private PointLatLng location;

        //These are the get/set meathods for Location
        public PointLatLng Location { get => location; set => location = value; }
        public PointLatLng GetLocation()
        {
            return location;
        } 
        public void SetLocation(PointLatLng loc)
        {
            location = loc;
        }

        public DateTime DateAndTime { get; set; }

        //this means whether the event marked is a text message, tweet, Facebook etc.
        public string EventType { get; set; }

        //Notes written by the user or written in the XML file
        public string EventDescription { get; set; }

        //This is to get information in a form of string of all the data of the event
        public override string ToString()
        {
            string estring = "";
            estring = $"Event ID: {EventID}Date/Time: {DateAndTime}Context: {EventType}Location: " + GetLocation();
            return estring;
        }
        
        public GMapMarker Marker { get; set; }
        //Get event function
        public Event GetEvent()
        {
            return this;
        }
    
    }
}
