using System.Collections.Generic;

namespace InputReader
{
    /// <summary>
    /// Reader.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Read.
        /// </summary>
        /// <returns>String.</returns>
        public string Read();

        /// <summary>
        /// ReadLines.
        /// </summary>
        /// <returns>Collection of ints.</returns>
        ICollection<int> ReadLines();
    }
}