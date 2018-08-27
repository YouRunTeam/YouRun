using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Collections;
using System.IO;
using System.Diagnostics;

namespace YouRunApp
{
    public class XmlLoader
    {
        static string _path = GlobalConstants.SHEHRYAR_PATH;
        // This class is responsible for loading the necessary information 
        // about a map represented by an xml file into a data structure

        // XmlLoad reads in a xml file representing a map, parses its data and
        // puts it into a tree of nodes (an XmlNodeList), and then returns 
        // hashtable containing the nodes in the tree
        public static Hashtable XmlLoad(string filepath)
        {
            Hashtable points;

            // Create new Xml Document
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();

            //xDoc.Load("/Users/shehryarmalik/Documents/youruntesting/MyFirstProject/YouRunShared/iOS/test2.xml");

            // Load the file as an xml document
            xDoc.Load(_path + "test2.xml");

            // Get elements with tag name "node" and put them in nodeTree
            System.Xml.XmlNodeList nodeTree = xDoc.GetElementsByTagName("node");

            // Check the method loaded at least 1 node
            if (nodeTree.Count == 0)
            {
                Debug.WriteLine("node Tree is NULL");
            }

            // Check if data was read in correctly
            WriteNodesAndTagsToFile(nodeTree);

            // Convert the tree to a hashtable
            points = AddTreeToHashtable(nodeTree);

            return points;

        }

        // AddNodes adds a tree of nodes (an XmlNodeList) into a hashtable 
        // and returns the newly constructed hashtable
        // The function iterates over every node that matched the keyword
        // and reads in the attributes of the tags, such as name, keyword, &
        // lat/lon.
        private static Hashtable AddTreeToHashtable(XmlNodeList nodeTree)
        {
            Hashtable points = new Hashtable();
            Hashtable runnablePoints = new Hashtable();

            // System.Environment.Exit(1);

            HashNode hashNode;

            // Convert nodes in xml tree to Nodes & add them to the hastable
            foreach (XmlNode node in nodeTree)
            {
                // Create node for hash table
                hashNode = ConvertToHashNode(node);


                // If the node was created succssfully, add it to Hashtable
                if (hashNode != null)
                {
                    points.Add(hashNode.GetLocation(), hashNode);
                }
            }

            WriteHashNodesToFile(points);

            // TODO Check if each node is runnable too

            return points;
        }

        // Helper function that converts XmlNodes to Nodes
        // If an XmlNode does not have any attributes then it returns null
        private static HashNode ConvertToHashNode(XmlNode node)
        {
            XmlAttributeCollection attributes;
            HashNode hashNode;

            string nodeName, keyword;
            double lat, lon;


            attributes = node.Attributes;

            if (attributes.Count == 0)
            {
                Debug.WriteLine("No attributes found in XmlNode");
                return null;
            }

            foreach (XmlAttribute attr in attributes)
            {
                Console.Write(attr.Name + ": " + attr.Value + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            // Check if any of the attributes are null

            // Set Lat
            if (attributes[GlobalConstants.OSM_LAT] == null) lat = GlobalConstants.LAT_NOT_FOUND;
            else lat = Double.Parse(attributes[GlobalConstants.OSM_LAT].Value);

            // Set Lon
            if (attributes[GlobalConstants.OSM_LON] == null) lon = GlobalConstants.LON_NOT_FOUND;
            else lon = Double.Parse(attributes[GlobalConstants.OSM_LON].Value);

            // Set Node Name
            if (attributes[GlobalConstants.OSM_NODE_NAME] == null) nodeName = GlobalConstants.NAME_NOT_FOUND;
            else nodeName = attributes[GlobalConstants.OSM_NODE_NAME].Value;

            // Set Keyword
            if (attributes[GlobalConstants.OSM_ATTR_KEYWORD] == null) keyword = GlobalConstants.KEYWORD_NOT_FOUND;
            else keyword = attributes[GlobalConstants.OSM_ATTR_KEYWORD].Value;

            // Create an instance of our Node class
            hashNode = new HashNode(lat, lon, nodeName, keyword,
                                GlobalConstants.DESCRIPTION_NOT_FOUND);

            AddTagsToNode(node, hashNode);

            //WriteTestOutput(hashNode);

            return hashNode;
        }

        // The function checks if the node is runnable. If it is, it sets its
        // runnable attribute to true and adds it to the runnablePoints 
        // hashtable
        private static void CheckRun(HashNode hashNode, Hashtable runnablePoints)
        {
            StreamWriter runnableFile;

            if (hashNode.GetName() == "sidewalk" ||
                hashNode.GetName() == "footway")
            {
                hashNode.SetRunnable();
                runnablePoints.Add(hashNode.GetLocation(), hashNode);

                // The node is runnable, write it to the runnableFile
                runnableFile = new StreamWriter(_path + "/runable.txt", true);
                WriteNodeToFile(hashNode, runnableFile);

                runnableFile.Close();
            }
        }

        // Adds the tags found in XmlNode to the HashNode as keyword and value pairs
        private static void AddTagsToNode(XmlNode node, HashNode hashNode)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                string keyword = child.Attributes[GlobalConstants.OSM_ATTR_KEYWORD].Value;
                string value = child.Attributes[GlobalConstants.OSM_ATTR_VALUE].Value;

                hashNode.AddTag(keyword, value);
            }
        }


