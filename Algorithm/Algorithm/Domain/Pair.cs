using System;

namespace Algorithm.Domain
{
    public class Pair
    {
        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}