using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SigmaBotAPI.Models;

namespace SigmaBotAPI.Services
{
    public interface IStatusService
    {
        public StatusModel GetStatus();
        public bool UpdateStatus(StatusModel model);
        public bool ResetStatus();
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
        public bool ResetStatus()
        {
            try
            {
                statusService = new StatusModel();
                return true;
            } catch (Exception ex)
            {
                return false;
            }

 
        }



    }
}
