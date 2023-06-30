using AlgoritmoGenetico.Enums;
using AlgoritmoGenetico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AlgoritmoGenetico.Helpers
{
    public static class CanvasHelper
    {
        private static bool _isDrawing;

        public static void AddFieldsToCanvas(Canvas canvas)
        {
            for (int row = 0; row < MazeStructure.Rows * MazeStructure.SquareSize; row += MazeStructure.SquareSize)
            {
                for (int column = 0; column < MazeStructure.Columns * MazeStructure.SquareSize; column += MazeStructure.SquareSize)
                {
                    var mainField = new Border
                    {
                        Margin = new Thickness(column, row, 0, 0),
                        Height = MazeStructure.SquareSize,
                        Width = MazeStructure.SquareSize,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Background = new SolidColorBrush(Color.FromRgb(255, 255, 255))
                    };

                    Grid grid = GetFieldWalls(row / MazeStructure.SquareSize, column / MazeStructure.SquareSize);

                    var coloredField = new Border
                    {
                        Height = 20,
                        Width = 20,
                        Background = new SolidColorBrush(Color.FromRgb(255, 255, 255))
                    };

                    grid.Children.Add(coloredField);

                    MazeStructure.MazeFields[row / 35, column / 35].CanvasField = coloredField;

                    mainField.Child = grid;

                    canvas.Children.Add(mainField);
                }
            }
        }

        public static void UpdateUI(List<MazeField> fieldsTraveled)
        {
            if (_isDrawing || fieldsTraveled == null) return;

            _isDrawing = true;

            new Task(() =>
            {
                foreach (var field in fieldsTraveled)
                {
                    UITask(() => { UpdateCanvasField(field.CanvasField); });

                    Thread.Sleep(100);
                }

                Thread.Sleep(200);

                foreach (var field in fieldsTraveled)
                {
                    UITask(() => { UpdateCanvasField(field.CanvasField, true); });
                }

                _isDrawing = false;
            }).Start();
        }

        private static void UITask(Action action)
        {
            if (Application.Current != null)
                Application.Current.Dispatcher.Invoke(action);
        }

        private static void UpdateCanvasField(Border fieldToPaint, bool shouldClean = false)
        {
            if (shouldClean)
            {
                fieldToPaint.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            else
            {
                fieldToPaint.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }

        private static Grid GetFieldWalls(int row, int column)
        {
            var field = MazeStructure.MazeFields[row, column];

            var grid = new Grid();

            foreach (var wallDirection in field.WallDirections)
            {
                Border wall = GetWallFromEnum(wallDirection);
                if (wall != null)
                {
                    grid.Children.Add(wall);
                }
            }

            AddLinesToField(grid, MazeStructure.AllWallDirections.Except(field.WallDirections).ToList());

            return grid;
        }

        private static void AddLinesToField(Grid grid, List<Direction> lineDirectionsList)
        {
            foreach (var lineDirection in lineDirectionsList)
            {
                Border line = GetWallFromEnum(lineDirection, true);
                if (line != null)
                {
                    grid.Children.Add(line);
                }
            }
        }

        private static Border GetWallFromEnum(Direction wallDirection, bool isLine = false)
        {
            switch (wallDirection)
            {
                case Direction.East:
                    var eastWall = new Border
                    {
                        BorderThickness = GetBorderThickness(isLine),
                        BorderBrush = GetBorderColor(isLine),
                        HorizontalAlignment = HorizontalAlignment.Right
                    };
                    return eastWall;

                case Direction.North:
                    var northWall = new Border
                    {
                        BorderThickness = GetBorderThickness(isLine),
                        BorderBrush = GetBorderColor(isLine),
                        VerticalAlignment = VerticalAlignment.Top
                    };
                    return northWall;

                case Direction.West:
                    var westWall = new Border
                    {
                        BorderThickness = GetBorderThickness(isLine),
                        BorderBrush = GetBorderColor(isLine),
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    return westWall;

                case Direction.South:
                    var southWall = new Border
                    {
                        BorderThickness = GetBorderThickness(isLine),
                        BorderBrush = GetBorderColor(isLine),
                        VerticalAlignment = VerticalAlignment.Bottom
                    };
                    return southWall;

                default: return null;
            }
        }

        private static Thickness GetBorderThickness(bool isLine)
        {
            if (isLine)
            {
                return new Thickness(.25);
            }
            else
            {
                return new Thickness(1);
            }
        }

        private static Brush GetBorderColor(bool isLine)
        {
            if (isLine)
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }
            else
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }
    }
}
