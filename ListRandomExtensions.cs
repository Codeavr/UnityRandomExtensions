using System.Collections.Generic;
using UnityEngine;

namespace Codeavr.RandomExtensions
{
    public static class ListRandomExtensions
    {
        /// <summary>
        /// Remove and return random item
        /// </summary>
        /// <returns>Random item, or default(T)</returns>
        public static T PopRandom<T>(this List<T> list)
        {
            int index = Random.Range(0, list.Count);

            T item = list[index];
            list.RemoveAt(index);

            return item;
        }

        /// <summary>
        /// Return random item
        /// </summary>
        /// <returns>Random item, or default(T)</returns>
        public static T PickRandom<T>(this List<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return default;
            }

            int randomIndex = Random.Range(0, list.Count);

            return list[randomIndex];
        }

        /// <summary>
        /// Return random item
        /// </summary>
        /// <returns>Random item, or default(T)</returns>
        public static T PickRandom<T>(this IReadOnlyList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return default;
            }

            int randomIndex = Random.Range(0, list.Count);

            return list[randomIndex];
        }
    }
}