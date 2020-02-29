using System.Linq;
using UnityEngine;

namespace Codeavr.RandomExtensions
{
    public static class ArrayRandomExtensions
    {
        /// <summary>
        /// Get random item using weights array
        /// </summary>
        /// <param name="array">Original array</param>
        /// <param name="weights">Weights for each item in array</param>
        /// <returns>Random weighted item</returns>
        public static T GetWeightedRandomElement<T>(this T[] array, float[] weights)
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
        /// Return random item
        /// </summary>
        /// <returns>Random item, or default(T)</returns>
        public static T PickRandom<T>(this T[] array)
        {
            if (array == null || array.Length <= 0)
            {
                return default;
            }

            int randomIndex = Random.Range(0, array.Length);

            return array[randomIndex];
        }

        /// <summary>
        /// Create array with no repetitions in a row
        /// </summary>
        /// <param name="array">Original array</param>
        /// <param name="length">Array size</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static T[] RandomizedWithoutRepeats<T>(this T[] array, int length) where T : class
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
                } while (randomArray[i] == randomArray[i - 1] ||
                         randomArray[i] == randomArray[(i + 1) % randomArray.Length]);
            }

            return randomArray;
        }
    }
}