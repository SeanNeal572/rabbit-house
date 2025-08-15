using System.Runtime.CompilerServices;

namespace Runner
{
    public class LandFiller(RabbitHouseArrangement arrangement)
    {
        public void Fill()
        {
            var loopHasChanges = false;
            do {
                loopHasChanges = false;
                foreach (var tile in StreamTiles())
                {
                    var minimumSurroundingHeight = tile.Height - 1;
                    var tilesNeedingUpdating = GetTilesAround(tile.X, tile.Y).Where((x) => x.Height < minimumSurroundingHeight);
                    loopHasChanges = loopHasChanges || tilesNeedingUpdating.Any();
                    foreach (var surroundingTile in tilesNeedingUpdating)
                    {
                        arrangement.SetHeightAt(surroundingTile.X, surroundingTile.Y, minimumSurroundingHeight);
                    }
                }
            } while (loopHasChanges);
        }

        public Task FillAsync()
        {
            return Task.Run(Fill);
        }

        private IEnumerable<Tile> StreamTiles()
        {
            for (var x = 0; x < arrangement.TotalRows; x++)
            {
                for (var y = 0; y < arrangement.TotalColumns; y++)
                {
                    yield return TileAndHeightAt(x, y);
                }
            }
        }

        private IEnumerable<Tile> GetTilesAround(int x, int y)
        {
            if (x > 0) yield return TileAndHeightAt(x - 1, y);
            if (x < arrangement.TotalRows - 1) yield return TileAndHeightAt(x + 1, y);
            if (y > 0) yield return TileAndHeightAt(x, y - 1);
            if (y < arrangement.TotalColumns - 1) yield return TileAndHeightAt(x, y + 1);
        }

        private Tile TileAndHeightAt(int x, int y)
        {
            return new Tile(x, y, arrangement.GetHeightAt(x, y));
        }
    }
}
