using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using sporttracks.core.tool;

namespace sporttracks.core
{
    public static class ActivityExtensions
    {
        public static Activity ToActivity( this XmlElement element , XmlNamespaceManager nms)
        {
            var activity = new Activity();
// <Activity referenceId="cccd13f1-5120-4f63-8bb8-b33e58531c41"
// startTime="2013-04-23T16:58:41Z" timeZoneUtcOffset="2" hasStartTime="true"
// totalTime="2190.8199999999997"
// totalDistance="5994.2"
// totalCalories="468"
// notes="4 x 1000 m"
// categoryId="83da24e9-6a6d-4888-b4e9-ed06baac8332" categoryName="Lauftraining"
// location="AW - Plänzert" 
// useEnteredData="false">
            activity.Id = Guid.Parse( element.GetAttribute( "referenceId") );
            if ( element.GetAttributeAsBool("hasStartTime"))
            {
                activity.StartTime = element.GetAttributeAsDateTime("startTime");
                
            }
            activity.TotalTime = element.GetAttributeAsDouble( "totalTime");
            activity.TotalDistance = element.GetAttributeAsDouble( "totalDistance");
            activity.TotalCalories = element.GetAttributeAsDouble("totalCalories");

            activity.CategoryId = element.GetAttributeAsGuid("categoryId");
            activity.CategoryName = element.GetAttribute("categoryName");
            activity.Location = element.GetAttribute("location");
            activity.Notes = element.GetAttribute("notes");

            var laps = new List<Lap>();
            var lapsNode = element.SelectNodes("./ns1:Laps/ns1:Lap", nms);
            if ( lapsNode != null )
            {
                foreach ( XmlElement lapNode in lapsNode.OfType<XmlElement>() )
                {
                    laps.Add( lapNode.ToLap());
                }
                activity.Laps = laps;
            }

            var weatherNode = element.SelectSingleNode("./ns1:Weather", nms) as XmlElement;
            if ( weatherNode != null )
            {
                activity.Weather = weatherNode.ToWeather();
            }

            var gpsRouteNode = element.SelectSingleNode("./ns1:GPSRoute", nms) as XmlElement;
            if ( gpsRouteNode != null )
            {
                activity.GpsRoute = gpsRouteNode.ToGpsRoute(nms);
            }
            return activity;
        }

    }

}