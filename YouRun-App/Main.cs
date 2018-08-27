using System;
using System.Collections;
using System.IO;
using UIKit;
using System.Diagnostics;

namespace YouRunApp
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {

            //TestCalcDistance();

            Hashtable nodes = XmlLoader.XmlLoad("~/test.osm");

            return;






            /* If the Number of Priorities constant doesn't equal
             * the number of priorities calculated at run time, end program */
            if (GlobalConstants.NUMBER_OF_PRIORITIES !=
                Enum.GetNames(typeof(GlobalConstants.Priority)).Length)
            {
                throw new Exception(GlobalConstants.PRIORITY_ERROR_MESSAGE);
            }

            RunAlgorithm();

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }

        static void TestCalcDistance()
        {
            /* Testing Distance Formula to see if it calculates Latitude
             * and Longitude Distance Correctly)
             */

            Console.WriteLine("Hi Shehryar");

            double[] lats = new double[] { 76.67, -32.13, 10.001, -30.971, 0.000 };
            double[] longs = new double[] { -82.99, 13.100, 76.918, -81.111, 0.000 };

            for (int i = 0; i < lats.Length - 1; i++)
            {
                Console.Write("Distance between: (" + lats[i] + ", " + longs[i] + ") ; ("
                              + lats[i + 1] + ", " + longs[i + 1] + "): ");

                double distance = Distance.CalcDistance(lats[i], longs[i], lats[i + 1], longs[i + 1], 'K');

                Console.WriteLine(distance);
            }
        }

        static void RunAlgorithm()
        {
            // Data Variables
            bool reachedHalfway = false;
            bool reachedStart = false;
            double distanceTraveled;
            double halfwayDistance;
            double totalDistance;
            double distanceJumped;

            Coordinate startLocation;
            Coordinate currentLocation;
            Coordinate predictedHalfwayPoint;
            // Class Preferences; // TODO create this Class

            /* Read in Preferences from User */


            /* Set Distance variables */
            // TODO Read in totalDistance from User, rather than hard code
            totalDistance = 8;
            halfwayDistance = totalDistance / 2;
            distanceTraveled = 0;


            /* Read in currentLocation and startLocation from Google */
            // currentLocation = new Coordinate(google.lat, google.lon)
            // startlocation = new Coordinate(google.lat, google.lon)


            /* Calculate predictedHalfwayPoint */
            //predictedHalfwayPoint = new Coordinate(calc.lat, calc.lon)


            // 1st Loop: Going To HalfwayPoint
            while (true)
            {
                if (distanceTraveled < halfwayDistance)
                {
                    // initialize variables
                    distanceJumped = 0;

                    // Pick a new local trajectory (i.e. pick a direction
                    // you will generally go in by examining the weights in
                    // the direction of the predictedHalfwayPoint)

                    // Randomly choose what your next turn will be (i.e. if you
                    // will go straight, right, or left, etc) based on
                    // the user's preferences and the weight potentials of
                    // different local routes

                    // Pick a turn with a function which adds the path to the 
                    // overall route and updates currentLocation, and returns 
                    // the distance involved in making the turn
                    // distanceJumped = PickATurn(currentLocation, currentPath);

                    // update distance the algorithm just traveled 
                    distanceTraveled += distanceJumped;
                }

                else
                {
                    reachedHalfway = true;
                    break;
                }
            }

            // 2nd Loop: Heading Back
            while (true)
            {
                if (distanceTraveled < totalDistance)
                {
                    // initialize variables
                    distanceJumped = 0;

                    // Pick a new local trajectory (i.e. pick a direction
                    // you will generally go in by examining the weights in
                    // the direction of the predictedHalfwayPoint)

                    // Randomly choose what your next turn will be (i.e. if you
                    // will go straight, right, or left, etc) based on
                    // the user's preferences and the weight potentials of
                    // different local routes

                    // Pick a turn with a function which adds the path to the 
                    // overall route and updates currentLocation, and returns 
                    // the distance involved in making the turn
                    // distanceJumped = PickATurn(currentLocation, currentPath);

                    // update distance the algorithm just traveled 
                    distanceTraveled += distanceJumped;
                }

                else
                {
                    // Check if we got back to startLocation
                    /* if (startLocation == currentLocation)
                    {
                        reachedStart = true;
                        break;
                    }

                       else (
                       {
                           // make a beeline for the starting position (i.e.
                           // get back to start as quick as possible)
                       }
                    */


                }
                break;
            }
        }

        static void TestHashTable()
        {
            /* Code for a Hash Table that holds the nodes in the map */
            /* Keys are the Coordinates */
            /* Values are the Nodes located at each Coordinate */
            /*Hashtable points = new Hashtable(new CoordinateCompare());

            // Create a sample coordinate to add to the Hashtable
            double sampleLatitude  =  40.7521844;
            double sampleLongitude = -73.9875229;

            Coordinate sampleKey = new Coordinate(sampleLatitude, 
                                                  sampleLongitude);

            String sampleData = "";

            points.Add(sampleKey, sampleData);

            String outputFilePath = @"/Users/russgomez/Projects/MyFirstProject/YouRunShared/iOS/TestFile.txt";

            // Write to TestFile to test behavior
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                outputFile.Write("Sample Key: " + sampleKey + " ");

                if (points[sampleKey] != null)
                {
                    outputFile.WriteLine("worked"); 
                }
                else
                {
                    outputFile.WriteLine("didn't work");
                }
                outputFile.WriteLine(System.IO.Directory.GetCurrentDirectory());
            }
            */
        }
    }
}
