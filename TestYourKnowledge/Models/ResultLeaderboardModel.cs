using System;

namespace TestYourKnowledge.Models
{
    public class ResultLeaderboardModel
    {
        public int No { get; set; }
        public string Name { get; set; }
        public int TimeResult { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public DateTime TimeStart { get; set; }
    }
}
