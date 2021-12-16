using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        private PointLatLng sp;
        public AddForm newevent;
         MapSettings Mapset;
        
         

        public PointLatLng Selectedpt { get => sp; set => sp = value; }
        public Form1()
        {
            InitializeComponent();
            gmap.MapProvider = GMapProviders.GoogleMap;
            gmap.MaxZoom = 20;
            gmap.MinZoom = 2;
         
        }

        //This is for autoloading map when turned on
        private void Form1_Load(object sender, EventArgs e)
        {
            _ = gmap.EmptyMapBackground; 
            gmap.Position = new GMap.NET.PointLatLng(-31.9523, 115.8613);//COrdinates of Perth
            gmap.Zoom = 10;
            LoaddatainMap();


        }
        //This function is to get back to the Perth View incase the person gets lost on the Map
        private void HomeTown_Click(object sender, EventArgs e)
        {
            gmap.Position = new GMap.NET.PointLatLng(-31.9523, 115.8613);
            gmap.Zoom = 10;
        }

        private void gmap_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            LoaddatainMap();
            if (e.Button == MouseButtons.Right)
            {

                
                var point = gmap.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lng = point.Lng;

                gmap.Position = point;

                var markers = new GMapOverlay { Id = "Markers" };
                var marker = new GMarkerGoogle(point, GMarkerGoogleType.arrow);
                markers.Markers.Add(marker);
                gmap.Overlays.Add(markers);

                AddForm ad = new AddForm(lat,lng,Mapset.GetSize());
                ad.Show();

            }
            
        }

        private void LoaddatainMap()
        {
            //gmap.Overlays.Remove();
            Mapset = new MapSettings();
            Mapset.LoadData();

            gmap.Overlays.Add(Mapset.UpdateOverlay());
        }

        private void gmap_OnMarkerDoubleClick(GMapMarker item, MouseEventArgs e)
        {
           
            
        }

    }
}
