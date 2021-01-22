namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Assigment.Core.BrickWork;
    using Assigment.InputReader;
    using Assigment.InputReader.Validate;
    using Assigment.OutPuts.OutPut;

    public class MainLogic : Validations
    {
        public int ColumnPairs
        {
            get => this.matrix.GetLength(1) / 4;
        }

        public int RowPairs
        {
            get => this.matrix.GetLength(0) / 2;
        }

        protected string horizontalView { get; private set; } = "Horizontal";

        protected string verticalView { get; private set; } = "Vertical";

        protected List<Brick> result2;
        protected int[,] result;
        protected Dictionary<int, List<Brick>> multiDimentionalPairHolder;

        private Brick[,] brickMatrix;
        protected int[,] matrix;
        protected IWriter writer;

        protected Brick[,] FillBrickMatrix
        {
            get => this.brickMatrix;

            set
            {
                this.brickMatrix = value;
            }
        }

        protected void ArrangeResult()
        {
            int rows = this.result.GetLength(0) / 2;
            int cols = this.result.GetLength(1) / 4;
            int col = 0;
            var row = 0;
            foreach (var chield in this.multiDimentionalPairHolder)
            {
                if (col >= this.result.GetLength(1))
                {
                    row += 2;
                    col = 0;
                }

                this.Calculate(chield.Value, row, col);
                col += 4;
            }
        }

        private void Calculate(List<Brick> bricks, int row, int col)
        {
            for (int i = 0; i < bricks.Count - 1; i++)
            {
                if (i < 2)
                {
                    if (bricks[i].BrickLayout == this.horizontalView && bricks[i + 1].BrickLayout == this.verticalView)
                    {
                        this.result2.Add(bricks[i + 1]);
                        this.result2.Add(bricks[i]);

                        this.result[row, col] = bricks[i + 1].Number;
                        this.result[row + 1, col] = bricks[i + 1].Number;

                        this.result[row, col + 1] = bricks[i].Number;
                        this.result[row, col + 2] = bricks[i].Number;
                        i += 1;
                        row += 2;
                        col += 2;
                    }
                    else if (bricks[i].BrickLayout == this.horizontalView && bricks[i + 1].BrickLayout == this.horizontalView)
                    {
                        this.result2.Add(bricks[i + 1]);
                        this.result2.Add(bricks[i]);

                        this.result[row, col] = bricks[i + 1].Number;
                        this.result[row, col + 1] = bricks[i + 1].Number;

                        this.result[row, col + 2] = bricks[i].Number;
                        this.result[row, col + 3] = bricks[i].Number;
                        i += 1;
                        row += 2;
                        col += 2;
                    }
                }
                else
                {
                    if (bricks[i].BrickLayout == this.horizontalView && bricks[i + 1].BrickLayout == this.verticalView)
                    {
                        this.result2.Add(bricks[i]);
                        this.result2.Add(bricks[i + 1]);

                        this.result[row - 1, col - 1] = bricks[i].Number;
                        this.result[row - 1, col] = bricks[i].Number;

                        this.result[row - 2, col + 1] = bricks[i + 1].Number;
                        this.result[row - 1, col + 1] = bricks[i + 1].Number;

                        i += 1;
                        row += 2;
                        col += 2;
                    }
                    else if (bricks[i].BrickLayout == this.horizontalView && bricks[i + 1].BrickLayout == this.horizontalView)
                    {
                        this.result2.Add(bricks[i + 1]);
                        this.result2.Add(bricks[i]);

                        this.result[row - 1, col - 2] = bricks[i + 1].Number;
                        this.result[row - 1, col - 1] = bricks[i + 1].Number;

                        this.result[row - 1, col] = bricks[i].Number;
                        this.result[row - 1, col + 1] = bricks[i].Number;
                        i += 1;
                        row += 2;
                        col += 2;
                    }
                }
            }
        }
    }
}
