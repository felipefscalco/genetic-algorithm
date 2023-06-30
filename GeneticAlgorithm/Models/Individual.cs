using AlgoritmoGenetico.Enums;
using AlgoritmoGenetico.Helpers;
using System.Collections.Generic;

namespace AlgoritmoGenetico.Models
{
    public class Individual
    {
        private readonly List<string> PossibleMoves = new List<string>(4) { "00", "01", "10", "11" };
        public List<MazeField> FieldsTraveled { get; set; }
        public string Genes { get; set; }
        public int WallsHit { get; set; }
        public int Fitness { get; set; }
        public int RepeatedFields { get; set; }
        public bool HasImpossibleMove { get; set; }
        public bool HasSolution => VerifyIfHasSolution();


        //gera um indivíduo aleatório
        public Individual(int numberOfGenes)
        {
            for (int i = 0; i < numberOfGenes; i++)
            {
                int index = RandomHelper.GenerateRandom(4);
                Genes += PossibleMoves[index];
            }

            GenerateFitness();
        }

        //cria um indivíduo com os genes definidos
        public Individual(string genes)
        {
            Genes = genes;

            //se for mutar, cria um gene aleatório
            if (RandomHelper.GenerateRandomDouble() <= GeneticAlgorithm.MutationRate)
            {
                List<int> randomNumbers = RandomHelper.GenerateRandomNumbers(1);

                var newGene = string.Empty;

                for (int i = 0; i < GeneticAlgorithm.NumberOfGenes; i++)
                {
                    if (randomNumbers.Contains(i))
                    {
                        var newPossibleMoves = new List<string>(PossibleMoves);
                        var geneMove = string.Concat(genes[i * 2], genes[i * 2 + 1]);

                        newPossibleMoves.Remove(geneMove);

                        newGene += newPossibleMoves[RandomHelper.GenerateRandom(newPossibleMoves.Count)];
                    }
                    else
                    {
                        newGene += string.Concat(genes[i * 2], genes[i * 2 + 1]);
                    }
                }

                Genes = newGene;
            }

            GenerateFitness();
        }

        //gera o valor de aptidão, será calculada pelo número de bits do gene iguais ao da solução
        private void GenerateFitness()
        {
            //beginning of maze
            MazeField currentField = MazeStructure.GetMazeFieldFromCoordinate(9, 0);

            FieldsTraveled = new List<MazeField>();

            for (int i = 0; i < MazeStructure.MazeSolution.Length; i += 2)
            {
                string move = string.Concat(Genes[i], Genes[i + 1]);
                Direction direction = GetDirectionFromMove(move);

                if (currentField.PossibleDirections.Contains(direction))
                {
                    if (currentField.WallDirections.Contains(direction))
                    {
                        WallsHit++;
                    }

                    if (FieldsTraveled.Contains(currentField))
                    {
                        RepeatedFields++;
                    }
                    else
                    {
                        FieldsTraveled.Add(currentField);
                    }

                    currentField = MazeStructure.GetNextMazeFieldByDirection(currentField.Coordinate, direction);
                }
                else
                {
                    if (FieldsTraveled.Contains(currentField))
                    {
                        RepeatedFields++;
                    }
                    else
                    {
                        FieldsTraveled.Add(currentField);
                    }

                    Fitness -= 200;
                    HasImpossibleMove = true;
                }
            }

            Fitness -= RepeatedFields;
            Fitness -= WallsHit;
            //Fitness -= 26 - FieldsTraveled.Count;
            //if (FieldsTraveled.Count < 26)
            //{
            //    Fitness -= 5;
            //}

            var individualLastField = FieldsTraveled[FieldsTraveled.Count - 1];
            //if (individualLastField == MazeStructure.GetMazeFieldFromCoordinate(0, 9))
            //{
            //    Fitness += 10;
            //}

            GetPenaltyFromDistance(individualLastField);

            //CompareGenesWithBestSolution();
        }

        private void GetPenaltyFromDistance(MazeField individualLastField)
        {
            var penalty = MazeStructure.LastField.Coordinate.X - individualLastField.Coordinate.X;
            penalty += individualLastField.Coordinate.Y - MazeStructure.LastField.Coordinate.Y;

            Fitness += penalty;
        }

        private void CompareGenesWithBestSolution()
        {
            for (int i = 0; i < Genes.Length; i += 2)
            {
                var geneMove = string.Concat(Genes[i], Genes[i + 1]);
                var bestMove = string.Concat(MazeStructure.MazeSolution[i], MazeStructure.MazeSolution[i + 1]);
                if (geneMove.Equals(bestMove))
                {
                    Fitness += 10;
                }
                else
                {
                    Fitness -= 10;
                }
            }
        }

        private Direction GetDirectionFromMove(string move)
        {
            switch (move)
            {
                case "00":
                    return Direction.East;

                case "01":
                    return Direction.North;

                case "10":
                    return Direction.West;

                case "11":
                    return Direction.South;

                default:
                    return Direction.None;
            }
        }

        private bool VerifyIfHasSolution()
        {
            var lastField = FieldsTraveled[FieldsTraveled.Count - 1];
            var exitField = MazeStructure.GetMazeFieldFromCoordinate(0, 9);

            return WallsHit == 0 && !HasImpossibleMove && lastField == exitField;
        }
    }
}
