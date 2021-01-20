namespace Assigment.Core.BrickWork
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using InputReader.Validate;

    public class Brick 
    {
        internal int Visited { get; set; }

        internal int Row { get; set; }

        internal int Col { get; set; }


        internal int Row2 { get; set; }

        internal int Col2 { get; set; }

        internal bool Horizontal { get; set; }

        internal bool Vertical { get; set; }

        internal string BrickLayout { get; set; }

        internal int Number { get; set; }

        internal Brick()
        {

        }

    }
}
