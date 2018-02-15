using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> people)
        {
            _people = people;
        }

        public Pair Find(AgeDifference ageDifference)
        {
            var listOfPairs = new List<Pair>();

            for(var i = 0; i < _people.Count - 1; i++)
            {
                for(var j = i + 1; j < _people.Count; j++)
                {
                    var pair = new Pair();
                    if(_people[i].BirthDate < _people[j].BirthDate)
                    {
                        pair.YoungerPerson = _people[i];
                        pair.OlderPerson = _people[j];
                    }
                    else
                    {
                        pair.YoungerPerson = _people[j];
                        pair.OlderPerson = _people[i];
                    }
                    pair.AgeDifference = pair.OlderPerson.BirthDate - pair.YoungerPerson.BirthDate;
                    listOfPairs.Add(pair);
                }
            }

            if(listOfPairs.Count < 1)
            {
                return new Pair();
            }

            Pair thePair = listOfPairs[0];
            foreach(var pair in listOfPairs)
            {
                switch(ageDifference)
                {
                    case AgeDifference.Closest:
                        if(pair.AgeDifference < thePair.AgeDifference)
                        {
                            thePair = pair;
                        }
                        break;

                    case AgeDifference.Furthest:
                        if(pair.AgeDifference > thePair.AgeDifference)
                        {
                            thePair = pair;
                        }
                        break;
                }
            }

            return thePair;
        }
    }
}