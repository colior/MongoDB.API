using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [Serializable]
    public class User
    {
        public class Favorite
        {
            public String Label { get; set; }
            public String Address { get; set; }
        }

        [BsonElement("_id")]
        public String UserId { get; set; }
        public String Password { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public DateTime Birthday { get; set; }
        public String Ride { get; set; }
        public String Home;
        public String Work;
        public LinkedList<Favorite> Favorites = new LinkedList<Favorite>();
    }
}
