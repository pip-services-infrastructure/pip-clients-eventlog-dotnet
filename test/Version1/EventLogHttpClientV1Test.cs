using PipServices.EventLog.Client.Version1;
using PipServices3.Commons.Config;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.EventLog.Client.Test.Version1
{
    public class EventLogHttpClientV1Test : IDisposable
    {
        private static readonly ConfigParams HttpConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
        );

        private EventLogHttpClientV1 _client;
        private EventLogClientFixtureV1 _fixture;

        public EventLogHttpClientV1Test()
        {
            _client = new EventLogHttpClientV1();
            _client.Configure(HttpConfig);

            _fixture = new EventLogClientFixtureV1(_client);
            _client.OpenAsync(null);
        }

        public void Dispose()
        {
            _client.CloseAsync(null).Wait();
        }

        [Fact]
        public async Task TestCrudOperationsAsync()
        {
            await _fixture.TestCrudOperationsAsync();
        }
    }
}
