using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using GMap.NET;

namespace Assignment1
{
    public partial class AddEvent : Form1
    {
        PointLatLng cordinates;
        //MapSettings MS;
        double lat, lng;
        //int TempInt = MapSettings.EventData.GetTotalENtry() ;

        public AddEvent()
        {
            InitializeComponent();
            
        }

        public AddEvent(PointLatLng Point , double x, double y )
        {
            lat = x;
            lng = y;
            //EntertheValues();
            

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InputData();
            Close();
        }

        //public void InputData( )
        //{
        //    Event e = new Event();
        //    EventDataHandler evd = new EventDataHandler();
        //    MapSettings MS = new MapSettings();
        //   int tempeId = MS.EventDictionary.Count;
        //    tempeId++;
        //    e.EventID = tempeId.ToString();
        //    e.SetLocation(point);
        //    //e.DateAndTime;
        //    e.EventType = EventType.ToString();
        //    e.EventDescription = EventDes.ToString();
        //    e.DateAndTime = dateTimePicker1.Value;
        //    evd.AddEvent(MS.EventDictionary , e);
           
        //    MS.UpdateOverlay();
        //}
        public  void InputData(int TempInt)
        {
           
        }

        private void EventType_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        /*
         * Third Party Reference: https://stackoverflow.com/questions/64194463/how-to-add-new-elements-to-a-soap-xml
         */
        //public void EntertheValues()
        //{
        //    XDocument xDoc = XDocument.Load("hindsight-events.xml");
        //    XElement soap = xDoc.Root;
        //    XNamespace hse = "http://projects.awgm.co/hindsightevents";
        //    TempInt++;


        //    soap.Add(new XElement("Event", new XElement("eventid", TempInt.ToString()), 
        //                                   new XElement("location", 
        //                                        new XElement("lat", lat), 
        //                                        new XElement("long", lng)), 
        //                                   new XElement("datetimestamp", dateTimePicker1.ToString())
        //                                   )
        //        );
                
        //}
    }
}
