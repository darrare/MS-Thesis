using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericGeneticAlgorithm.Problems;

namespace GenericGeneticAlgorithm
{
    class Extensions
    {
        public class KnapsackItemArrayComparer : IEqualityComparer<KnapsackItem[]>
        {
            public bool Equals(KnapsackItem[] x, KnapsackItem[] y)
            {
                if (x == null || y == null)
                    return false;
                x = x.OrderBy(t => t.Weight).ThenBy(t => t.Value).ToArray();
                y = y.OrderBy(t => t.Weight).ThenBy(t => t.Value).ToArray();

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i].Weight != y[i].Weight
                        || x[i].Value != y[i].Value)
                        return false;
                }
                return true;
            }

            public int GetHashCode(KnapsackItem[] obj)
            {
                if (obj == null)
                    return 0;
                int hash = 23;
                foreach (KnapsackItem item in obj)
                {
                    hash = hash * 31 + item.GetHashCode();
                }
                return hash;
            }
        }

    }
}
