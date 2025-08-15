namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrangements = new RabbitHouseParser().Parse(File.ReadAllLines("input.txt"));

            foreach (var arrangement in arrangements)
            {
                var landFiller = new LandFiller(arrangement);
                landFiller.Fill();

                Console.WriteLine(arrangement.IsSafe().ToString());
                Console.WriteLine(arrangement.GetTotalAddedBlocks());

                var visualizer = new Visualiser(arrangement);
                visualizer.Visualize();
                Console.WriteLine();
            }


            Console.WriteLine("Hello, World!");
        }
    }
}
