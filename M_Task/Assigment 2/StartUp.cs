namespace Assigment
{
    using Assigment.Init;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IBuilder build = new Builder();
            build.Run();
        }
    }
}
