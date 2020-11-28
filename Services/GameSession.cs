using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace QuickClipBlazor.Services
{
    public class RoundResult
    {
        public int Round { get; set; }
        public DeezerTrack CorrectAnswer { get; set; }
        public DeezerTrack SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class SessionManager
    {
        private readonly IMemoryCache _cache;

        public SessionManager(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public bool LoadSession(Guid sessionId)
        {
            if (_cache.TryGetValue(sessionId, out GameSession session))
            {
                Session = session;
                NotifyStateChanged();
                return true;
            }

            return false;
        }

        public void InitSession(Guid sessionId)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromMinutes(15));
            
            _cache.Set(sessionId, Session, cacheEntryOptions);
        }

        public void ClearSession(Guid sessionId)
        {
            _cache.Remove(sessionId);
            Session = null;
        }

        public GameSession Session { get; set; }
        
        public event Action OnChange;
        
        public void NotifyStateChanged()
        {
            OnChange?.Invoke();
            if (Session != null)
            {
                //Refresh Session Entry so it doesn't expire
                _cache.Get(Session.SessionId);
            }
        }
    }
    
    public class GameSession
    {
        public int TotalRounds { get; } = 2;
        public int Round { get; set; } = 1;
        public int Score { get; set; }

        public bool ReadyForNextRound { get; set; }

        public List<RoundResult> RoundResults { get; } = new List<RoundResult>();
        public DeezerArtist CurrentArtist { get; set; }

        public List<DeezerTrack> Choices { get; set; } = new List<DeezerTrack>();

        public DeezerTrack CorrectAnswer { get; set; }

        public List<DeezerTrack> Songs { get; set; }
        
        public Guid SessionId { get; set; }
        
        public bool GameOver { get; set; }
    }
}
