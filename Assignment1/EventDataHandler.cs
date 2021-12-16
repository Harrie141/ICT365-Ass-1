using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using GMap.NET;

namespace Assignment1
{
    class EventDataHandler : MapSettings
    {
        int items = 0;//Total items in the Dictionary

        public  int GetTotalENtry()
        {
            return items;
        }
        public Dictionary<string, Event> InputAllEvents()
        {
            Dictionary<string, Event> ev = new Dictionary<string, Event>();
            
            
            XNamespace hse = "http://projects.awgm.co/hindsightevents";//Namespace for the XML File
            XElement XFile = XElement.Load(@"Event-Log.xml");//Variable XFile has been used so that same code can be used for getting person information

            foreach(var e in XFile.Descendants(hse + "Event")){
                
                string tempDate = "";
                Event tempevent = new Event();//Data is of different types and all these types are present in the Event Class as its Event data
                PointLatLng tempLocation = new PointLatLng(); // This is the store location attributes such as Lat and Long in Event Class

                tempevent.EventID = e.Element(hse+"eventid").Value;
                //TempLocation has 2 attributes, both present in the XML file, so to fill the attribute,
                //Current Approach is used
                tempLocation.Lat = (double)e.Element(hse + "location").Element(hse + "lat");  //This is done because Lat and Long lie under the Location tab in XML file
                tempLocation.Lng = (double)e.Element(hse + "location").Element(hse + "long");

                tempevent.SetLocation(tempLocation);//Set locaation with the value of Lat and Long set above

                tempDate = e.Element(hse + "datetimestamp").Value;
                tempevent.DateAndTime = DateTime.Parse(tempDate, System.Globalization.CultureInfo.InvariantCulture);
                tempevent.EventType = e.Element(hse + "context").FirstAttribute.Value;
                tempevent.EventDescription = e.Element(hse + "context").Value;
                Console.WriteLine("Item Added {0}",tempevent.DateAndTime);
                //In this line of code, the values of the event are added to the dictionary of the events
                

                items++;//Incrementing total number of items in the dictionary
                //Before restarting the foreach loop, the total number of items that is items are already incremented in the starting of the program                
                 ev.Add(tempevent.EventID, tempevent);

                
            }

            Console.WriteLine("Total Events: {0}", items);//This is for later record if we want to cross check if all the enteries are begin inputed in the system

            return ev;//Dictionary Object
        }
    
        public Dictionary<string,Event> AddEvent(Dictionary<string,Event> evdictionary, Event newevent)
        {
            evdictionary.Add(newevent.EventID, newevent); //All the values have already been inputted before
            Console.WriteLine("New event was added. EventID: {0}", newevent.EventID);//THis for later reference and degugging if the event was added
            return evdictionary;
        }
        

    
    }
}


