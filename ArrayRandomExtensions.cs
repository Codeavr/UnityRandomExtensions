using UnityEngine;

namespace Codeavr.RandomExtensions
{
    public static class ArrayRandomExtensions
    {
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
    }
}