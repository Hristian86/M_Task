namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Assigment.Core.BrickWork;
    using Assigment.Core.Draw;

    public class Solution : Drawable
    {
        private List<List<string>> variations;
        private List<List<string>> otherVariants;

        private void AddVariations()
        {
            this.variations = new List<List<string>>();

            List<string> variants = new List<string>();

            this.variations.Add(new List<string>() 
            {
                this.horizontalView,
                this.horizontalView,
                this.horizontalView,
                this.horizontalView,
            });

            this.variations.Add(new List<string>()
            {
                this.horizontalView,
                this.verticalView,
                this.horizontalView,
                this.verticalView,
            });

            this.variations.Add(new List<string>()
            {
                this.verticalView,
                this.horizontalView,
                this.horizontalView,
                this.verticalView,
            });

            this.variations.Add(new List<string>()
            {
                this.horizontalView,
                this.horizontalView,
                this.verticalView,
                this.verticalView,
            });

            this.variations.Add(new List<string>()
            {
                this.verticalView,
                this.verticalView,
                this.horizontalView,
                this.horizontalView,
            });
        }

        protected void Solution1()
        {
            foreach (var layer in this.multiDimentionalPairHolder)
            {
                List<Brick> layerChields = layer.Value;
                this.solve(layerChields);
                this.otherVariants.Clear();
            }
        }

        private void solve(List<Brick> layerChields)
        {
            bool[] used = new bool[layerChields.Count];
            int combinations = 4;
            int index = 0;
            int start = 1;
            List<string> listOfPositions = layerChields
                .Select(x => x.BrickLayout)
                .ToList();

            this.AddVariations();

            this.otherVariants = this.variations
                .Where(x => !x.SequenceEqual(listOfPositions))
                .ToList();

            this.CheckPositionsOfBricks(listOfPositions, used, combinations, index, start, layerChields);

        }

        private void CheckPositionsOfBricks(List<string> listOfPositions, bool[] used, int combinations, int index, int start, List<Brick> layerChields)
        {
            List<string> variant = this.otherVariants[0];
            int i = 0;
            foreach (Brick brick in layerChields)
            {
                brick.BrickLayout = variant[i];
                i += 1;
            }
        }
    }
}
