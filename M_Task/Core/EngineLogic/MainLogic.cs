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

        protected string horizontalView { get; private set; } = "Horizontal";

        protected string verticalView { get; private set; } = "Vertical";

        // All of double pair of repeated numbers which are forming the bricks.
        protected Dictionary<int, Brick> occurrence;

        // Holds for each layer the unique numbers.
        protected Dictionary<int, List<int[]>> multiDimentionalPairHolder;

        protected List<int> unique;
        protected bool[] visited;
        protected Brick[,] result;

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

        /// <summary>
        /// When brick .horizontal and .vertical are true it is top bottom else one row.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Col.</param>
        /// <param name="bricks">int brick numbers.</param>
        /// <param name="brick">Bricks class.</param>
        protected void ArrangeBrickPossition(int i, int j, int bricks, Brick brick)
        {
            brick.Visited += 1;

            // Check if it is found on differend row, if it is then its vertical, if it is not then is horizontal.
            if (i % 2 != 1)
            {
                brick.Horizontal = true;
            }
            else
            {
                brick.Vertical = true;
            }

            if (!this.occurrence.ContainsKey(bricks))
            {
                this.occurrence[bricks] = brick;
            }
            else
            {
                if (brick.Horizontal)
                {
                    this.occurrence[bricks].Horizontal = brick.Horizontal;
                    this.occurrence[bricks].Visited += 1;
                    this.occurrence[bricks].Row2 = i;
                    this.occurrence[bricks].Col2 = j;
                }
                else if (brick.Vertical)
                {
                    this.occurrence[bricks].Vertical = brick.Vertical;
                    this.occurrence[bricks].Visited += 1;
                    this.occurrence[bricks].Row2 = i;
                    this.occurrence[bricks].Col2 = j;
                }
            }
        }
    }
}
