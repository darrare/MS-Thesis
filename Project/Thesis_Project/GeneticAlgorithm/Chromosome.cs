using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Chromosome
    {
        public object[] Genes { get; set; }
        public double FitnessScore { get; set; } = 0;

        public Chromosome(object[] genes)
        {
            Genes = genes;
        }
    }
}
