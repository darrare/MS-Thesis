using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGeneticAlgorithm.Genetic_Algorithm
{
    class Chromosome
    {
        public object[] Genes { get; private set; }
        public float FitnessScore { get; set; } = 0;

        public Chromosome(object[] genes)
        {
            Genes = genes;
        }
    }
}
