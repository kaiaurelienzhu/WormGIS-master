﻿using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Earthworm
{
    class helpers_Projection
    {
        // This method converts latitude longitude to UTM xyz pts
        public static void LatLongDSPToUTM(double latitude, double longitude, string utmStr, out double X, out double Y)
        {
            double[] latlong = new double[2];
            latlong[0] = latitude;
            latlong[1] = longitude;

            double[] Z = new double[1];
            Z[0] = 1;

            //string utmStr = "+proj=utm +zone=30 +ellps=WGS84 +datum=WGS84 +units=m +no_defs ";


            ProjectionInfo projIn = KnownCoordinateSystems.Geographic.World.WGS1984;
            ProjectionInfo projOut = ProjectionInfo.FromProj4String(utmStr);

            Reproject.ReprojectPoints(latlong, Z, projIn, projOut, 0, 1);
            Y = latlong[0];
            X = latlong[1];
        }

        // This method converts XYZ UTM pts to latitude longitude
        public static void UTMToLatLongDSP(double X, double Y, string utmStr, out double latitude, out double longitude)
        {
            double[] XY = new double[2];
            XY[0] = X;
            XY[1] = Y;

            double[] Z = new double[1];
            Z[0] = 1;

            //string utmStr = "+proj=utm +zone=30 +ellps=WGS84 +datum=WGS84 +units=m +no_defs ";

            ProjectionInfo projIn = ProjectionInfo.FromProj4String(utmStr);
            ProjectionInfo projOut = KnownCoordinateSystems.Geographic.World.WGS1984;
            Reproject.ReprojectPoints(XY, Z, projIn, projOut, 0, 1);

            longitude = XY[0];
            latitude = XY[1];
        }

        public static void ProjectPts(Point3d point, string inPrjStr, string outPrjStr, out double outX, out double outY)
        {
            double[] XY = new double[2];
            XY[0] = point.X;
            XY[1] = point.Y;

            double[] Z = new double[1];
            Z[0] = 1;

            //string utmStr = "+proj=utm +zone=30 +ellps=WGS84 +datum=WGS84 +units=m +no_defs ";

            ProjectionInfo projIn = ProjectionInfo.FromProj4String(inPrjStr);
            ProjectionInfo projOut = ProjectionInfo.FromProj4String(outPrjStr);
            Reproject.ReprojectPoints(XY, Z, projIn, projOut, 0, 1);

            outX = XY[0];
            outY = XY[1];
        }

        public static void DefaultProjectPts(Point3d point, string inPrjStr, out double outX, out double outY)
        {
            double[] XY = new double[2];
            XY[0] = point.X;
            XY[1] = point.Y;

            double[] Z = new double[1];
            Z[0] = 1;

            ProjectionInfo projIn = ProjectionInfo.FromProj4String(inPrjStr);
            ProjectionInfo projOut = ProjectionInfo.FromProj4String(" + proj = longlat + ellps = WGS84 + datum = WGS84 + no_defs");
            Reproject.ReprojectPoints(XY, Z, projIn, projOut, 0, 1);


            outX = XY[0];
            outY = XY[1];
        }


    }
}
