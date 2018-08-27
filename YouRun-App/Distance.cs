using System;
using System.Collections;

namespace YouRunApp
{
    public static class Distance
    {
        /* Calculates the distance between two points using haversine formula
         *
         * All arguments except unit are given in degrees
         * 
         * Returns the distance in Kilometers, Nautical Miles, or Miles
         * depending on [unit] (K,N,M)
         * 
         * Source: https://www.movable-type.co.uk/scripts/latlong.html
         */
        public static double CalcDistance(double lat1, double lon1,
                                          double lat2, double lon2,
                                          char unit)
        {
            // Convert latitude values to radians
            double lat1Radians = GlobalConstants.DEGREES_TO_RADIANS * lat1;
            double lat2Radians = GlobalConstants.DEGREES_TO_RADIANS * lat2;

            // Calculate difference between latitudes
            double deltaLat = lat2 - lat1;

            // Convert difference to radians
            double deltaLatRadians = deltaLat * GlobalConstants.DEGREES_TO_RADIANS;

            // Find difference in longitude values and covert them to radians
            double deltaLamda = lon2 - lon1;
            double deltaLamdaRadians = GlobalConstants.DEGREES_TO_RADIANS * deltaLamda;

            // Calculate distance between the two points
            double distancekM = CalcGreatCircleDistance(lat1Radians, lat2Radians, deltaLatRadians, deltaLamdaRadians);

            /* Decide which unit to use for distance*/
            switch (unit)
            {
                case 'K': // Kilometers -> default
                    return distancekM;
                case 'N': // Nautical Miles 
                    return distancekM * GlobalConstants.KM_TO_NAUTICAL;
                case 'M': // Miles
                    return distancekM * GlobalConstants.KM_TO_MILES;
            }

            return distancekM;
        }

        /* Helper function which calculates distance between two points using 
         * haversine forumla
         * 
         * Returns the distance in KM
         */
        private static double CalcGreatCircleDistance(double lat1Radians, double lat2Radians,
                                                      double deltaLatRadians, double deltaLamdaRadians)
        {
            // Calculate square of the half chord length between the points
            double a = Math.Sin(deltaLatRadians / 2) * Math.Sin(deltaLatRadians / 2) +
                       Math.Cos(lat1Radians) * Math.Cos(lat2Radians) *
                       Math.Sin(deltaLamdaRadians / 2) * Math.Sin(deltaLamdaRadians / 2);

            // Calculate angular distance in radians
            double angularDistance = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));

            // Calcuate the distance in KM using earth's radius
            double distanceKM = GlobalConstants.EARTH_RADIUS * angularDistance;

            return distanceKM;
        }
    }
}
