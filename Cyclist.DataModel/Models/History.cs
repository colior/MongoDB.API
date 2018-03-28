using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [Serializable]
    public class History
    {
        [BsonElement("_id")]
        public String Id { get; set; }
        [BsonElement("userId")]
        public String UserId { get; set; }
        public String Destination { get; set; }
        public String StartingPoint { get; set; }
        public DateTime Time { get; set; }
    }
}
