using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [DataContract]
    public class History
    {
        [BsonElement("_id")]
        [DataMember(Name = "Id")]
        public String Id { get; set; }
        [BsonElement("userId")]
        [DataMember(Name = "UserId")]
        public String UserId { get; set; }
        [DataMember(Name = "Destination")]
        public String Destination { get; set; }
        [DataMember(Name = "StartingPoint")]
        public String StartingPoint { get; set; }
        [DataMember(Name = "Time")]
        public DateTime Time { get; set; }
    }
}
