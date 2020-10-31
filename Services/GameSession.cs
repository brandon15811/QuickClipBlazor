using System.Collections.Generic;

namespace QuickClipBlazor.Services
{
    public class GameResults
    {
        public int Round { get; set; }
        public DeezerTrack CorrectAnswer { get; set; }
        public DeezerTrack SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class SessionHolder
    {
        public GameSession Session { get; set; }
    }
    
    public class GameSession
    {
        public int Round { get; set; }

        public int Score { get; set; }

        public List<GameResults> RoundResults { get; set; } = new List<GameResults>();
        
        
    }
}
