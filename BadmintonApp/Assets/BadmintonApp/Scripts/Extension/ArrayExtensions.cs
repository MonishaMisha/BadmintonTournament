using System.Collections.Generic;
using UnityEngine;

namespace com.badmintonApp.BadmintonApp.Scripts
{
    public static class ArrayExtensions
    {
        public static List<List<T>> GetCombinations<T>(this T[] array , int n)
        {
            var result = new List<List<T>>();
            Recurse(array, 0, new List<T>(), n, result);
            return result;
        }

        private static void Recurse<T>(T[] array, int index, List<T> current, int n, List<List<T>> result)
        {
            if (current.Count == n)
            {
                result.Add(new List<T>(current));
                return;
            }

            for (int i = index; i < array.Length; i++)
            {
                current.Add(array[i]);
                Recurse(array, i + 1, current, n, result);
                current.RemoveAt(current.Count - 1);
            }
        }
        
        public static void Shuffle<T>(this List<T> array)
        {
            int n = array.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int j = Random.Range(i, n); // inclusive i, exclusive n
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}