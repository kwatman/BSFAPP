using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models.Memory
{
    public class Field
    {
        public int NumberOfTiles { get; set; }
        public IList<Tile> Tiles { get; set; }

        public Field(int numberOfTiles, List<Tile> tiles)
        {
            NumberOfTiles = numberOfTiles;
            Tiles = tiles;
        }
    }
}
