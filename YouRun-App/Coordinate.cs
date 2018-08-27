using System;
using System.Collections;
namespace YouRunApp
{
    // A class that represents a coordinate on a map 
    // Holds a latitude and longitude as doubles
    public class Coordinate
    {
        private double _Latitude;
        private double _Longitude;

        /* Constructor that sets the latitude and longitude */
        public Coordinate(double Lat, double Lon)
        {
            _Latitude = Lat;
            _Longitude = Lon;
        }

        /* Returns distance in miles between current coordinate and 'x' */
        public double GetDistance(Coordinate x)
        {
            return Distance.CalcDistance(_Latitude, _Longitude,
                                         x.GetLatitude(), x.GetLongitude(),
                                         'M');
        }

        // Get Methods //
        public double GetLatitude()
        {
            return _Latitude;
        }

        public double GetLongitude()
        {
            return _Longitude;
        }

        // Set Methods //
        public void SetLatitude(double lat)
        {
            _Latitude = lat;
        }
        public void SetLongitude(double lon)
        {
            _Longitude = lon;
        }
    }

    // Class which identifies if two coordinates are equal to eachother
    public class CoordinateCompare : IEqualityComparer
    {

        // Compares two Coordinates to see if they are equal
        // If they are close enough together it considers them equal
        bool IEqualityComparer.Equals(object x, object y)
        {
            Coordinate C1 = x as Coordinate;
            Coordinate C2 = y as Coordinate;

            double distance = C1.GetDistance(C2);

            return distance <= GlobalConstants.CLOSE_ENOUGH;
        }

        int IEqualityComparer.GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
