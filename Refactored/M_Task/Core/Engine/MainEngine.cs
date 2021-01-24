namespace Assigment.Core.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Assigment.Core.BrickWork;
    using Assigment.Core.Draw;
    using Core.BrickWork;
    using Core.EngineLogic;
    using Core.Interfaces;
    using OutPuts.OutPut;

    public class MainEngine : Solution, IMainEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainEngine"/> class.
        /// </summary>
        /// <param name="rows">Rows.</param>
        /// <param name="cols">Cols.</param>
        public MainEngine(int rows, int cols)
        {
            this.FillBrickMatrix = new Brick[rows, cols];
            this.matrix = new int[rows, cols];
            this.writer = new Writer();
            this.result = new int[rows, cols];
            this.result2 = new List<Brick>();
        }

        /// <summary>
        /// Init the engine.
        /// </summary>
        public void Init()
        {
            this.FillMatrix();
            this.Solution1();
            this.ArrangeResult();
        }

        /// <summary>
        /// Prints the solution.
        /// </summary>
        public void Print()
        {
            this.DrawBrickWork();
        }

        private void FillMatrix()
        {
            this.FillIntArray();

            this.FillUnique();
        }

        /// <summary>
        /// Col check.
        /// </summary>
        /// <param name="row">Row.</param>
        /// <param name="col">Col.</param>
        /// <returns>Bool.</returns>
        private bool isNotOfBoundCol(int row, int col)
        {
            return col + 1 < this.matrix.GetLength(1);
        }

        /// <summary>
        /// Row check.
        /// </summary>
        /// <param name="row">row.</param>
        /// <param name="col">col.</param>
        /// <returns>bool.</returns>
        private bool isNotOfBoundsRow(int row, int col)
        {
            return row + 1 < this.matrix.GetLength(0);
        }

        private void FillIntArray()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                int[] bricks = this.ReadLine();

                // Validations for each row.
                this.ValidateRows(bricks);

                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = bricks[j];
                }
            }
        }

        /// <summary>
        /// Fill the unique individual containers with 2 x 2 pairs.
        /// </summary>
        private void FillUnique()
        {
            this.multiDimentionalPairHolder = new Dictionary<int, List<Brick>>();
            var used = new bool[this.matrix.GetLength(0), this.matrix.GetLength(1)];

            int layers = this.matrix.GetLength(0) / 2;
            int pairs = this.matrix.GetLength(1) / 4;
            int x = layers * pairs;

            for (int f = 0; f < x; f++)
            {
                if (!this.multiDimentionalPairHolder.ContainsKey(f))
                {
                    this.multiDimentionalPairHolder[f] = new List<Brick>();
                }
            }

            List<Brick> uniquePair = new List<Brick>();
            int rows = 0;
            int countPairs = 0;
            int countLayers = 0;
            for (int i = 0; i < layers; i++)
            {
                for (int k = 0; k < pairs; k++)
                {
                    this.CellAssign(rows, uniquePair,  countPairs, ref countLayers, used);

                    countPairs += 4;
                }

                rows += 2;
                countPairs = 0;
            }
        }

        /// <summary>
        /// Fills each number and his view (horizontal or vertical) and adds them to the Dictionary childs.
        /// </summary>
        /// <param name="rows">Grow in rows.</param>
        /// <param name="childsToBeAdded">Add the child for each number with assigned view.</param>
        /// <param name="countPairs">Grow in pairs after the furst CellAssign it grows to check the rest of the column.</param>
        /// <param name="countLayers">Each 2 rows make a layer.</param>
        /// <param name="used">Bool array with visited cells.</param>
        private void CellAssign(int rows, List<Brick> childsToBeAdded, int countPairs, ref int countLayers, bool[,] used)
        {
            for (int row = rows; row < 2 + rows; row++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var col = j + countPairs;

                    if (childsToBeAdded.Count == 4)
                    {
                        this.multiDimentionalPairHolder[countLayers] = childsToBeAdded.ToList();

                        countLayers += 1;
                        childsToBeAdded.Clear();
                    }

                    if (!used[row, col])
                    {
                        if (this.isNotOfBoundCol(row, col))
                        {
                            // Check col.
                            var num = this.matrix[row, col];
                            if (this.matrix[row, col + 1] == num)
                            {
                                used[row, col] = true;
                                used[row, col + 1] = true;

                                // Logic...
                                childsToBeAdded.Add(new Brick()
                                {
                                    Number = this.matrix[row, col],
                                    BrickLayout = this.horizontalView,
                                });
                            }
                        }

                        if (this.isNotOfBoundsRow(row, col))
                        {
                            // Check row.
                            var num = this.matrix[row, col];
                            if (this.matrix[row + 1, col] == num)
                            {
                                used[row, col] = true;
                                used[row + 1, col] = true;

                                // Logic...
                                childsToBeAdded.Add(new Brick()
                                {
                                    Number = this.matrix[row, col],
                                    BrickLayout = this.verticalView,
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}