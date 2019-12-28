namespace Domino.Models
{
    internal class Person
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }

        public Person(string name, int time, int level)
        {
            Name = name;
            Time = time;
            Level = level;
        }
    }
}