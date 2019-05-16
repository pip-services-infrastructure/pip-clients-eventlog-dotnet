using System.Threading.Tasks;
using PipServices3.Commons.Data;

namespace PipServices.EventLog.Client.Version1
{
    public class EventLogNullClientV1 : IEventLogClientV1
    {
        public async Task<DataPage<SystemEventV1>> GetEvents(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<SystemEventV1>());
        }

        public async Task<SystemEventV1> LogEvent(string correlationId, SystemEventV1 _event)
        {
            return await Task.FromResult(new SystemEventV1());
        }
    }
}
