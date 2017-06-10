using System;
using sporttracks.core;

namespace sporttracks
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = null;

            if ( args != null && args.Length > 0 )
            {
                file = args[0];
            }
            
            try
            {
                var logbook = Logbook.ReadFromFile( file );


            }
            catch ( Exception ex )
            {
                System.Console.WriteLine($"Error: {ex}");
                Environment.Exit(1);
            }

        }
    }
}
