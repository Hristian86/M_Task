namespace Assigment.Core.Draw
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Assigment.Core.BrickWork;
    using Assigment.Core.EngineLogic;

    public class Drawable : MainLogic, IDrawable
    {
        /// <summary>
        /// Display bricks as numbers.
        /// </summary>
        public void DrawBrickWork()
        {
            this.writer.Write(string.Empty);

            for (int i = 0; i < this.result.GetLength(0); i++)
            {
                for (int j = 0; j < this.result.GetLength(1); j++)
                {
                    this.writer.WriteOneRow(this.result[i, j] + " ");
                }

                this.writer.Write(string.Empty);
            }

            this.writer.Write(string.Empty);

            //this.DrawBricks();
            this.DrawListOfBricks();
        }

        /// <summary>
        /// Draw bricks.
        /// </summary>
        private void DrawListOfBricks()
        {
            var display = new string[5];

            foreach (var brick in this.result2)
            {
                if (brick.BrickLayout == this.horizontalView)
                {
                    this.horizon(brick, display);
                }
                else if (brick.BrickLayout == this.verticalView)
                {
                    this.Vertical(brick, display);
                }
            }

            foreach (var item in display)
            {
                this.writer.Write(item);
            }
        }

        private void DrawBricks()
        {
            foreach (KeyValuePair<int, List<BrickWork.Brick>> pairs in this.multiDimentionalPairHolder)
            {
                this.DrawPairs(pairs);
            }
        }

        private void DrawPairs(KeyValuePair<int, List<Brick>> pairs)
        {
            string[] dispaly = new string[5];

            var i = 0;
            foreach (var brick in pairs.Value)
            {
                if (brick.BrickLayout == this.horizontalView)
                {
                    this.horizon(brick, dispaly);
                }
                else if (brick.BrickLayout == this.verticalView)
                {
                    this.Vertical(brick, dispaly);
                }

                i += 1;
            }

            foreach (var item in dispaly)
            {
                this.writer.Write(item);
            }
        }

        private void Vertical(Brick brick, string[] dispaly)
        {
            dispaly[0] += $"***********" + " ";
            dispaly[1] += $"*    {brick.Number}    *" + " ";
            dispaly[2] += $"*---------*" + " ";
            dispaly[3] += $"*    {brick.Number}    *" + " ";
            dispaly[4] += $"***********" + " ";
        }

        private void horizon(Brick brick, string[] dispaly)
        {
            dispaly[0] += $"*****-*****" + " ";
            dispaly[1] += $"*    -    *" + " ";
            dispaly[2] += $"*  {brick.Number} - {brick.Number}  *" + " ";
            dispaly[3] += $"*    -    *" + " ";
            dispaly[4] += $"*****-*****" + " ";
        }
    }
}
