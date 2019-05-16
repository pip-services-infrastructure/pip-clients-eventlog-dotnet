using System.Threading.Tasks;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Rpc.Clients;

namespace PipServices.EventLog.Client.Version1
{
    public class EventLogHttpClientV1 : CommandableHttpClient, IEventLogClientV1
    {
        public EventLogHttpClientV1() : base("v1/eventlog")
        { }

        public EventLogHttpClientV1(object config) : base("v1/eventlog")
        {
            if (config != null)
                this.Configure(ConfigParams.FromValue(config));
        }

        public async Task<DataPage<SystemEventV1>> GetEvents(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<SystemEventV1>>(
                    "get_events",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<SystemEventV1> LogEvent(string correlationId, SystemEventV1 _event)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<SystemEventV1>(
                    "log_event",
                    correlationId,
                    new
                    {
                        eventlog = _event
                    }
                    );
            }
        }
    }
}
