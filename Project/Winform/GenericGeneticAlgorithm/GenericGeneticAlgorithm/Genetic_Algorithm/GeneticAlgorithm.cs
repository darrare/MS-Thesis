using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericGeneticAlgorithm.Problems;

namespace GenericGeneticAlgorithm.Genetic_Algorithm
{
    class GeneticAlgorithm
    {
        //Random rand = new Random(8675309);
        Random rand = new Random(1234);
        //Random rand = new Random();

        public GeneticAlgorithm()
        {
            int n = 100;
            float[] weights = new float[n];
            float[] values = new float[n];
            for (int i = 0; i < n; i++)
            {
                weights[i] = (float)(1 + rand.NextDouble() * 1);
                values[i] = (float)(1 + rand.NextDouble() * 1);
            }
            Knapsack knapsack = new Knapsack(50, weights, values);
            Population p = new Population(528, new object[] { 1.0f, 1.0f, 1.0f, 1.0f }, 1f);

            int index = 0;
            while(true)
            {
                p.CalculateFitness(knapsack.Fitness);
                p = p.RemoveUnworthy();
                if (p.CalculateConvergence() < .001f)
                {
                    break;
                }
                p.MatePopulation();
                //25% chance to select a node to mutate. 50% chance to actually mutate each gene. 25% maximum deviation from original (random)
                p.Mutate(.25f, .5f, .25f);
                index++;
            }
            knapsack.SetKnapsackSolutionState(p.Chromosomes.Select(t => t.Genes).ToList());
        }
    }
}
