namespace OutPuts.OutPut
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Writes.
    /// </summary>
    public class Writer : IWriter
    {
        /// <summary>
        /// Writes string.
        /// </summary>
        /// <param name="x">string.</param>
        public void Write(string x)
        {
            Console.WriteLine(x);
        }

        public void WriteOneRow(string x)
        {
            Console.Write(x);
        }

        /// <summary>
        /// Writes number.
        /// </summary>
        /// <param name="x">int.</param>
        public void Write(int x)
        {
            Console.WriteLine(x);
        }

        /// <summary>
        /// Writes collection.
        /// </summary>
        /// <param name="x">IEnumerable<char>.</param>
        public void Write<T>(IEnumerable<T> x)
        {
            foreach (var items in x)
            {
                Console.WriteLine(items);
            }
        }

    }
}
