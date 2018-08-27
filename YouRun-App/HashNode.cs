using System;
using System.Collections.Generic;

namespace YouRunApp
{
    // Represents the data for a point on a map
    // A Node is the value in the key-value pairs for the hash table
    class HashNode
    {
        // Class Variables //
        public Coordinate _Location;

        private string _Name;
        private string _Keyword;
        private string _Description;
        private bool   _Runnable;

        // Represents k and v tags found in osm xml file. For us, it keeps track of
        // important attributes about a location
        public struct Tag
        {
            public string Keyword;
            public string Value;
        }

        // Tag List
        private List<Tag> _TagList;


        /* Constructor that sets the coordinates, name, keyword, and description*/
        public HashNode(double lat, double lon,
                    string name, string keyword, string description)
        {
            _Location = new Coordinate(lat, lon);

            _Name = name;
            _Keyword = keyword;
            _Description = description;
            _Runnable = false;
            _TagList = new List<Tag>();
        }

        // Get Methods //
        public Coordinate GetLocation()
        {
            return _Location;
        }

        public string GetName()
        {
            return _Name;
        }

        public string GetKeyword()
        {
            return _Keyword;
        }

        public string GetDescription()
        {
            return _Description;
        }

        public bool GetRunnable()
        {
            return _Runnable;
        }

        public void SetRunnable()
        {
            _Runnable = true;
        }

        public void AddTag(string key, string value)
        {
            Tag tag = new Tag { Keyword = key, Value = value };
            _TagList.Add(tag);
        }

        // Searches for a tag with the given keyword, and returns the struct
        // If tag is not found, it returns null
        public Tag GetTag(string keyword)
        {
            return _TagList.Find(x => x.Keyword.Equals(keyword));
        }


        public List<Tag> GetTagList()
        {
            return _TagList;
        }

    }
}
