namespace OutPuts.OutPut
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for writer.
    /// </summary>
    public interface IWriter
    {
        void WriteOneRow(string x);

        /// <summary>
        /// Writes string.
        /// </summary>
        /// <param name="x">string.</param>
        public void Write(string x);

        /// <summary>
        /// Writes number.
        /// </summary>
        /// <param name="x">int.</param>
        public void Write(int x);

        /// <summary>
        /// Writes collection.
        /// </summary>
        /// <param name="x">IEnumerable<char>.</param>
        public void Write<T>(IEnumerable<T> x);
    }
}