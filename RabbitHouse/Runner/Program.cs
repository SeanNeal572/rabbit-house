namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrangements = new RabbitHouseParser().Parse(File.ReadAllLines("1.in"));

            Task.WaitAll(arrangements.Select((arrangement) => new LandFiller(arrangement).FillAsync()).ToArray());

            var tester = new OutputTester("1.ans");
            tester.VisualizeResult(arrangements);
        }
    }
}