        /****************************************************************/
        /*                   File Writing Functions                     */
        /****************************************************************/

        // Write the (lat,lon) nodes with ids to a file with their tags
        // written underneath them
        // Ex:  Parent Node: 42428264 
        //      Lat: 40.7521844
        //      Lon: -73.9875229
        //      Printing Tag: k: crossing v: traffic_signals
        //      Printing Tag: k: highway v: traffic_signals
        //      Printing Tag: k: sloped_curb v: yes
        private static void WriteNodesAndTagsToFile(XmlNodeList parentNodes)
        {
            System.Console.WriteLine("In WriteNodesAndTags()");
            StreamWriter file;

            file = new StreamWriter(_path + "nodesAndTags.txt", false);

            foreach (XmlNode node in parentNodes)
            {
                file.WriteLine("Parent Node: " + node.Attributes["id"].Value);
                file.WriteLine("Lat: " + node.Attributes["lat"].Value);
                file.WriteLine("Lon: " + node.Attributes["lon"].Value);

                // Print child nodes, which are tags
                foreach (XmlNode child in node.ChildNodes)
                {
                    file.Write("Printing Tag: ");

                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        file.Write(attr.Name + ": " + attr.Value + " ");
                    }
                    file.WriteLine();
                }
                file.WriteLine();
            }

            file.Close();

            System.Console.WriteLine("Leaving WriteNodesAndTags()");
        }

        // Same as other WriteNodesAndTagsToFile(), but accepts hashtables
        private static void WriteHashNodesToFile(Hashtable points)
        {
            System.Console.WriteLine("In Write HashNodes()");
            StreamWriter file;

            file = new StreamWriter(_path + "hashNodes.txt", false);

            foreach (DictionaryEntry pair in points)
            {
                HashNode node = (YouRunApp.HashNode)pair.Value;

                file.WriteLine("HashNode: " + node.GetName());
                file.WriteLine("Lat: " + node.GetLocation().GetLatitude());
                file.WriteLine("Lon: " + node.GetLocation().GetLongitude());
                file.WriteLine("Key: " + node.GetKeyword());
                file.WriteLine("Description: " + node.GetDescription());

                // Write tags of node to file
                foreach (HashNode.Tag tag in node.GetTagList())
                {
                    file.WriteLine("Keyword: " + tag.Keyword);
                    file.WriteLine("Value: " + tag.Value);
                }

                file.WriteLine();
            }

            file.Close();

            System.Console.WriteLine("Leaving HashNodes()");
        }

        // Test function that is used to write the test output to a file
        private static void WriteTestOutput(HashNode hashNode)
        {
            StreamWriter file;

            // Create a file stream to test out the node data
            file = new StreamWriter(_path + "test2.txt", true);

            WriteNodeToFile(hashNode, file);

            file.Close();
        }

        // The function writes the given node to a file
        private static void WriteNodeToFile(HashNode hashNode, StreamWriter file)
        {
            file.Write("Name: ");
            file.WriteLine(hashNode.GetName());

            file.Write("Key: ");
            file.WriteLine(hashNode.GetKeyword());

            file.Write("Lat: ");
            file.WriteLine(hashNode.GetLocation().GetLatitude());

            file.Write("Lon: ");
            file.WriteLine(hashNode.GetLocation().GetLongitude());

            file.WriteLine("\n");
        }
    }
}
