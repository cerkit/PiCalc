using System;

namespace PiCalculusMqttTemplate
{
    public class PiMessage
    {
        public string Type { get; set; }
        public string Channel { get; set; }
        public string Payload { get; set; }
        public Metadata Meta { get; set; }
    }

    public class Metadata
    {
        public string CorrelationId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
