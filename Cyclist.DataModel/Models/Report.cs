using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Cyclist.DataModel.Models
{
    [DataContract]
    public class Report
    {
        public enum ReportDescription{
            BLOCKED,
            POLICE,
            DISRUPTION,
            UNKNOWN_DANGER
        };

        [BsonElement("_id")]
        [DataMember(Name = "ReportId")]
        public String ReportId { get; set; }
        [BsonElement("userId")]
        [DataMember(Name = "UserID")]
        public String UserID { get; set; }
        [DataMember(Name = "Description")]
        public ReportDescription Description { get; set; }
        [DataMember(Name = "Time")]
        public DateTime Time { get; set; }
        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
