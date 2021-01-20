namespace Assigment_2.Init
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.Engine;
    using Core.Interfaces;
    using InputReader;
    using InputReader.Validate;
    using OutPuts.OutPut;

    /// <summary>
    /// Calling the engine.
    /// </summary>
    public class Builder : Validations, IBuilder
    {
        private IMainEngine engine;
        private readonly IWriter writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        public Builder()
        {
            this.writer = new Writer();
        }

        /// <summary>
        /// Starts the building.
        /// </summary>
        public void Run()
        {
            try
            {
                var (rows, cols) = this.ReadLine(true);
                this.engine = new MainEngine(rows, cols);
                this.engine.Init();
                this.engine.Print();
            }
            catch (Exception ex)
            {
                this.writer.Write(ex.Message);
            }
        }
    }
}