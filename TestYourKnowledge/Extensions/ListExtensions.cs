using System;
using System.Collections.Generic;
using System.Linq;

namespace TestYourKnowledge.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random _rng = new Random();
        public static List<T> Shuffle<T>(this IList<T> list)
        {
            return list.OrderBy(x => _rng.Next()).ToList();
        }
    }
}
