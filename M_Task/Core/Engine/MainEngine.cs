namespace Assigment.Core.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
            this.occurrence = new Dictionary<int, Brick>();
            this.unique = new List<int>();
            this.writer = new Writer();
        }

        /// <summary>
        /// Init the engine.
        /// </summary>
        public void Init()
        {
            this.FillMatrix();
            this.FillUnique();
            this.Solution1();
        }

        /// <summary>
        /// Fill the unique individual containers with 2 x 2 pairs.
        /// </summary>
        private void FillUnique()
        {
            this.multiDimentionalPairHolder = new Dictionary<int, List<int[]>>();
            var layers = this.matrix.GetLength(0) / 2;
            var pairs = this.matrix.GetLength(1) / 4;
            var x = layers * pairs;

            for (int f = 0; f < x; f++)
            {
                if (!this.multiDimentionalPairHolder.ContainsKey(f))
                {
                    this.multiDimentionalPairHolder[f] = new List<int[]>();
                }
            }

            var rows = 0;
            var index = 0;
            var count = 0;
            var pairsCount = 0;
            for (int i = 0; i < layers; i++)
            {
                for (int k = 0; k < pairs; k++)
                {
                    var uniquePair = new int[4];

                    for (int row = rows; row < 2; row++)
                    {
                        for (int col = 0; col < 4; col++)
                        {
                            if (!uniquePair.Contains(this.matrix[row, col + count]))
                            {
                                uniquePair[index] = this.matrix[row, col + count];
                                index += 1;
                            }
                        }
                    }

                    this.multiDimentionalPairHolder[pairsCount].Add(uniquePair);
                    pairsCount += 1;
                    count += 4;
                    index = 0;
                }

                rows += 2;
            }
        }

        public void Print()
        {
            this.writer.Write(string.Empty);
            for (int i = 0; i < this.result.GetLength(0); i++)
            {
                for (int j = 0; j < this.result.GetLength(1); j++)
                {
                    this.writer.WriteOneRow(this.result[i, j].Number + " ");
                }

                this.writer.Write(string.Empty);
            }
        }

        private void FillMatrix()
        {
            this.FillIntArray();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                this.SecondLoop(i);
            }
        }

        private void FillIntArray()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                int[] bricks = this.ReadLine();

                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = bricks[j];
                }
            }
        }

        private void SecondLoop(int i)
        {
            for (int j = 0; j < this.matrix.GetLength(1); j++)
            {
                Brick brick = new Brick();
                brick.Number = this.matrix[i, j];
                brick.Row = i;
                brick.Col = j;

                this.CheckBrick(i, j, brick.Number, brick);

                // Validete each number.
                this.FillBrickMatrix[i, j] = brick;
            }
        }
    }
}