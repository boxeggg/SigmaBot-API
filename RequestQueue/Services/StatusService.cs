using Microsoft.AspNetCore.JsonPatch;
using RequestQueue.Models;

namespace RequestQueue.Services
{
    public interface IStatusService
    {
        public StatusModel GetStatus();
        public bool UpdateStatus(StatusModel model);
    }
    public class StatusService : IStatusService
    {
        private StatusModel statusService = new StatusModel();
        public StatusModel GetStatus()
        {
            return statusService;
        }
        public bool UpdateStatus(StatusModel model)
        {
            try
            {
                statusService = model;
                return true;
            } 
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}
