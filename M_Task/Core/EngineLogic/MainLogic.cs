namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Core.BrickWork;
    using InputReader;
    using InputReader.Validate;
    using OutPuts.OutPut;

    public class MainLogic : Validations
    {

        protected string horizontalView { get; private set; } = "Horizontal";

        protected string verticalView { get; private set; } = "Vertical";

        protected Dictionary<int, Brick> occurrence;
        protected List<int> unique;
        protected bool[] visited;
        protected Dictionary<int, List<int[]>> multiDimentionalPairHolder;

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
        protected void CheckBrick(int i, int j, int bricks, Brick brick)
        {
            brick.Visited += 1;

            // Check if it is found on differend row, if it is then its vertical if it not, it is horizontal.
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
