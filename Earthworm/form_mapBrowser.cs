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

        List<CropProperties> _properties = new List<CropProperties>();

        public form_mapBrowser(List<CropProperties> properties)
        {
            _properties = properties;
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Initialize map
            gmap.MapProvider = GMapProviders.GoogleHybridMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GMapOverlay polygons = new GMapOverlay("polygons");
            foreach (CropProperties property in _properties)
            {

                gmap.Position = new PointLatLng(property.maxLat, property.maxLng);
                gmap.MinZoom = 1;
                gmap.MaxZoom = 24;
                gmap.Zoom = 5;
                gmap.ShowCenter = false;



                // Initialize shapefile boundaries

                List<PointLatLng> points = new List<PointLatLng>();

                // Create polygons + add to map Lat = Y, Lng = X
                points.Add(new PointLatLng(property.minLat, property.minLng));
                points.Add(new PointLatLng(property.maxLat, property.minLng));
                points.Add(new PointLatLng(property.maxLat, property.maxLng));
                points.Add(new PointLatLng(property.minLat, property.maxLng));

                // Creates polygons
                GMapPolygon polygon = new GMapPolygon(points, "Extents");
                polygon.Fill = new SolidBrush(Color.FromArgb(25, Color.Green));
                polygon.Stroke = new Pen(Color.Red, 1);
                polygons.Polygons.Add(polygon);
                gmap.Overlays.Add(polygons);

            }


        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

            }

        }
    }
}
