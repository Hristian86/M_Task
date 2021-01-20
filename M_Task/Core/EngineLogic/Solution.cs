namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.BrickWork;

    public class Solution : MainLogic
    {
        protected Brick[,] result;

        protected void Solution1()
        {
            this.result = new Brick[this.FillBrickMatrix.GetLength(0), this.FillBrickMatrix.GetLength(1)];

            foreach (var uniqueReact in this.multiDimentionalPairHolder)
            {
                this.unique.AddRange(uniqueReact.Value[0].ToList());

                List<int> copySort = this.unique.ToList();
                copySort.Sort();

                this.visited = new bool[copySort[copySort.Count - 1]];

                for (int i = 0; i < this.unique.Count - 1; i++)
                {
                    var x = i;

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
                        if (this.occurrence[next].Horizontal && this.occurrence[next].Vertical)
                        {
                            // Top bottom + top bottom...
                        }
                        else
                        {
                            // Top bottom + left right...
                            this.VerticalHorizontal(current, next, x);
                        }
                    }
                    else
                    {
                        // left right.
                        // current = horizontal view.
                        this.LeftRight(current, next, x);
                    }

                }

                this.unique.Clear();
            }
        }

        // Current is verticali, next is horizontal.
        private void VerticalHorizontal(int current, int next, int x)
        {
            if (x < 2)
            {
                var currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                var nextSwap = this.occurrence[next];
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
                var currentSwap = this.occurrence[current];
                currentSwap.BrickLayout = this.horizontalView;
                var nextSwap = this.occurrence[next];
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

        private void LeftRight(int current, int next, int x)
        {
            // current = horizontal view.
            if (this.occurrence[next].Horizontal && this.occurrence[next].Vertical)
            {
                // TO DO....
                // Left right + Top bottom...
                if (x < 2)
                {
                    var currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    var nextSwap = this.occurrence[next];
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
                    var currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    var nextSwap = this.occurrence[next];
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
                // next = horizontal view.
                // move the seccond one to left side.
                // Left right + left right...
                // First 2 pair of bricks.
                if (x < 2)
                {
                    var currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    var nextSwap = this.occurrence[next];
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
                    var currentSwap = this.occurrence[current];
                    currentSwap.BrickLayout = this.horizontalView;
                    var nextSwap = this.occurrence[next];
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
        }
    }
}
