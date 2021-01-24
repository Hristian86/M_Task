namespace Assigment.Core.EngineLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Assigment.Core.BrickWork;
    using Assigment.Core.Draw;

    /// <summary>
    /// Holds the variants that are used and assign new variants.
    /// </summary>
    public class Solution : Drawable
    {
        private List<List<string>> variations;
        private List<List<string>> otherVariants;

        /// <summary>
        /// Add variations.
        /// </summary>
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

        /// <summary>
        /// Reassign new horizontal or vertical views for each child.
        /// </summary>
        protected void Solution1()
        {
            foreach (var layer in this.multiDimentionalPairHolder)
            {
                List<Brick> layerChilds = layer.Value;
                this.solve(layerChilds);
                this.otherVariants.Clear();
            }
        }

        /// <summary>
        /// Child view assign.
        /// </summary>
        /// <param name="layerChilds">Childs.</param>
        private void solve(List<Brick> layerChilds)
        {
            int combinations = 4;
            int index = 0;
            int start = 1;
            List<string> listOfPositions = layerChilds
                .Select(x => x.BrickLayout)
                .ToList();

            this.AddVariations();

            this.otherVariants = this.variations
                .Where(x => !x.SequenceEqual(listOfPositions))
                .ToList();

            this.CheckPositionsOfBricks(listOfPositions, layerChilds);
        }

        /// <summary>
        /// Change views in each brick.
        /// </summary>
        /// <param name="listOfPositions">List of views.</param>
        /// <param name="layerChilds">List of childs with the position views, which will be changed.</param>
        private void CheckPositionsOfBricks(List<string> listOfPositions, List<Brick> layerChilds)
        {
            List<string> variant = this.otherVariants[0];
            int i = 0;
            foreach (Brick brick in layerChilds)
            {
                brick.BrickLayout = variant[i];
                i += 1;
            }
        }
    }
}