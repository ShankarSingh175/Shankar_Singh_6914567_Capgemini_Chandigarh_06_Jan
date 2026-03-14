using MiddlewareForRequestTracking.Models;

namespace MiddlewareForRequestTracking.Services
{
    public interface IRequestLogService
    {
        void AddLog(RequestLog log);
        List<RequestLog> GetLogs();
    }
}