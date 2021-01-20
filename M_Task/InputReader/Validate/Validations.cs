namespace Assigment.InputReader.Validate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Validations : InputRead
    {
        /// <summary>
        /// Validate if the input is numbers.
        /// </summary>
        /// <returns>Collection of numbers.</returns>
        protected virtual ICollection<int> ReadLines(bool isNotCordinates = false)
        {
            string[] firstLine = this.Read()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (isNotCordinates)
            {
                // To Do check for length % 4...
            }

            var result = this.ValidateInput(firstLine);

            return result;
        }

        /// <summary>
        /// Try parse the input.
        /// </summary>
        /// <param name="firstLine">array of strings.</param>
        /// <returns>int array.</returns>
        private int[] ValidateInput(string[] firstLine)
        {
            int[] intArr = new int[firstLine.Length];

            for (int i = 0; i < firstLine.Length; i++)
            {
                string number = firstLine[i];

                int temp;
                bool test = int.TryParse(number, out temp);
                if (!test)
                {
                    throw new ArgumentException("You need to enter only numbers");
                }
                else
                {
                    intArr[i] = temp;
                }
            }

            // After successfully validated numbers.
            return intArr;
        }

        /// <summary>
        /// Validate first line with cordinates of the brickMatrix.
        /// </summary>
        /// <param name="firstLine">Bool which states is it first line or not.</param>
        /// <returns>Tuple of 2 int's.</returns>
        protected Tuple<int, int> ReadLine(bool firstLine)
        {
            int[] line = this.ReadLines().ToArray();

            if (firstLine)
            {
                this.AssignRowsAndCOls(line);
            }

            // Validate.
            return new Tuple<int, int>(line[0], line[1]);
        }

        protected int[] ReadLine()
        {
            int[] line = this.ReadLines().ToArray();
            return line;
        }

        /// <summary>
        /// Validate for out of range and even numbers.
        /// </summary>
        /// <param name="line">parametars.</param>
        protected void AssignRowsAndCOls(int[] line)
        {
            if (line.Length != 2)
            {
                throw new ArgumentException("Invalid arguments");
            }
            else
            {
                foreach (var number in line)
                {
                    if (number > 100 || number < 0)
                    {
                        throw new ArgumentOutOfRangeException("Invalid argumens");
                    }
                    else if (number % 2 == 1)
                    {
                        throw new ArgumentException("Invalid number of bricks");
                    }
                }
            }
        }
    }
}
