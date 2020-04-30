using System.Linq;
using UnityEngine;

namespace Codeavr.RandomExtensions
{
    public static class RandomUtils
    {
        /// <summary>
        /// Get random item using weights array
        /// </summary>
        /// <param name="array">Original array</param>
        /// <param name="weights">Weights for each item in array</param>
        /// <returns>Random weighted item</returns>
        public static T GetWeightedRandomElement<T>(T[] array, float[] weights)
        {
            if (array.Length != weights.Length)
            {
                throw new System.ArgumentException($"{nameof(weights)}.length != {nameof(array)}.length");
            }

            float totalWeight = weights.Sum();

            float roll = Random.value * totalWeight;

            float cursor = 0;

            for (var index = 0; index < array.Length; index++)
            {
                var item = array[index];
                cursor += weights[index];

                if (cursor >= roll)
                {
                    return item;
                }
            }

            return default;
        }

        /// <summary>
        /// Create array with no repetitions in a row
        /// </summary>
        /// <param name="array">Original array</param>
        /// <param name="length">Array size</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static T[] GenerateNonRepeatingRandomArray<T>(T[] array, int length)
        {
            if (length < 2)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }

            if (array.Length < 2)
            {
                throw new System.ArgumentOutOfRangeException(nameof(array.Length));
            }

            var randomArray = new T[length];

            randomArray[0] = array.PickRandom();

            for (int i = 1; i < length; i++)
            {
                do
                {
                    randomArray[i] = array.PickRandom();
                } while (randomArray[i].Equals(randomArray[i - 1]));
            }

            return randomArray;
        }

        /// <summary>
        /// Create looped array with no repetitions in a row
        /// </summary>
        /// <param name="array">Original array</param>
        /// <param name="length">Array size</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static T[] GenerateNonRepeatingRandomLoopedArray<T>(T[] array, int length)
        {
            if (length < 3)
            {
                throw new System.ArgumentOutOfRangeException(nameof(length));
            }

            if (array.Length < 3)
            {
                throw new System.ArgumentOutOfRangeException(nameof(array.Length));
            }

            var randomArray = new T[length];

            randomArray[0] = array.PickRandom();

            for (int i = 1; i < length; i++)
            {
                do
                {
                    randomArray[i] = array.PickRandom();
                } while (randomArray[i].Equals(randomArray[i - 1]) ||
                         randomArray[i].Equals(randomArray[(i + 1) % randomArray.Length]));
            }

            return randomArray;
        }
    }
}