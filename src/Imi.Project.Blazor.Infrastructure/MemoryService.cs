using Imi.Project.Blazor.Core.Models.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Infrastructure
{
    public class MemoryService
    {
        public Field InitGame()
        {
            Field field = new Field(16, new List<Tile>());

            for (int i = 1; i <= field.NumberOfTiles / 2; i++)
            {
                Tile tile = new Tile(i);
                Tile twinTile = new Tile(i);

                field.Tiles.Add(tile);
                field.Tiles.Add(twinTile);
            }

            field.Tiles.ShuffleDeck();

            return field;
        }


    }
}
