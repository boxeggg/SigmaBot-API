
using SigmaBotAPI.Data;
using SigmaBotAPI.Data.Entities;
using SQLitePCL;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace SigmaBotAPI.Services
{
    public interface ISongRepository
    {
        List<SongEntity> GetAllRequests(string guildId);
        SongEntity GetLastRequest(string guildId);
        bool AddRequest(SongEntity request);
        bool AddPlaylist(ICollection<SongEntity> playlist);
        bool RemoveLastRequest(string guildId);
        int RequestsCount(string guildId);
        bool ClearQueue(string guildId);
    }

    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _context;

        public SongRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<SongEntity> GetAllRequests(string guildId)
        {
            return  _context.SongEntity
                .Where(s => s.GuildId == guildId)
                .ToList();
            
        }

        public SongEntity GetLastRequest(string guildId)
        {
            return _context.SongEntity
                .Where(s => s.GuildId == guildId)
                .OrderBy(s => s.Id)
                .FirstOrDefault();
        }

        public bool AddRequest(SongEntity request)
        {
            try
            {
                
                _context.SongEntity.Add(request);
                return _context.SaveChanges() > 0;
                 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddPlaylist(ICollection<SongEntity> playlist)
        {
            try
            {
                foreach (var song in playlist)
                {
                    _context.SongEntity.Add(song);
                }
                return _context.SaveChanges() > 0;

            }
            catch (Exception) { 
                return false;
            }
        }

        public bool RemoveLastRequest(string guildId)
        {
            var lastRequest = GetLastRequest(guildId);
            if (lastRequest != null)
            {
                _context.SongEntity.Remove(lastRequest);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public int RequestsCount(string guildId)
        {
            return _context.SongEntity
                .Count(s => s.GuildId == guildId);
        }

        public bool ClearQueue(string guildId)
        {
            try
            {
                var songsToRemove = _context.SongEntity
                    .Where(s => s.GuildId == guildId)
                    .ToList();

                _context.SongEntity.RemoveRange(songsToRemove);
                return _context.SaveChanges() > 0;
                
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
