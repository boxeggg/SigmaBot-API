using SigmaBotAPI.Data;
using SigmaBotAPI.Data.Entities;

namespace SigmaBotAPI.Services
{
    public interface IStatusRepository
    {
        public List<StatusEntity> GetAllStatuses();
        public StatusEntity GetStatus(string guildId);
        public bool CreateStatus(string guildId, string guildName);
        public bool UpdateStatus(StatusEntity model);
        public bool ResetStatus(string guildId);
        public bool DeleteStatus(string guildId);
    }

    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<StatusEntity> GetAllStatuses()
        {
            return _context.StatusEntity.ToList();

        }
        public StatusEntity GetStatus(string guildId)
        {
            return _context.StatusEntity
                .FirstOrDefault(s => s.GuildId == guildId);
        }

        public bool CreateStatus(string guildId, string guildName)
        {

            var newStatus = new StatusEntity
            {
                GuildId = guildId,
                GuildName = guildName,
                LoopMode = LoopModes.None,
                OnVoiceChannel = false,
                Volume = 100,
                SkipQueued = false,
            };

            _context.StatusEntity.Add(newStatus);
            return _context.SaveChanges() > 0;

        }

        public bool UpdateStatus(StatusEntity model)
        {
            _context.StatusEntity.Update(model);
            return _context.SaveChanges() > 0;

        }

        public bool ResetStatus(string guildId)
        {

            var statusToReset = _context.StatusEntity
                .FirstOrDefault(s => s.GuildId == guildId);

            if (statusToReset != null)
            {
                statusToReset.GuildId = guildId;
                statusToReset.GuildName = statusToReset.GuildName;
                statusToReset.LoopMode = LoopModes.None;
                statusToReset.OnVoiceChannel = false;
                statusToReset.Volume = 100;
                statusToReset.SkipQueued = false;


                _context.Update(statusToReset);
                return _context.SaveChanges() > 0;

            }

            return false;

        }
        public bool DeleteStatus(string guildId)
        {
            var statusToReset = _context.StatusEntity
             .FirstOrDefault(s => s.GuildId == guildId);
            if (statusToReset != null) _context.Remove(statusToReset);
            return _context.SaveChanges() > 0;

            

        }
    }
}
