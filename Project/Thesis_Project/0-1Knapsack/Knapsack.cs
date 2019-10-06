using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_1Knapsack
{
    class Knapsack
    {
        public int Capacity { get; private set; }
        public KnapsackItem[] Items { get; private set; }
        public double MaximumWeight { get; private set; }
        public double MinimumWeight { get; private set; }
        public double MaximumValue { get; private set; }
        public double MinimumValue { get; private set; }

        Random rand = new Random();


        /// <summary>
        /// Constructor for a knapsack
        /// </summary>
        /// <param name="capacity">Max weight holdable by knapsack</param>
        /// <param name="minWeight">minimum weight for each object</param>
        /// <param name="maxWeight">maximum weight for each object</param>
        /// <param name="minValue">minimum value for each object</param>
        /// <param name="maxValue">maximum value for each object</param>
        /// <param name="count">number of objects we need to find optimal solution for</param>
        /// <param name="seed">(OPTIONAL) randomized seed</param>
        public Knapsack(int capacity, double minWeight, double maxWeight, double minValue, double maxValue, int count, int seed = 0)
        {
            Capacity = capacity;
            MaximumWeight = maxWeight;
            MinimumWeight = minWeight;
            MaximumValue = maxValue;
            MinimumValue = minValue;

            if (seed != 0)
                rand = new Random(seed);

            //Set up items
            Items = new KnapsackItem[count];
            for (int i = 0; i < count; i++)
            {
                Items[i] = new KnapsackItem()
                {
                    Weight = (rand.NextDouble() * (maxWeight - minWeight) + minWeight),
                    Value = (rand.NextDouble() * (maxValue - minValue) + minValue)
                };
            }
        }

        /// <summary>
        /// The fitness is the total value of the load. Weight cannot go over capacity
        /// </summary>
        /// <param name="genes">
        /// [0] = priority of low weight (double)
        /// [1] = priority of high weight (double)
        /// [2] = priority of low value (double)
        /// [3] = priority of high value (double)
        /// </param>
        /// <returns>The value of the load</returns>
        public double Fitness(object[] genes)
        {
            //Use heuristic to sort array such that most wanted items are at the beginning
            List<KnapsackItem> inBag = new List<KnapsackItem>();
            foreach (KnapsackItem item in Items.OrderByDescending(item =>
                (MaximumWeight - item.Weight) * Convert.ToDouble(genes[0]) +
                item.Weight * Convert.ToDouble(genes[1]) +
                (MaximumValue - item.Value) * Convert.ToDouble(genes[2]) +
                item.Value * Convert.ToDouble(genes[3])))
            {
                if (inBag.Sum(t => t.Weight) + item.Weight < Capacity)
                {
                    inBag.Add(item);
                }
            }
            return inBag.Sum(t => t.Value);
        }

        /// <summary>
        /// Generates a list of all solutions based on the converged generation
        /// </summary>
        /// <param name="genes">The converged genes</param>
        public List<KnapsackSolution> GetKnapsackSolutionsFromGenes(List<object[]> genes)
        {
            List<KnapsackSolution> solutions = new List<KnapsackSolution>();
            foreach (object[] geneSet in genes)
            {
                List<KnapsackItem> inBag = new List<KnapsackItem>();
                foreach (KnapsackItem item in Items.OrderByDescending(item =>
                    (MaximumWeight - item.Weight) * Convert.ToDouble(geneSet[0]) +
                    item.Weight * Convert.ToDouble(geneSet[1]) +
                    (MaximumValue - item.Value) * Convert.ToDouble(geneSet[2]) +
                    item.Value * Convert.ToDouble(geneSet[3])
                    ))
                {
                    if (inBag.Sum(t => t.Weight) + item.Weight < Capacity)
                    {
                        inBag.Add(item);
                    }
                }

                KnapsackSolution solution = new KnapsackSolution() { Items = inBag, Genes = geneSet };
                if (!solutions.Contains(solution))
                {
                    solutions.Add(solution);
                }
            }
            return solutions;
        }
    }

    /// <summary>
    /// Used for storage
    /// </summary>
    public class KnapsackItem
    {
        public double Weight { get; set; }
        public double Value { get; set; }

        /// <summary>
        /// Custom hash. Might run into overflow?!?!?
        /// </summary>
        /// <returns>The calculated hash</returns>
        public override int GetHashCode()
        {
            return Weight.GetHashCode() + Value.GetHashCode();
        }
    }

    public class KnapsackSolution : IEquatable<KnapsackSolution>
    {
        public List<KnapsackItem> Items { get; set; }
        public double TotalWeight { get { return Items.Sum(t => t.Weight); } }
        public double TotalValue { get { return Items.Sum(t => t.Value); } }
        public object[] Genes { get; set; }

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
