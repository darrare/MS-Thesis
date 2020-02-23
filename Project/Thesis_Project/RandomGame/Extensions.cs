using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGame
{
    static class Extensions
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;
            return value;
        }

        public static T Pop<V, T>(this SortedList<V, T> list)
        {
            T val = list.Last().Value;
            list.RemoveAt(list.Count - 1);
            return val;
        }

        /// <summary>
        /// If the key already exists, try incrementing by an incredibly small amount and insert again
        /// </summary>
        public static void SafeAdd(this SortedList<double, Graph> list, double key, Graph value)
        {
            while (list.ContainsKey(key))
            {
                key += .001;
            }
            list.Add(key, value);
        }
    }
}
