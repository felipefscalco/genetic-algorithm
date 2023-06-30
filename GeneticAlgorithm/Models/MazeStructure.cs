using AlgoritmoGenetico.Enums;
using AlgoritmoGenetico.Properties;
using System.Collections.Generic;
using System.Linq;

namespace AlgoritmoGenetico.Models
{
    public class MazeStructure
    {
        public static string MazeSolution = "010101000001010001101010010000000000010100000011000111";

        public static MazeField LastField;

        public static MazeField[,] MazeFields;
        public static int Columns { get; private set; }
        public static int Rows { get; private set; }
        public static int SquareSize { get; private set; }
        public static List<Direction> AllWallDirections { get; private set; }

        public MazeStructure(int columns, int rows, int squareSize)
        {
            Columns = columns;
            Rows = rows;
            SquareSize = squareSize;

            AllWallDirections = new List<Direction>
            {
                Direction.North,
                Direction.South,
                Direction.West,
                Direction.East
            };

            MazeFields = CreateFields();

            LastField = GetMazeFieldFromCoordinate(0, 9);
        }

        public static MazeField GetMazeFieldFromCoordinate(int row, int column)
        {
            return MazeFields[row, column];
        }

        public static MazeField GetNextMazeFieldByDirection(Coordinate coordinate, Direction direction)
        {
            if (coordinate.Y > 0 && coordinate.X > 0 && coordinate.Y < Columns - 1 && coordinate.X < Rows - 1)
            {
                switch (direction)
                {
                    case Direction.North:
                        return MazeFields[coordinate.X - 1, coordinate.Y];
                    case Direction.South:
                        return MazeFields[coordinate.X + 1, coordinate.Y];
                    case Direction.West:
                        return MazeFields[coordinate.X, coordinate.Y - 1];
                    case Direction.East:
                        return MazeFields[coordinate.X, coordinate.Y + 1];
                }
            }
            else if (coordinate.Y == 0 && coordinate.X > 0 && coordinate.X < Rows - 1)
            {
                switch (direction)
                {
                    case Direction.North:
                        return MazeFields[coordinate.X - 1, coordinate.Y];
                    case Direction.South:
                        return MazeFields[coordinate.X + 1, coordinate.Y];
                    case Direction.East:
                        return MazeFields[coordinate.X, coordinate.Y + 1];
                }
            }
            else if (coordinate.Y == Columns - 1 && coordinate.X > 0 && coordinate.X < Rows - 1)
            {
                switch (direction)
                {
                    case Direction.North:
                        return MazeFields[coordinate.X - 1, coordinate.Y];
                    case Direction.West:
                        return MazeFields[coordinate.X, coordinate.Y - 1];
                    case Direction.South:
                        return MazeFields[coordinate.X + 1, coordinate.Y];
                }
            }
            else if (coordinate.X == 0 && coordinate.Y > 0 && coordinate.Y < Columns - 1)
            {
                switch (direction)
                {
                    case Direction.West:
                        return MazeFields[coordinate.X, coordinate.Y - 1];
                    case Direction.South:
                        return MazeFields[coordinate.X + 1, coordinate.Y];
                    case Direction.East:
                        return MazeFields[coordinate.X, coordinate.Y + 1];
                }
            }
            else if (coordinate.X == Rows - 1 && coordinate.Y > 0 && coordinate.Y < Columns - 1)
            {
                switch (direction)
                {
                    case Direction.North:
                        return MazeFields[coordinate.X - 1, coordinate.Y];
                    case Direction.East:
                        return MazeFields[coordinate.X, coordinate.Y + 1];
                    case Direction.West:
                        return MazeFields[coordinate.X, coordinate.Y - 1];
                }
            }
            else
            {
                if (coordinate.X == 0 && coordinate.Y == 0)
                {
                    switch (direction)
                    {
                        case Direction.South:
                            return MazeFields[coordinate.X + 1, coordinate.Y];
                        case Direction.East:
                            return MazeFields[coordinate.X, coordinate.Y + 1];
                    }
                }
                else if (coordinate.X == 0 && coordinate.Y == Columns - 1)
                {
                    switch (direction)
                    {
                        case Direction.South:
                            return MazeFields[coordinate.X + 1, coordinate.Y];
                        case Direction.West:
                            return MazeFields[coordinate.X, coordinate.Y - 1];
                    }
                }
                else if (coordinate.X == Rows - 1 && coordinate.Y == 0)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            return MazeFields[coordinate.X - 1, coordinate.Y];
                        case Direction.East:
                            return MazeFields[coordinate.X, coordinate.Y + 1];
                    }
                }
                else if (coordinate.X == Rows - 1 && coordinate.Y == Columns - 1)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            return MazeFields[coordinate.X - 1, coordinate.Y];
                        case Direction.West:
                            return MazeFields[coordinate.X, coordinate.Y - 1];
                    }
                }
            }

            return MazeFields[coordinate.X, coordinate.Y];
        }

        private MazeField[,] CreateFields()
        {
            var wallDirections = GetWallsDirections();
            var matrixFields = new MazeField[Columns, Rows];
            var index = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    var coordinate = new Coordinate(row, column);
                    matrixFields[row, column] = new MazeField(wallDirections[index], coordinate, index);
                    index++;
                }
            }

            return matrixFields;
        }

        private List<string> GetWallsDirections()
        {
            return Resources.MazeStructure.Split(';').ToList();
        }
    }
}
