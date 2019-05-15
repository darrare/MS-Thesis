using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGeneticAlgorithm.Genetic_Algorithm
{
    class Population
    {
        static Random Rand = new Random();

        public List<Chromosome> Chromosomes = new List<Chromosome>();

        public int GeneCount { get; private set; } = 0;
        public int PopulationSize { get; private set; } = 0;

        public int NumParentsToKeepEachIteration { get; private set; } = 0;

        /// <summary>
        /// public constructor used to generate the first generation
        /// </summary>
        /// <param name="populationSize">Total size of the population
        /// <para />(must be in the form of Size = X + Y where x = y(y-1)/2).
        /// <para />Example: Set Y = 100, therefore X = 100(99)/2 = 4950. X + Y = 5050 where Y is the number of parents we keep per iteration.)
        /// <para />Some valid values: 36, 136, 528, 2080</param>
        /// <param name="defaultGenes">The set of default genes for the first generation</param>
        /// <param name="maxDerivation">Percentage wise, how much can we deviate from the default genes values</param>
        public Population(int populationSize, object[] defaultGenes, float maxDerivation)
        {
            GeneCount = defaultGenes.Length;
            PopulationSize = populationSize;
            NumParentsToKeepEachIteration = CalculateNumParentsToKeepEachIteration(PopulationSize);
            GenerateFirstGeneration(defaultGenes, maxDerivation);
        }

        /// <summary>
        /// Generates the first generation of the genetic algorithm
        /// </summary>
        /// <param name="defaultGenes">The set of default genes for the first generation</param>
        /// <param name="maxDerivation">Percentage wise, how much can we deviate from the default genes values</param>
        private void GenerateFirstGeneration(object[] defaultGenes, float maxDerivation)
        {
            for(int i = 0; i < PopulationSize; i++)
            {
                object[] newGenes = new object[GeneCount];
                for (int j = 0; j < GeneCount; j++)
                {
                    newGenes[j] = defaultGenes[j];
                    //Mutate gene based on type.
                    if (newGenes[j] is float)
                    {
                        float val = Convert.ToSingle(newGenes[j]);
                        newGenes[j] = val + val * ((Rand.NextDouble() * 2) - 1) * maxDerivation;
                    }
                    else if (newGenes[j] is int)
                    {
                        int val = (int)newGenes[j];
                        //Floors all rounding errors
                        newGenes[j] = val + val * ((Rand.NextDouble() * 2) - 1) * maxDerivation;
                    }
                }
                Chromosomes.Add(new Chromosome(newGenes));
            }
        }

        /// <summary>
        /// Private constructor used in generating future generations
        /// </summary>
        /// <param name="geneCount">How many different heuristic variables are considered</param>
        /// <param name="populationSize">Total size of the population</param>
        /// <param name="chromosomes">Chromosomes generated from the previous generation</param>
        private Population(int geneCount, int populationSize, List<Chromosome> chromosomes)
        {
            GeneCount = geneCount;
            PopulationSize = populationSize;
            Chromosomes = chromosomes;
            NumParentsToKeepEachIteration = CalculateNumParentsToKeepEachIteration(PopulationSize);
        }

        /// <summary>
        /// Compute the number of parents to keep each round
        /// </summary>
        /// <param name="total">The total size of our population</param>
        /// <returns>The number of parents to keep each round</returns>
        private int CalculateNumParentsToKeepEachIteration(int total)
        {
            for (int Y = 1; Y < total; Y++)
            {
                int X = total - Y;
                int result = (Y * (Y - 1)) / 2;
                if (X == result)
                    return Y;
                else if (X < result)
                    throw new Exception("Invalid population size, must be in the form of Size = X + Y where x = y(y-1)/2). Example: Set Y = 100, therefore X = 100(99)/2 = 4950. X + Y = 5050 where Y is the number of parents we keep per iteration.");
            }
            throw new Exception("Total must be greater than 2");
        }

        /// <summary>
        /// Runs through each chromosome to calculate its fitness against the provided fitness algorithm
        /// </summary>
        /// <param name="fitnessAlgorithm">The fitness algorithm</param>
        public void CalculateFitness(Func<object[], float> fitnessAlgorithm)
        {
            foreach(Chromosome c in Chromosomes)
            {
                c.FitnessScore = fitnessAlgorithm(c.Genes);
            }
        }

        /// <summary>
        /// Often considered the "Selection" part of the algorithm.
        /// Picks the strongest to survive.
        /// </summary>
        /// <returns>A new population of just the worthy chromosomes</returns>
        public Population RemoveUnworthy()
        {
            if (Chromosomes.Sum(t => t.FitnessScore) == 0)
                throw new Exception("Must calculate fitness before selection");

            Chromosomes = Chromosomes.OrderByDescending(t => t.FitnessScore).ToList();
            return new Population(GeneCount, PopulationSize, Chromosomes.Take(NumParentsToKeepEachIteration).ToList());
        }

        /// <summary>
        /// Often called the "Crossover" part of the algorithm
        /// Picks shares values between each pair of parents to create offsprings
        /// The offspring will be added to the collection of parents to form the next generation
        /// </summary>
        public void MatePopulation()
        {
            //Select a random crossover point that will always include at least 1 gene from each parent
            int crossoverPoint = Rand.Next(1, GeneCount - 1);

            //New list so we can iterate over just the parents
            List<Chromosome> chromosomesToAdd = new List<Chromosome>();

            //Force every parent to breed with every other parent
            //Take the first part of parent 1 up to crossoverPoint
            //Take the last part of parent 2 from crossoverPoint
            for (int i = 0; i < Chromosomes.Count - 1; i++)
            {
                for (int j = i + 1; j < Chromosomes.Count; j++)
                {
                    object[] newGenes = new object[GeneCount];
                    for (int x = 0; x < crossoverPoint; x++)
                        newGenes[x] = Chromosomes[i].Genes[x];
                    for (int y = crossoverPoint; y < GeneCount; y++)
                        newGenes[y] = Chromosomes[j].Genes[y];
                    chromosomesToAdd.Add(new Chromosome(newGenes));
                }
            }
            //Add the new children to the list with the parents
            Chromosomes.AddRange(chromosomesToAdd);
        }

        /// <summary>
        /// Often called the mutation part of the algorithm
        /// Slightly alters some of the chromosomes randomly.
        /// </summary>
        /// <param name="initialSelectionChance">0-1 chance of mutating each chromosome</param>
        /// <param name="individualGeneSelectionChance">0-1 chance of selecting each individual gene from the selected chromosomes</param>
        /// <param name="mutationPercentageMax">0-1 upper bound percentage of how much we can mutate each gene. 0 = no mutation, 1 = can either set to 0 or double</param>
        public void Mutate(float initialSelectionChance, float individualGeneSelectionChance, float mutationPercentageMax)
        {
            if (initialSelectionChance < 0 || initialSelectionChance > 1)
                throw new Exception("Initial selection chance must be between 0 and 1");
            if (individualGeneSelectionChance < 0 || individualGeneSelectionChance > 1)
                throw new Exception("Individual gene selection chance must be between 0 and 1");
            if (mutationPercentageMax < 0 || mutationPercentageMax > 1)
                throw new Exception("Mutation percentage max must be between 0 and 1");

            //For every chromosome
            foreach(Chromosome c in Chromosomes)
            {
                //Roll the dice to see if we should mutate it
                if (Rand.NextDouble() <= initialSelectionChance)
                {
                    //For every gene in chromosome
                    for(int i = 0; i < GeneCount; i++)
                    {
                        //Roll the dice to see if we should mutate it
                        if (Rand.NextDouble() <= individualGeneSelectionChance)
                        {
                            //Mutate gene based on type.
                            if (c.Genes[i] is float)
                            {
                                float val = Convert.ToSingle(c.Genes[i]);
                                c.Genes[i] = val + val * ((Rand.NextDouble() * 2) - 1) * mutationPercentageMax;
                            }
                            else if (c.Genes[i] is int)
                            {
                                int val = (int)c.Genes[i];
                                //Floors all rounding errors
                                c.Genes[i] = val + val * ((Rand.NextDouble() * 2) - 1) * mutationPercentageMax;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates the difference between min and max values based on percentage.
        /// </summary>
        /// <returns>Percentage of max that the min is</returns>
        public float CalculateConvergence()
        {
            return 1 - (Chromosomes.Min(t => t.FitnessScore) / Chromosomes.Max(t => t.FitnessScore));
        }
    }
}
