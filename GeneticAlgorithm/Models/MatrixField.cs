using AlgoritmoGenetico.Enums;
using System.Collections.Generic;
using System.Windows.Controls;

namespace AlgoritmoGenetico.Models
{
    public class MazeField
    {
        public Border CanvasField { get; set; }
        public List<Direction> WallDirections { get; private set; }
        public List<Direction> PossibleDirections { get; private set; }
        public Coordinate Coordinate { get; private set; }
        public int Index { get; private set; }

        public MazeField(string wallDirections, Coordinate coordinate, int index)
        {
            InitializeFields(index, coordinate);

            AddWallDirections(wallDirections);
            AddPossibleDirections();
        }

        private void InitializeFields(int index, Coordinate coordinate)
        {
            Index = index;
            Coordinate = coordinate;
            WallDirections = new List<Direction>();
        }

        private void AddWallDirections(string wallDirections)
        {
            var directions = wallDirections.Split(',');
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "N":
                        WallDirections.Add(Direction.North);
                        break;

                    case "S":
                        WallDirections.Add(Direction.South);
                        break;

                    case "L":
                        WallDirections.Add(Direction.East);
                        break;

                    case "O":
                        WallDirections.Add(Direction.West);
                        break;

                    default:
                        WallDirections.Add(Direction.None);
                        break;
                }
            }
        }

        private void AddPossibleDirections()
        {
            if (Coordinate.Y > 0 && Coordinate.X > 0 && Coordinate.Y < MazeStructure.Columns - 1 && Coordinate.X < MazeStructure.Rows - 1)
            {
                PossibleDirections = new List<Direction>
                    {
                        Direction.North,
                        Direction.West,
                        Direction.East,
                        Direction.South
                    };
            }
            else if (Coordinate.Y == 0 && Coordinate.X > 0 && Coordinate.X < MazeStructure.Rows - 1)
            {
                PossibleDirections = new List<Direction>
                    {
                        Direction.North,
                        Direction.East,
                        Direction.South
                    };
            }
            else if (Coordinate.Y == MazeStructure.Columns - 1 && Coordinate.X > 0 && Coordinate.X < MazeStructure.Rows - 1)
            {
                PossibleDirections = new List<Direction>
                    {
                        Direction.North,
                        Direction.South,
                        Direction.West
                    };

            }
            else if (Coordinate.X == 0 && Coordinate.Y > 0 && Coordinate.Y < MazeStructure.Columns - 1)
            {
                PossibleDirections = new List<Direction>
                    {
                        Direction.East,
                        Direction.West,
                        Direction.South
                    };
            }
            else if (Coordinate.X == MazeStructure.Rows - 1 && Coordinate.Y > 0 && Coordinate.Y < MazeStructure.Columns - 1)
            {
                PossibleDirections = new List<Direction>
                    {
                        Direction.North,
                        Direction.West,
                        Direction.East
                    };
            }
            else
            {
                if (Coordinate.X == 0 && Coordinate.Y == 0)
                {
                    PossibleDirections = new List<Direction>
                    {
                        Direction.East,
                        Direction.South
                    };
                }
                else if (Coordinate.X == 0 && Coordinate.Y == MazeStructure.Columns - 1)
                {
                    PossibleDirections = new List<Direction>
                    {
                        Direction.West,
                        Direction.South
                    };
                }
                else if (Coordinate.X == MazeStructure.Rows - 1 && Coordinate.Y == 0)
                {
                    PossibleDirections = new List<Direction>
                    {
                        Direction.North,
                        Direction.East
                    };
                }
                else if (Coordinate.X == MazeStructure.Rows - 1 && Coordinate.Y == MazeStructure.Columns - 1)
                {
                    PossibleDirections = new List<Direction>
                    {
                        Direction.West,
                        Direction.North
                    };
                }
            }
        }
    }
}
