using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Linq;

namespace sporttracks.core
{
    public class Logbook
    {
        public IReadOnlyList<Activity> Activities {get;set;}

        public static Logbook ReadFromFile( string fileName )
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"Logbook '{fileName}' not found");
            }

            var logbook = new Logbook();

            using ( var stream = File.OpenRead( fileName ) )
            {
                var doc = new XmlDocument();

                doc.Load( stream );
                var namespaceManager = new XmlNamespaceManager(doc.NameTable);
                namespaceManager.AddNamespace( "ns1", "urn:uuid:D0EB2ED5-49B6-44e3-B13C-CF15BE7DD7DD");

                var activities = new List<Activity>();
                var activityNodes = doc.DocumentElement.SelectNodes( "//ns1:Activity", namespaceManager );
                foreach ( var a in activityNodes.OfType<XmlElement>().Cast<XmlElement>() )
                {

                    var activity = a.ToActivity(namespaceManager); 
                    activities.Add( activity );                    
                    
                }
                logbook.Activities = activities;

                return logbook;
            }

        }
    }
}