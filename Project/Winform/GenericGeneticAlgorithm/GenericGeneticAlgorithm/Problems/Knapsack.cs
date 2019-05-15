using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGeneticAlgorithm.Problems
{
    class Knapsack
    {
        public int Capacity { get; private set; }
        public KnapsackItem[] Items { get; private set; }
        public float MaximumWeight { get; private set; }
        public float MinimumWeight { get; private set; }
        public float MaximumValue { get; private set; }
        public float MinimumValue { get; private set; }

        public List<KnapsackSolution> Solutions { get; private set; } = new List<KnapsackSolution>();

        /// <summary>
        /// Constructor for a knapsack.
        /// </summary>
        /// <param name="capacity">How much can the knapsack hold</param>
        /// <param name="weights">Weights of items</param>
        /// <param name="values">Values of items</param>
        public Knapsack(int capacity, float[] weights, float[] values)
        {
            Capacity = capacity;
            MaximumWeight = weights.Max();
            MinimumWeight = weights.Min();
            MaximumValue = values.Max();
            MinimumValue = values.Min();

            //Set up items
            Items = new KnapsackItem[weights.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                Items[i] = new KnapsackItem() { Weight = weights[i], Value = values[i] };
            }
        }

        /// <summary>
        /// The fitness is the total value of the load. Weight cannot go over capacity
        /// </summary>
        /// <param name="genes">
        /// [0] = priority of low weight (float)
        /// [1] = priority of high weight (float)
        /// [2] = priority of low value (float)
        /// [3] = priority of high value (float)
        /// </param>
        /// <returns>The value of the load</returns>
        public float Fitness(object[] genes)
        {
            //Use heuristic to sort array such that most wanted items are at the beginning
            Items = Items.OrderByDescending(item =>
                (MaximumWeight - item.Weight) * Convert.ToSingle(genes[0]) +
                item.Weight * Convert.ToSingle(genes[1]) + 
                (MaximumValue - item.Value) * Convert.ToSingle(genes[2]) +
                item.Value * Convert.ToSingle(genes[3])
                ).ToArray();

            List<KnapsackItem> inBag = new List<KnapsackItem>();
            foreach (KnapsackItem item in Items)
            {
                if (inBag.Sum(t => t.Weight) + item.Weight < Capacity)
                {
                    inBag.Add(item);
                }
            }
            return inBag.Sum(t => t.Value);
        }

        public void SetKnapsackSolutionState(List<object[]> genes)
        {
            foreach(object[] geneSet in genes)
            {
                Items = Items.OrderByDescending(item =>
                    (MaximumWeight - item.Weight) * Convert.ToSingle(geneSet[0]) +
                    item.Weight * Convert.ToSingle(geneSet[1]) +
                    (MaximumValue - item.Value) * Convert.ToSingle(geneSet[2]) +
                    item.Value * Convert.ToSingle(geneSet[3])
                    ).ToArray();

                List<KnapsackItem> inBag = new List<KnapsackItem>();
                foreach(KnapsackItem item in Items)
                {
                    if (inBag.Sum(t => t.Weight) + item.Weight < Capacity)
                    {
                        inBag.Add(item);
                    }
                }

                KnapsackSolution solution = new KnapsackSolution() { Items = inBag };
                if (!Solutions.Contains(solution))
                {
                    Solutions.Add(solution);
                }
            }

        }
    }

    /// <summary>
    /// Used for storage
    /// </summary>
    class KnapsackItem
    {
        public float Weight { get; set; }
        public float Value { get; set; }

        /// <summary>
        /// Custom hash. Might run into overflow?!?!?
        /// </summary>
        /// <returns>The calculated hash</returns>
        public override int GetHashCode()
        {
            return Weight.GetHashCode() + Value.GetHashCode();
        }
    }

    class KnapsackSolution : IEquatable<KnapsackSolution>
    {
        public List<KnapsackItem> Items { get; set; }
        public float TotalWeight { get { return Items.Sum(t => t.Weight); } }
        public float TotalValue { get { return Items.Sum(t => t.Value); } }

        public bool Equals(KnapsackSolution other)
        {
            if (other == null)
                return false;
            Items = Items.OrderBy(t => t.Weight).ThenBy(t => t.Value).ToList();
            other.Items = other.Items.OrderBy(t => t.Weight).ThenBy(t => t.Value).ToList();

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Weight != other.Items[i].Weight
                    || Items[i].Value != other.Items[i].Value)
                    return false;
            }
            return true;
        }

        public int GetHashCode(KnapsackSolution obj)
        {
            if (obj == null)
                return 0;
            int hash = 23;
            foreach (KnapsackItem item in obj.Items)
            {
                hash = hash * 31 + item.GetHashCode();
            }
            return hash;
        }
    }
}
