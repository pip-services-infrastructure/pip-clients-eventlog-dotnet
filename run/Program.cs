using PipServices.EventLog.Client.Version1;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using System;

namespace run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );
                var client = new EventLogHttpClientV1();
                client.Configure(config);
                SystemEventV1 EVENT1 = new SystemEventV1(
                    null,
                    "test",
                    EventLogTypeV1.Restart,
                    EventLogSeverityV1.Important,
                    "test restart #1",
                    null
                    );
                SystemEventV1 EVENT2 = new SystemEventV1(
                    null,
                    "test",
                    EventLogTypeV1.Failure,
                    EventLogSeverityV1.Critical,
                    "test error",
                    null
                    );
                client.OpenAsync(correlationId);

                client.LogEvent(correlationId, EVENT1);
                client.LogEvent(correlationId, EVENT2);
                var page = client.GetEvents(null, null, null);
                Console.WriteLine("Get events: ");

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
