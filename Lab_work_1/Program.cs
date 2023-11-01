namespace Lab_work_1
{
    public class Program
    {
        static void Main(string[] argv)
        {
            if (argv.Length == 1)
            {
                System.Console.Write("Hello, ");
                System.Console.WriteLine(argv[0]);
            }
            else
            {
                System.Console.WriteLine("Hello, world!");
            }
        }
    }
}
