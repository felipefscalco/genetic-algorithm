using AlgoritmoGenetico.Models;
using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico.Helpers
{
    public static class RandomHelper
    {
        private static Random _random;
        private static Random Random
        {
            get
            {
                if (_random == null)
                {
                    _random = new Random();
                }

                return _random;
            }
            set
            {
                _random = value;
            }

        }
        public static int GenerateRandom(int max)
        {
            var random = Random.Next(max);
            return random;
        }

        public static double GenerateRandomDouble()
        {
            var random = Random.NextDouble();
            return random;
        }

        public static List<int> GenerateRandomNumbers(int numberOfRandomNumbers)
        {
            var randomNumbers = new List<int>();
            while (randomNumbers.Count < numberOfRandomNumbers)
            {
                var randomNum = GenerateRandom(GeneticAlgorithm.NumberOfGenes);
                if (!randomNumbers.Contains(randomNum))
                {
                    randomNumbers.Add(randomNum);
                }
            }

            return randomNumbers;
        }
    }
}
