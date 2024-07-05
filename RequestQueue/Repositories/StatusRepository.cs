using SigmaBotAPI.Data;
using SigmaBotAPI.Data.Entities;

namespace SigmaBotAPI.Services
{
    public interface IStatusRepository
    {
        public StatusEntity GetStatus(string guildId);
        public bool CreateStatus(string guildId);
        public bool UpdateStatus(StatusEntity model);
        public bool ResetStatus(string guildId);
    }

    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public StatusEntity GetStatus(string guildId)
        {
            return _context.StatusEntity
                .FirstOrDefault(s => s.GuildId == guildId);
        }

        public bool CreateStatus(string guildId)
        {

            var newStatus = new StatusEntity
            {
                GuildId = guildId,
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
                    statusToReset.LoopMode = LoopModes.None;
                    statusToReset.OnVoiceChannel = false;
                    statusToReset.Volume = 100;
                statusToReset.SkipQueued = false;


                return _context.SaveChanges() > 0;
                     
                }

                return false;
 
        }
    }
}
