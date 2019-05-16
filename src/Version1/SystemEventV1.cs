using PipServices3.Commons.Data;
using System;
using System.Runtime.Serialization;

namespace PipServices.EventLog.Client.Version1
{
    [DataContract]
    public class SystemEventV1 : IStringIdentifiable
    {
        public SystemEventV1()
        { }

        public SystemEventV1(string correlationId, string source, string type, int severity, string message, StringValueMap details)
        {
            Id = IdGenerator.NextLong();
            Time = new DateTime();
            CorrelationId = correlationId;
            Source = source;
            Type = type ?? EventLogTypeV1.Other;
            Severity = severity | EventLogSeverityV1.Informational;
            Message = message;
            Details = details ?? new StringValueMap();
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }

        [DataMember(Name = "correlation_id")]
        public string CorrelationId { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "severity")]
        public int Severity { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "details")]
        public StringValueMap Details { get; set; }
    }
}
