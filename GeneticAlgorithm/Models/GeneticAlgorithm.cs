using AlgoritmoGenetico.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AlgoritmoGenetico.Models
{
    public class GeneticAlgorithm
    {
        public BackgroundWorker Worker;
        public static List<MazeField> Solution;

        public static float CrossoverRate;
        public static float MutationRate;
        public static int PopulationSize;
        public static int MaxNumberOfGenerations;
        public static int CurrentGeneration;
        public static int NumberOfGenes;
        public static int GenerationControl;
        public static bool ElitismEnabled;


        public GeneticAlgorithm(float crossoverRate, float mutationRate, int populationSize, int maxNumberOfGenerations, bool elitismEnabled)
        {
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
            PopulationSize = populationSize;
            MaxNumberOfGenerations = maxNumberOfGenerations;
            ElitismEnabled = elitismEnabled;

            NumberOfGenes = MazeStructure.MazeSolution.Length / 2;

            CurrentGeneration = 0;
        }

        internal void FindMazePath(BackgroundWorker worker, DoWorkEventArgs doWorkEventArgs)
        {
            Worker = worker;

            Population population = new Population(NumberOfGenes, PopulationSize);
            bool hasSolution = false;

            Console.WriteLine($@"Iniciando... Aptidão da solução: {MazeStructure.MazeSolution}");

            while (!hasSolution && CurrentGeneration < MaxNumberOfGenerations)
            {
                CurrentGeneration++;

                population = CreateNewGeneration(population);
                var bestIndividualOfCurrentGeneration = population.Individuals.FirstOrDefault();

                Worker.ReportProgress(0, bestIndividualOfCurrentGeneration);

                Console.WriteLine(
                    $@"Geração {CurrentGeneration} | Aptidão: {population.Individuals[0].Fitness} | Melhor: {population.Individuals[0].Genes}");

                hasSolution = population.Individuals.FirstOrDefault(i => i.HasSolution == true) != null;

                if (Worker.CancellationPending)
                {
                    doWorkEventArgs.Cancel = true;
                    return;
                }
            }
            if (CurrentGeneration == MaxNumberOfGenerations)
            {
                Console.WriteLine(
                    $@"Numero Maximo de Gerações | {population.Individuals[0].Genes} {population.Individuals[0].Fitness}");
            }

            if (hasSolution)
            {
                Solution = population.Individuals.FirstOrDefault().FieldsTraveled;
                Console.WriteLine(
                    $@"Encontrado resultado na geração {CurrentGeneration} | {population.Individuals[0].Genes} (Aptidao: {population.Individuals[0].Fitness})");
            }
        }

        private Population CreateNewGeneration(Population population)
        {
            //nova população do mesmo tamanho da antiga
            Population newPopulation = new Population(population.PopulationSize);
            population.OrderByFitness();

            //se tiver elitismo, mantém o melhor indivíduo da geração atual
            if (ElitismEnabled)
            {
                newPopulation.Individuals.Add(population.Individuals[0]);
            }

            //insere novos indivíduos na nova população, até atingir o tamanho máximo
            while (newPopulation.Individuals.Count < newPopulation.PopulationSize)
            {
                //seleciona os 2 pais por torneio
                Individual[] parents = SelectionByTournament(population);

                Individual[] childrens = new Individual[2];

                //verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
                if (RandomHelper.GenerateRandomDouble() <= CrossoverRate)
                {
                    childrens = Crossover(parents[1], parents[0]);
                }
                else
                {
                    childrens[0] = new Individual(parents[0].Genes);
                    childrens[1] = new Individual(parents[1].Genes);
                }

                //adiciona os filhos na nova geração
                newPopulation.Individuals.AddRange(childrens);
            }

            //ordena a nova população
            newPopulation.OrderByFitness();

            newPopulation.Individuals.RemoveAt(newPopulation.PopulationSize - 1);

            return newPopulation;
        }

        public static Individual[] Crossover(Individual firstIndividual, Individual secondIndividual)
        {
            Individual[] childrens = new Individual[2];

            for (int i = 0; i < 2; i++)
            {
                var newGenes = string.Empty;
                for (int j = 0; j < firstIndividual.Genes.Length; j += 2)
                {
                    if (RandomHelper.GenerateRandomDouble() > 0.5)
                    {
                        newGenes += string.Concat(firstIndividual.Genes[j], firstIndividual.Genes[j + 1]);
                    }
                    else
                    {
                        newGenes += string.Concat(secondIndividual.Genes[j], secondIndividual.Genes[j + 1]);
                    }
                }
                childrens[i] = new Individual(newGenes);
            }

            return childrens;
        }

        public static Individual[] SelectionByTournament(Population population)
        {
            Population newPopulation = new Population(3);

            //seleciona 3 indivíduos aleatóriamente na população
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = RandomHelper.GenerateRandom((int)(population.PopulationSize * 0.2));

                Individual randomIndividual = population.Individuals[randomNumber];

                newPopulation.Individuals.Add(randomIndividual);
            }

            //ordena a população
            newPopulation.OrderByFitness();

            Individual[] parents = new Individual[2];

            //seleciona os 2 melhores deste população
            parents[0] = newPopulation.Individuals[0];
            parents[1] = newPopulation.Individuals[1];

            return parents;
        }
    }
}
