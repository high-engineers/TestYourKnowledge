using System;
using System.Collections.Generic;

namespace TestYourKnowledge.Models
{
    public class PlayerResultModel
    {
        public string Name { get; set; }
        public int TimeResult { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public DateTime TimeStart { get; set; }
        public IList<SoundClickedCorrectPairModel> SoundResults { get; set; }
    }
}