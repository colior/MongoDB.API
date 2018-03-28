using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [Serializable]
    public class Report
    {
        public enum ReportDescription{
            BLOCKED,
            POLICE,
            DISRUPTION,
            UNKNOWN_DANGER
        };

        [BsonElement("_id")]
        public String ReportId { get; set; }
        [BsonElement("userId")]
        public String UserID { get; set; }
        public String Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsActive { get; set; }
    }
}
