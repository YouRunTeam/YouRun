using System;
using System.Collections;
namespace YouRunApp
{
    public class NodePrioritySetup
    {
        public Hashtable AssignPrioritiesToNodes(Hashtable nodes)
        {
            //Hashtable poiPoints = new Hashtable();
            Hashtable poiBuckets = new Hashtable();

            // Loop through all nodes searching for points of interest,
            // and group nodes that represent the same point of interest
            // into point of interest buckets (poiBuckets)
            foreach (HashNode currentNode in nodes)
            {
                if (IsPointOfInterest(currentNode))
                {
                    // if (node's point of interest is new)
                    // create new poiBucket for that point of interest
                    // add node to the poi bucket
                    // add the new poibucket to poiBuckets

                    // else
                    // add the node to an existing poi bucket
                }
            }

            // Loop through all the poibuckets (i.e. all points of interests)
            // for each poibucket
            // count the number of nodes that correspond to that poi
            // determine the relevant priorities associated with it

            // Loop through all the poibuckets
            // for each poibucket node
            // Loop through the nodes surrounding it
            // if node exists, is runnable, and isn't another poi node (no duplicates) 
            // Add 1/poibucket.count as a weight for each of the 
            // poibucket's relevant priorities of that runnable node
            // i.e. if relevant priorities of poibucket are water and hills
            // update water and hills priorities of runnable node with 1/poibucket.count

            return new Hashtable();

            //
        }

        private static bool IsPointOfInterest(HashNode node)
        {
            //runcalculations on point of interest?


            return false;
        }
    }
}
