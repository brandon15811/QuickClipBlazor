using System;
using System.Collections.Generic;

namespace QuickClipBlazor.Services
{
    public class RoundResult
    {
        public int Round { get; set; }
        public DeezerTrack CorrectAnswer { get; set; }
        public DeezerTrack SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class SessionHolder
    {
        public GameSession Session { get; set; }
        
        public event Action OnChange;
        
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
    
    public class GameSession
    {
        public int TotalRounds { get; } = 2;
        public int Round { get; set; } = 1;

        public int Score { get; set; }

        public List<RoundResult> RoundResults { get; } = new List<RoundResult>();
        public DeezerArtist CurrentArtist { get; set; }
    }
}
