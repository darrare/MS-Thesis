using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public delegate double FitnessAlgorithm(object[] genes);

    public static class GeneticAlgorithmClass
    {
        public static Action<int, double, int, double, Tuple<int, List<double>>> UpdateProgressBar { get; set; }

        /// <summary>
        /// Runs the genetic algorithm using the given parameters to solve for a list of Chromosomes that satisfy the problem
        /// </summary>
        /// <param name="populationSize">Total size of the population
        /// <para/>(must be in the form of Size = X + Y where x = y(y-1)/2).
        /// <para/>Example: Set Y = 100, therefore X = 100(99)/2 = 4950. X + Y = 5050 where Y is the number of parents we keep per iteration.)
        /// <para/>Some valid values: 36, 136, 528, 2080</param>
        /// <param name="maxConvergenceDeviationToAccept">0 means every chromosome produces the exact same result
        /// <para/>.01 means the worst chromosome is within 1% of the best chromosome
        /// <para/>(1 - min fitness score / max fitness score)</param>
        /// <param name="defaultGenes">Default gene set, determined by specific CSP</param>
        /// <param name="chanceToSelectEachChromosome">% chance for each chromosome to be selected for mutation</param>
        /// <param name="chanceToMutateEachGene">% chance for each gene in the selected chromosomes to be mutated</param>
        /// <param name="maxGeneMutationDeviation">maximum % amount a genes value can change after a mutation
        /// <para/>.5 means +- 50%, IE: 90 -> 45-135 and 180 -> 90-270
        /// <para/>1 means the mutation will range from 0-double whatever the genes value was</param>
        /// <param name="fitnessAlgorithm">The algorithm provided by the CSP to determine the success of the chromosome</param>
        /// <param name="maxIterationCount">Maximum number of evolutions. Prevents algorithm from running forever when fitness scores won't converge. Default is infinite</param>
        /// <returns>List of chromosomes that was the last set before a convergence was found, ordered from highest to lowest</returns>
        public static List<Chromosome> RunGeneticAlgorithm(
            int populationSize,
            double maxConvergenceDeviationToAccept,
            object[] defaultGenes,
            double chanceToSelectEachChromosome,
            double chanceToMutateEachGene,
            double maxGeneMutationDeviation,
            FitnessAlgorithm fitnessAlgorithm,
            int maxIterationCount)
        {
            //Creates a new population, automatically mutates each gene by up to maxGeneMutationDeviation
            Population pop = new Population(populationSize, defaultGenes, maxGeneMutationDeviation);

            double convergence = 0;
            double averageFitness = 0;
            int i;
            for (i = 0; i < maxIterationCount; i++)
            {
                pop.CalculateFitness(fitnessAlgorithm);
                if ((convergence = pop.CalculateConvergence()) <= maxConvergenceDeviationToAccept)
                {
                    averageFitness = pop.CalculateAverageFitness();
                    UpdateProgressBar?.Invoke((int)(((double)i / (double)maxIterationCount) * 100), convergence, i, averageFitness, new Tuple<int, List<double>>(i, new List<double>()));
                    break;
                }

                if (i % 5 == 0)
                {
                    averageFitness = pop.CalculateAverageFitness();
                    UpdateProgressBar?.Invoke((int)(((double)i / (double)maxIterationCount) * 100), convergence, i, averageFitness, new Tuple<int, List<double>>(i, pop.GetFitnesses()));
                }

                pop.RemoveUnworthy();
                pop.MatePopulation();
                pop.Mutate(chanceToSelectEachChromosome, chanceToMutateEachGene, maxGeneMutationDeviation);
            }
            return pop.Chromosomes.OrderByDescending(t => t.FitnessScore).ToList();
        }
    }
}
