using System.Collections.Generic;
using Algorithm.Domain;
using Algorithm.Interfaces;

namespace Algorithm.Services
{
    public class ClosestPairPicker : ISorter
    {
        public Pair ReturnDesiredPair(List<Pair> listOfPairs)
        {
            Pair thePair = listOfPairs[0];
            foreach (var pair in listOfPairs)
            {
                if (pair.AgeDifference < thePair.AgeDifference)
                {
                    thePair = pair;
                }
            }

            return thePair;
        }
    }
}
