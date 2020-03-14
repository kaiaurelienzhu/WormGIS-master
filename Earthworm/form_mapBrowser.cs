﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace Earthworm
{
    public partial class form_mapBrowser : Form
    {
        public form_mapBrowser()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            //Initialize map
            gmap.MapProvider = GMapProviders.GoogleHybridMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(0, 0);
            gmap.MinZoom = 1;
            gmap.MaxZoom = 24;
            gmap.Zoom = 1;
            gmap.ShowCenter = false;

            // Add a marker
            //GMap.NET.WindowsForms.GMapOverlay markers = new GMap.NET.WindowsForms.GMapOverlay("markers");
            //GMap.NET.WindowsForms.GMapMarker marker =
            //    new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
            //        new GMap.NET.PointLatLng(48.8617774, 2.349272),
            //        GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
            //marker.ToolTipText = "hello\nout there";
            //markers.Markers.Add(marker);
            //gmap.Overlays.Add(markers);

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(48.866383, 2.323575));
            points.Add(new PointLatLng(48.863868, 2.321554));
            points.Add(new PointLatLng(48.861017, 2.330030));
            points.Add(new PointLatLng(48.863727, 2.331918));


        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                double lat = gmap.FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = gmap.FromLocalToLatLng(e.X, e.Y).Lng;
                GMapOverlay markers = new GMapOverlay("Markers");
                GMapMarker marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                                new GMap.NET.PointLatLng(lat, lng),
                                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.blue_pushpin);
                marker.ToolTipText = "Hello out there";
                markers.Markers.Add(marker);
                gmap.Overlays.Add(markers);

            }

        }
    }
}
