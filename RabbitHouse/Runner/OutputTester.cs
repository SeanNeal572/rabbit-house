using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    public class OutputTester
    {
        private readonly double[] _expectedBlockChanges;
        public OutputTester(string answerFilePath)
        {
            _expectedBlockChanges = ParseAnswerFile(answerFilePath);
        }

        private double[] ParseAnswerFile(string answerFilePath)
        {
            var lines = File.ReadAllLines(answerFilePath);
            var temp = lines.Select(line => line.Split(':')[1].Trim());
            return temp.Select(double.Parse).ToArray();
        }

        public void VisualizeResult(RabbitHouseArrangement[] arrangements)
        {
            if (arrangements.Length != _expectedBlockChanges.Length)
            {
                Console.WriteLine("Number of arrangements do not match");
                return;
            }

            var results = arrangements.Select(arrangement => arrangement.GetTotalAddedBlocks()).ToArray();

            var passes = true;
            for (int i = 0; i < _expectedBlockChanges.Length; i++)
            {
                var expected = _expectedBlockChanges[i];
                var result = results[i];
                Console.WriteLine($"Case #{i}: Expected = {expected}; Actual = {result}");
                passes = passes && result == expected;
            }
            Console.WriteLine();
            if (passes)
            {
                Console.WriteLine("Result matches the expected answer");
            }
            else
            {
                Console.WriteLine("Result does not match the expected answer");
            }
        }
    }
}
