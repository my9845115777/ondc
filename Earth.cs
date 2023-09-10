﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Monitoring
{
        class LatLon
        {
                public double Latitude, Longitude;
                public LatLon(double Lat, double Lon)
                {
                    Latitude = Lat;
                    Longitude = Lon;
                }
        }

    class Earth
    {
        public static LatLon CalculateDerivedPosition(LatLon source, double distance, double angle)
        {
            double distanceNorth = Math.Sin(angle) * distance;
            double distanceEast = Math.Cos(angle) * distance;
                
            double earthRadius = 6371000;

            double newLat = source.Latitude + (distanceNorth / earthRadius) * 180 / Math.PI;
            double newLon = source.Longitude + (distanceEast / (earthRadius * Math.Cos(newLat * 180 / Math.PI))) * 180 / Math.PI;
            return new LatLon(newLat, newLon);
        }

        public static double GetDistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            if (unit == 'K')
            {
                dist = dist * 1.609344;
            }
            else if (unit == 'N')
            {
                dist = dist * 0.8684;
            }
            return (dist);
        }

        private static double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
        private static double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }


    }




}
