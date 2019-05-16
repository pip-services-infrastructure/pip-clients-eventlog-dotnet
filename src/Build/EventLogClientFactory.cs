using PipServices.EventLog.Client.Version1;
using PipServices3.Commons.Refer;
using PipServices3.Components.Build;

namespace PipServices.EventLog.Client.Build
{
    public class EventLogClientFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services-eventlog", "factory", "default", "default", "1.0");
        public static Descriptor NullClientDescriptor = new Descriptor("pip-services-eventlog", "client", "null", "*", "1.0");
        public static Descriptor HttpClientDescriptor = new Descriptor("pip-services-eventlog", "client", "http", "*", "1.0");

        public EventLogClientFactory()
        {
            RegisterAsType(NullClientDescriptor, typeof(EventLogNullClientV1));
            RegisterAsType(HttpClientDescriptor, typeof(EventLogHttpClientV1));
        }
    }
}
