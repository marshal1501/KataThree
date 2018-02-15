using System.Collections.Generic;
using Algorithm.Domain;
using Algorithm.Interfaces;

namespace Algorithm.Services
{
    public class Finder
    {
        private readonly List<Person> _people;
        private readonly IDictionary<AgeDifference, ISorter> _sortingStrategies;

        public Finder(List<Person> people)
        {
            _people = people;
            _sortingStrategies = new Dictionary<AgeDifference, ISorter>
            {
                {AgeDifference.Closest, new ClosestPairPicker()},
                {AgeDifference.Furthest, new FurthestPairPicker()}
            };
        }

        public Pair Find(AgeDifference ageDifference)
        {
            var listOfPairs = GenerateListOfAllPossiblePairsFromPeople();

            if (listOfPairs.Count < 1)
            {
                return new Pair();
            }

            return _sortingStrategies[ageDifference].ReturnDesiredPair(listOfPairs);
        }

        private List<Pair> GenerateListOfAllPossiblePairsFromPeople()
        {
            var listOfPairs = new List<Pair>();

            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var pair = new Pair();
                    if (_people[i].BirthDate < _people[j].BirthDate)
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

            return listOfPairs;
        }
    }
}