using System;
using System.Globalization;
using System.Xml;

namespace sporttracks.core.tool
{

public static class XmlExtensions
{
    public static Guid? GetAttributeAsGuid( this XmlElement element, string name)
    {
        var s = element.GetAttribute( name);
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        return Guid.Parse( s );
    }


    public static byte? GetAttributeAsByte( this XmlElement element, string name)
    {
        var s = element.GetAttribute( name);
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        return Byte.Parse( s, CultureInfo.InvariantCulture  );
    }

    public static double? GetAttributeAsDouble( this XmlElement element, string name)
    {
        var s = element.GetAttribute( name);
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        return Double.Parse( s, CultureInfo.InvariantCulture  );
    }

    public static bool GetAttributeAsBool( this XmlElement element, string name)
    {
        var s = element.GetAttribute( name);
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }
        return String.Equals( s, "true", StringComparison.OrdinalIgnoreCase ) ||
               String.Equals( s, 1);
    }

    public static DateTime? GetAttributeAsDateTime( this XmlElement element, string name )
    {
        var s = element.GetAttribute( name);
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }
        return DateTime.Parse( s, CultureInfo.InvariantCulture );
       
    }
}

}