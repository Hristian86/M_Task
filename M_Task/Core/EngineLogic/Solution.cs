namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.BrickWork;

    public class Solution : MainLogic
    {
        protected void Solution1()
        {
            this.result = new Brick[this.FillBrickMatrix.GetLength(0), this.FillBrickMatrix.GetLength(1)];

            int rowIncrement = 0;
            int rowToSum = 0;
            foreach (var uniqueChield in this.multiDimentionalPairHolder)
            {
                if (rowIncrement % 2 == 0 && rowIncrement != 0)
                {
                    rowToSum += 2;
                }

                if (rowIncrement == 3)
                {
                    // Debugging purposes.
                    ;
                }

                this.unique.AddRange(uniqueChield.Value[0].ToList());
                this.visited = new bool[this.unique.Count];

                for (int i = 0; i < this.unique.Count - 1; i++)
                {
                    int x = i;

                    if (this.visited[x])
                    {
                        continue;
                    }

                    int current = this.unique[x];
                    int next = this.unique[x + 1];

                    // Top bottom.
                    if (this.occurrence[current].Horizontal
                        && this.occurrence[current].Vertical
                        && !this.visited[x]
                        && !this.visited[x + 1])
                    {
                        // Current = vertical view.
                        if (this.occurrence[next].Horizontal && this.occurrence[next].Vertical)
                        {
                            // Next = vertical view.
                            // Top bottom + top bottom...
                            this.VerticalVertical(current, next, x, rowToSum);
                        }
                        else
                        {
                            // Next = horizontal view.
                            // Top bottom + left right...
                            this.VerticalHorizontal(current, next, x, rowToSum);
                        }
                    }
                    else
                    {
                        // left right.
                        // current = horizontal view.
                        // TODO fix the method.
                        this.HorizontalHorizontal(current, next, x, rowToSum);
                    }
                }

                this.unique.Clear();
                rowIncrement += 1;
            }
        }

        /// <summary>
        /// Assign bricks.
        /// </summary>
        /// <param name="current">Currnet is vertical.</param>
        /// <param name="next">Next is vertical.</param>
        /// <param name="x">Index.</param>
        private void VerticalVertical(int current, int next, int x, int rowToSum)
        {
            if (x < 2)
            {
                Brick currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                Brick nextSwap = this.occurrence[next];
                nextSwap.BrickLayout = this.horizontalView;

                // next goes current and swap.
                this.result[nextSwap.Row, nextSwap.Col - 1] = nextSwap;
                this.result[nextSwap.Row, nextSwap.Col] = nextSwap;

                this.result[currentSwap.Row, nextSwap.Col + 1] = currentSwap;
                this.result[currentSwap.Row, nextSwap.Col + 2] = currentSwap;

                this.visited[x] = true;
                this.visited[x + 1] = true;
            }
            else
            {
                Brick currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                Brick nextSwap = this.occurrence[next];
                nextSwap.BrickLayout = this.horizontalView;

                // next goes current and swap.
                this.result[currentSwap.Row2, nextSwap.Col - 1] = nextSwap;
                this.result[currentSwap.Row2, nextSwap.Col] = nextSwap;

                this.result[nextSwap.Row, nextSwap.Col2] = currentSwap;
                this.result[nextSwap.Row, nextSwap.Col2 + 1] = currentSwap;

                this.visited[x] = true;
                this.visited[x + 1] = true;
            }
        }

        /// <summary>
        /// Assign bricks.
        /// </summary>
        /// <param name="current">Current is vertical.</param>
        /// <param name="next">Next is horizontal.</param>
        /// <param name="x">Index.</param>
        private void VerticalHorizontal(int current, int next, int x, int rowToSum)
        {
            if (x < 2)
            {
                Brick currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                Brick nextSwap = this.occurrence[next];
                nextSwap.BrickLayout = this.horizontalView;

                // next goes current and swap.
                this.result[nextSwap.Row, nextSwap.Col - 1] = nextSwap;
                this.result[nextSwap.Row, nextSwap.Col] = nextSwap;

                this.result[currentSwap.Row, nextSwap.Col + 1] = currentSwap;
                this.result[currentSwap.Row, nextSwap.Col + 2] = currentSwap;

                this.visited[x] = true;
                this.visited[x + 1] = true;
            }
            else
            {
                Brick currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                Brick nextSwap = this.occurrence[next];
                nextSwap.BrickLayout = this.horizontalView;

                // next goes current and swap.
                this.result[nextSwap.Row, nextSwap.Col - 1] = nextSwap;
                this.result[nextSwap.Row, nextSwap.Col] = nextSwap;

                this.result[nextSwap.Row, nextSwap.Col2] = currentSwap;
                this.result[nextSwap.Row, nextSwap.Col2 + 1] = currentSwap;

                this.visited[x] = true;
                this.visited[x + 1] = true;
            }
        }

        private void HorizontalHorizontal(int current, int next, int x, int rowToSum)
        {
            // current = horizontal view.
            if (this.occurrence[next].Horizontal && this.occurrence[next].Vertical)
            {
                // Next = vertical view.
                // Left right + Top bottom...
                if (x < 2)
                {
                    Brick currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    Brick nextSwap = this.occurrence[next];
                    nextSwap.BrickLayout = this.verticalView;

                    // next goes current and swap.
                    this.result[currentSwap.Row, currentSwap.Col] = nextSwap;
                    this.result[currentSwap.Row + 1, currentSwap.Col] = nextSwap;

                    this.result[currentSwap.Row, currentSwap.Col + 1] = currentSwap;
                    this.result[currentSwap.Row, currentSwap.Col + 2] = currentSwap;

                    this.visited[x] = true;
                    this.visited[x + 1] = true;
                }
                else
                {
                    Brick currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    Brick nextSwap = this.occurrence[next];
                    nextSwap.BrickLayout = this.verticalView;

                    // next goes current and swap.
                    this.result[currentSwap.Row, currentSwap.Col + 1] = currentSwap;
                    this.result[currentSwap.Row, currentSwap.Col + 2] = currentSwap;

                    this.result[nextSwap.Row - 1, nextSwap.Col2] = nextSwap;
                    this.result[nextSwap.Row, nextSwap.Col2] = nextSwap;

                    this.visited[x] = true;
                    this.visited[x + 1] = true;
                }
            }
            else
            {
                // Next = horizontal view.
                // move the seccond one to left side.
                // Left right + left right...
                // First 2 pair of bricks.
                if (x < 2)
                {
                    Brick currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    Brick nextSwap = this.occurrence[next];
                    nextSwap.BrickLayout = this.verticalView;

                    // next goes current and swap.
                    this.result[currentSwap.Row, currentSwap.Col] = nextSwap;
                    this.result[currentSwap.Row + 1, currentSwap.Col] = nextSwap;

                    this.result[currentSwap.Row, currentSwap.Col + 1] = currentSwap;
                    this.result[currentSwap.Row, currentSwap.Col + 2] = currentSwap;

                    this.visited[x] = true;
                    this.visited[x + 1] = true;
                }
                else
                {
                    Brick currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    Brick nextSwap = this.occurrence[next];
                    nextSwap.BrickLayout = this.verticalView;

                    // next goes current and swap.
                    this.result[currentSwap.Row, currentSwap.Col + 1] = currentSwap;
                    this.result[currentSwap.Row, currentSwap.Col + 2] = currentSwap;

                    this.result[nextSwap.Row - 1, nextSwap.Col + 1] = nextSwap;
                    this.result[nextSwap.Row, nextSwap.Col + 1] = nextSwap;

                    this.visited[x] = true;
                    this.visited[x + 1] = true;
                }
            }
        }
    }
}
