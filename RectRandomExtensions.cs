using UnityEngine;

namespace Codeavr.RandomExtensions
{
    public static class RectRandomExtensions
    {
        /// <summary>
        /// Create random point inside of rectangle
        /// </summary>
        public static Vector2 RandomPoint(this Rect rect)
        {
            float x = Random.value * rect.width;
            float y = Random.value * rect.height;

            return rect.min + new Vector2(x, y);
        }
    }
}