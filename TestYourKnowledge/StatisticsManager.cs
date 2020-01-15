using System.Collections.Generic;
using System.Linq;
using TestYourKnowledge.Models;

namespace TestYourKnowledge
{
    internal class StatisticsManager
    {
        public IDictionary<int, SoundStatisticsModel> SoundStatistics = new Dictionary<int, SoundStatisticsModel>();
        public IDictionary<int, ImageStatisticsModel> ImageStatistics = new Dictionary<int, ImageStatisticsModel>();
        public int NumberOfItems { get; private set; }

        public StatisticsManager(IList<int> resourceNumbers)
        {
            NumberOfItems = resourceNumbers.Count;
            SoundStatistics = new Dictionary<int, SoundStatisticsModel>();
            ImageStatistics = new Dictionary<int, ImageStatisticsModel>();
            foreach (var no in resourceNumbers.OrderBy(x => x))
            {
                SoundStatistics.Add(no, new SoundStatisticsModel
                {
                    ClickedCount = 0
                });

                ImageStatistics.Add(no, new ImageStatisticsModel
                {
                    IsCorrect = false
                });
            }
        }

        public int GetCorrectAnswersCount()
        {
            return ImageStatistics.Values.Where(x => x.IsCorrect).ToList().Count;
        }

        public void IncreaseClickedCount(int soundNo)
        {
            if (SoundStatistics.Any(x => x.Key == soundNo))
            {
                SoundStatistics[soundNo].ClickedCount++;
            }
        }

        public void SetImageCorrectness(int imageNo, bool value)
        {
            if (ImageStatistics.Any(x => x.Key == imageNo))
            {
                ImageStatistics[imageNo].IsCorrect = value;
            }
        }
    }
}
