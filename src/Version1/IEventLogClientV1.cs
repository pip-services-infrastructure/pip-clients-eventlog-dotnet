using PipServices3.Commons.Data;
using System.Threading.Tasks;

namespace PipServices.EventLog.Client.Version1
{
    public interface IEventLogClientV1
    {
        Task<DataPage<SystemEventV1>> GetEvents(string correlationId, FilterParams filter, PagingParams paging);
        Task<SystemEventV1> LogEvent(string correlationId, SystemEventV1 _event);
    }
}
