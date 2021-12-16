using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET;
using System.Drawing;

namespace Assignment1
{
    class MapSettings :Form1
    {
        public Dictionary<string, Event> EventDictionary;// string is the event id
        public static EventDataHandler EventData;

        public int GetSize() { return EventDictionary.Count; } //Keep track of the Dictionary of Event

        // Creating and then loading the data
        public void LoadData()
        {
            EventData = new EventDataHandler();
            EventDictionary = EventData.InputAllEvents();
        }

        public GMapOverlay UpdateOverlay()
        {
            GMapOverlay overlay = new GMapOverlay { Id = "Markers" };
            
            foreach (var e in EventDictionary)
            {
                e.Value.Marker = AddEventMarker(e.Value);
                overlay.Markers.Add(e.Value.Marker);
            }

            Console.WriteLine("Event Markers: " + EventDictionary.Count);
            Console.WriteLine("Total Markers: " + overlay.Markers.Count);
            //This is to make sure no marker was missed and thus can be reffered in the console tab after the end of the program
            return overlay;
        }
        /*
         * THis is a third part code as had no idea about gmap markers before
         * link: https://csharp.hotexamples.com/examples/GMap.NET.WindowsForms/GMapMarker/-/php-gmapmarker-class-examples.html
         * link: http://www.independent-software.com/gmap-net-beginners-tutorial-adding-clickable-markers-to-your-map-updates-for-vs2015-and-gmap-1-7.html
         */
        public GMapMarker AddEventMarker(Event e)
        {
            
            double lat = e.GetLocation().Lat;
            double lon = e.GetLocation().Lng;
            Console.WriteLine("New Event Marker at " + e.Location);
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lon),  GMarkerGoogleType.red_pushpin)
            {
                ToolTipText = "EVENT\n\n"
                + e.EventID + "\n"
                + e.DateAndTime + "\n"
                + e.EventType + "\n"
                + e.EventDescription +"\n"
                + e.Location.ToString()

            };

            /*
             * THis is just make the pins and textbox looklike officeworks :) 
             * 
             */
            //marker.ToolTip.
            marker.ToolTip.Fill = Brushes.LightBlue;
            marker.ToolTip.Foreground = Brushes.DarkBlue;
            marker.ToolTip.Stroke = Pens.DarkBlue;
            marker.ToolTip.TextPadding = new Size(20, 20);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;//get data hovering over the marker
            marker.Tag = e.EventID;

            return marker;
        }
    }
}

