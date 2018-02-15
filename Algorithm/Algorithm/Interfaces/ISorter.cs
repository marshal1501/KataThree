using System.Collections.Generic;
using Algorithm.Domain;

namespace Algorithm.Interfaces
{
    public interface ISorter
    {
        Pair ReturnDesiredPair(List<Pair> listOfPairs);
    }
}
