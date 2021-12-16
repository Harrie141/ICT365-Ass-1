using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms.Design;
using GMap.NET;

namespace Assignment1
{
    public partial class AddForm : Form
    {
        double lat;
        double lng;
        int i;
        public AddForm()
        {
            InitializeComponent();
            
        }

        public AddForm(double x, double y, int tempint)
        {
            InitializeComponent();
            lat = x;
            lng = y;
            i = tempint;
           

        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void E_type_TextChanged(object sender, EventArgs e)
        {

        }

        private void E_Des_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        /*
        * Third Party Reference: https://stackoverflow.com/questions/64194463/how-to-add-new-elements-to-a-soap-xml
        */
            public void EntertheValues(int TempInt)
            {
                XDocument xDoc = XDocument.Load(@"Event-Log.xml");
                XElement soap = xDoc.Root;
               
                TempInt++;


                soap.Add(new XElement("Event", new XElement("eventid", TempInt.ToString()),
                                               new XElement("location",
                                                    new XElement("lat", lat),
                                                    new XElement("long", lng)),
                                               new XElement("datetimestamp", dateTimePicker1.ToString()),
                                               new XElement("context",E_type.Text,
                                               new XElement("data",E_Des.Text))
                                               )
                    );

            }

        private void button1_Click(object sender, EventArgs e)
        {

            EntertheValues(i);
            MessageBox.Show("Event Added");
            Close();
        }
    }
       
    }


