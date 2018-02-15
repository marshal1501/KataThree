using System.Collections.Generic;

namespace Algorithm
{
    public class FurthestPairPicker : ISorter
    {
        public Pair ReturnDesiredPair(List<Pair> listOfPairs)
        {
            Pair thePair = listOfPairs[0];
            foreach (var pair in listOfPairs)
            {
                if (pair.AgeDifference > thePair.AgeDifference)
                {
                    thePair = pair;
                }
            }

            return thePair;
        }
    }
}
