using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    public class Visualiser(RabbitHouseArrangement arrangement)
    {
        public void Visualize()
        {
            var rows = StreamTiles().GroupBy((tile) => tile.X);
            foreach (var row in rows) 
            {
                Console.WriteLine(string.Join(" ", row.Select(x => x.Height.ToString())));
            }
        }

        private IEnumerable<Tile> StreamTiles()
        {
            for (int x = 0; x < arrangement.TotalRows; x++)
            {
                for (int y = 0; y < arrangement.TotalColumns; y++)
                {
                    yield return new Tile(x, y, arrangement.GetHeightAt(x, y));
                }
            }
        }
    }
}
