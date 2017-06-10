using System.Text;
using System.Xml;

namespace sporttracks.core
{
    public class GpsRoute
    {
        public string Gpx { get; set; }    
    }


    public static class GpsRouteExtensions
    {
        // <Weather conditions="PartClouds" temperatureCelsius="10" />

        public static GpsRoute ToGpsRoute(this XmlElement element, XmlNamespaceManager nms)
        {
/*
<GPSRoute>
        <TrackData version="4">
 */
            var route = new GpsRoute();

            var trackDataNode = element.SelectSingleNode("./TrackData", nms);
            var encoded = element.InnerText;

            var gpxBytes = System.Convert.FromBase64String( encoded );
            var gpx = Encoding.Unicode.GetString( gpxBytes );
            route.Gpx = element.InnerText;

            return route;
        }
    }
   
}