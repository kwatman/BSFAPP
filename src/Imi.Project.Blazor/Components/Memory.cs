using Imi.Project.Blazor.Core.Models.Memory;
using Imi.Project.Blazor.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Components
{
    public partial class Memory
    {
        public Field game;
        private MemoryService memoryService = new MemoryService();
        public List<Tile> clickedTiles = new List<Tile>();
        public List<Tile> checkingTiles = new List<Tile>();
        int numberOfMatches = 0;


        protected override Task OnInitializedAsync()
        {
            game = memoryService.InitGame();
            return base.OnInitializedAsync();
        }

        void tileClicked(Tile tile)
        {
            tile.CoverUri = tile.FlippedUri;
            clickedTiles.Add(tile);

            if (clickedTiles.Count == 3)
            {
                checkingTiles.Add(clickedTiles.First());
                clickedTiles.Remove(clickedTiles.First());
                checkingTiles.Add(clickedTiles.First());
                clickedTiles.Remove(clickedTiles.First());

                if (checkingTiles.First().Id == checkingTiles.Last().Id)
                {
                    checkingTiles.Clear();

                    numberOfMatches++;
                }
                else
                {
                    foreach (Tile checkingTile in checkingTiles)
                    {
                        checkingTile.CoverUri = "tile.png";
                    }

                    checkingTiles.Clear();
                }
            }
        }
    }
}
