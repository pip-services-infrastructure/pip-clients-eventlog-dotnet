using PipServices.EventLog.Client.Version1;
using PipServices3.Commons.Data;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.EventLog.Client.Test.Version1
{
    public class EventLogClientFixtureV1
    {
        private SystemEventV1 EVENT1 = new SystemEventV1(
            null,
            "test",
            EventLogTypeV1.Restart,
            EventLogSeverityV1.Important,
            "test restart #1",
            null
            );

        private SystemEventV1 EVENT2 = new SystemEventV1(
            null,
            "test",
            EventLogTypeV1.Failure,
            EventLogSeverityV1.Critical,
            "test error",
            null
            );

        private IEventLogClientV1 _client;

        public EventLogClientFixtureV1(IEventLogClientV1 client)
        {
            _client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            // Create one event
            var event1 = await this._client.LogEvent(null, EVENT1);

            Assert.NotNull(event1);
            Assert.Equal(EVENT1.Time , event1.Time);
            Assert.NotNull(event1.Source);
            Assert.Equal(EVENT1.Type, event1.Type);
            Assert.Equal(EVENT1.Message, event1.Message);

            // Create another event
            event1 = await this._client.LogEvent(null, EVENT2);

            Assert.NotNull(event1);
            Assert.Equal(EVENT2.Time, event1.Time);
            Assert.NotNull(event1.Source);
            Assert.Equal(EVENT2.Type, event1.Type);
            Assert.Equal(EVENT2.Message, event1.Message);

            // Get all system events
            var page = await this._client.GetEvents(null, null, null);

            Assert.NotNull(page);
            //Assert.Single(page.Data);
            Assert.Equal(2, page.Data.Count);
        }
    }
}
