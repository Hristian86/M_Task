namespace Assigment_2
{
    using Assigment_2.Init;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IBuilder build = new Builder();
            build.Run();
        }
    }
}
