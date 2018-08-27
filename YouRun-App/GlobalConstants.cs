using System;
namespace YouRunApp
{
    public static class GlobalConstants
    {
        /**********************************************************************/
        /*                       Location Constants                          */
        /**********************************************************************/

        /* Determines if the distance between two coordinates
         * is close enough that they can be considered equal */
        public const double CLOSE_ENOUGH = .000001;

        /**********************************************************************/
        /*                       Conversion Constants                         */
        /**********************************************************************/

        /* Converts from degrees to radians */
        public const double DEGREES_TO_RADIANS = System.Math.PI / 180;

        /* Converts from kilometers to miles */
        public const double KM_TO_MILES = 0.621371;

        /* Used for converting distance from kilometers to Nautical Miles */
        public const double KM_TO_NAUTICAL = 0.539957;

        /* Earth's Radius in KM */
        public const int EARTH_RADIUS = 6371;

        /**********************************************************************/
        /*                       Priority Constants                           */
        /**********************************************************************/

        public const int NUMBER_OF_PRIORITIES = 5;

        /* Represents all the priorities the user would prioritize when asking
         * for a route. If updated, NUMBER_OF_PRIORITIES should be updated */
        public enum Priority
        {
            WATER,
            HILLS,
            ART,
            TREES
        };

        public const string PRIORITY_ERROR_MESSAGE =
            "Priority count and NUMBER_OF_PRIORITIES do not match.\n" +
            "Please update the NUMBER_OF_PRIORITIES constant.";

        /**********************************************************************/
        /*                       Filepath Constants                           */
        /**********************************************************************/

        public const string SHEHRYAR_PATH = "/Users/shehryarmalik/Documents/youruntesting/YouRunShared/iOS/";
        public const string RUSS_PATH = @"/Users/russgomez/Projects/YouRun1-27-18/MyFirstProject/iOS/";

        /**********************************************************************/
        /*               "Attribute Not Found" Constants                      */
        /**********************************************************************/

        // Valid range for Latitudes is 0 to 90, for Longitude is 0 to 180
        // So we picked one outside of both ranges to avoid errors
        public const double LAT_NOT_FOUND = 300;
        public const double LON_NOT_FOUND = 350;

        public const string KEYWORD_NOT_FOUND = "NO KEYWORD FOUND";
        public const string NAME_NOT_FOUND = "NO NAME FOUND";
        public const string DESCRIPTION_NOT_FOUND = "NO DESCRIPTION FOUND";

        /**********************************************************************/
        /*                Open Street Map Xml Constants                       */
        /**********************************************************************/

        public const string OSM_LAT = "lat";
        public const string OSM_LON = "lon";
        public const string OSM_ATTR_KEYWORD = "k";
        public const string OSM_ATTR_VALUE = "v";
        public const string OSM_NODE_NAME = "id";
    }
}
