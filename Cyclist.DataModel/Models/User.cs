using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [DataContract]
    public class User
    {
        public class Favorite
        {
            public String Label { get; set; }
            public String Address { get; set; }
        }

        public enum RideType
        {
            BIKE,
            ELCTRIC_BIKE,
            ELECTRIC_SCOOTER,
            SEGWAY
        };

        [BsonElement("_id")]
        [DataMember(Name = "UserId")]
        public String UserId { get; set; }
        [DataMember(Name = "Password")]
        public String Password { get; set; }
        [DataMember(Name = "Fname")]
        public String Fname { get; set; }
        [DataMember(Name = "Lname")]
        public String Lname { get; set; }
        [DataMember(Name = "Birthday")]
        public DateTime Birthday { get; set; }
        [DataMember(Name = "Ride")]
        public RideType Ride { get; set; }
        [DataMember(Name = "Home")]
        public String Home { get; set; }
        [DataMember(Name = "Work")]
        public String Work { get; set; }
        [DataMember(Name = "Favorites")]
        public LinkedList<Favorite> Favorites = new LinkedList<Favorite>();
    }
}
