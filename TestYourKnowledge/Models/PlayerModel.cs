using System;

namespace TestYourKnowledge.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public int Level { get; set; }

        public PlayerModel(string name, int time, int level)
        {
            Name = name;
            TimeStart = DateTime.Now;
            Level = level;
        }
    }
}