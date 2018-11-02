using System;
using System.Device.Location;

namespace GpsStatusCheck
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myLocation = new CLocation();
            myLocation.GetLocationEvent(args.Length > 0);
            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();
        }

        private class CLocation
        {
            private GeoCoordinateWatcher _watcher;

            public void GetLocationEvent(bool isHighPrecision)
            {
                _watcher = new GeoCoordinateWatcher(isHighPrecision ? GeoPositionAccuracy.High : GeoPositionAccuracy.Default);
                _watcher.PositionChanged += watcher_PositionChanged;
                _watcher.StatusChanged += watcher_StatusChanged;
                _watcher.MovementThreshold = 0.5;

                Console.WriteLine("GeoCoordinateWatcher try start...");
                bool started = _watcher.TryStart(true, TimeSpan.FromMilliseconds(2000));
                if (!started)
                {
                    Console.WriteLine("GeoCoordinateWatcher timed out on start.");
                }
                else
                {
                    Console.WriteLine("watching gps position.");
                    Console.WriteLine(" accuracy: '{0}'", _watcher.DesiredAccuracy);
                    Console.WriteLine(" permission is '{0}'", _watcher.Permission);
                    if (_watcher.Permission == GeoPositionPermission.Denied)
                    {
                        Console.WriteLine("ERROR: Location access was denied. Please double check your system Settings->Location if location for this device is enabled.");
                    }
                }
            }

            private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
            {
                Console.WriteLine(" status is '{0}'", _watcher.Status);
            }

            private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
            {
                Console.WriteLine("");
                Console.WriteLine("==== Position obtained: {0} ====", e.Position.Timestamp.LocalDateTime);
                var location = e.Position.Location;
                if (location.IsUnknown)
                {
                    Console.WriteLine("     Location is unknown.");
                    return;
                }

                Console.WriteLine("     long(X)={0} lat=(Y)={1}", location.Longitude, location.Latitude);
                Console.WriteLine("     h-accuracy (m): {0:N1}", location.HorizontalAccuracy);
                Console.WriteLine("     v-accuracy (m): {0:N1}", location.VerticalAccuracy);
                Console.WriteLine("     altitude (m): {0:N1}", location.Altitude);
                Console.WriteLine("     speed (m/s): {0:N1}", location.Speed);
                Console.WriteLine("     course (°N): {0:N1}", location.Course);
            }
        }
    }
}
