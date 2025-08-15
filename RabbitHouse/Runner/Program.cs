namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmallTest();
            Console.WriteLine("------");
            LargeTest();
        }

        static void LargeTest()
        {
            var arrangements = new RabbitHouseParser().Parse(File.ReadAllLines("1.in"));

            Task.WaitAll(arrangements.Select((arrangement) => new LandFiller(arrangement).FillAsync()).ToArray());

            var tester = new OutputTester("1.ans");
            tester.VisualizeResult(arrangements);
        }

        static void SmallTest()
        {
            var arrangements = new RabbitHouseParser().Parse(File.ReadAllLines("input.txt"));

            Task.WaitAll(arrangements.Select((arrangement) => new LandFiller(arrangement).FillAsync()).ToArray());

            foreach (var arrangement in arrangements)
            {
                var visualizer = new Visualiser(arrangement);
                visualizer.Visualize();
                Console.WriteLine(arrangement.GetTotalAddedBlocks());
                Console.WriteLine();
            }
        }
    }
}
