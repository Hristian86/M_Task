namespace Core.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Interface for main engine.
    /// </summary>
    public interface IMainEngine
    {
        /// <summary>
        /// Starts the program.
        /// </summary>
        public void Init();

        /// <summary>
        /// Prints the brickWorck.
        /// </summary>
        public void Print();
    }
}
