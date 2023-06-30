using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGenetico.Models
{

    public class Population
    {
        public List<Individual> Individuals;
        public int PopulationSize;

        //cria uma população com indivíduos aleatória
        public Population(int numberOfGenes, int populationSize)
        {
            PopulationSize = populationSize;
            Individuals = new List<Individual>();

            for (int i = 0; i < populationSize; i++)
            {
                Individuals.Add(new Individual(numberOfGenes));
            }
        }

        //cria uma população com indivíduos sem valor, será composto posteriormente
        public Population(int populationSize)
        {
            PopulationSize = populationSize;
            Individuals = new List<Individual>(populationSize);
        }

        //ordena a população pelo valor de aptidão de cada indivíduo, do maior valor para o menor, assim se eu quiser obter o melhor indivíduo desta população, acesso a posição 0 do array de indivíduos
        public void OrderByFitness() => Individuals = Individuals.OrderByDescending(i => i.Fitness).ToList();
    }
}
