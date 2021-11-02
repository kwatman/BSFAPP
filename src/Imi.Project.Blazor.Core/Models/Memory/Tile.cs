using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models.Memory
{
    public class Tile
    {
        public int Id { get; set; }

        private string coverUri;

        public string CoverUri
        {
            get { return coverUri; }
            set 
            {
                value = "tile.png";
                coverUri = value; 
            }
        }

        private string flippedUri;

        public string FlippedUri
        {
            get { return flippedUri; }
            set 
            {
                switch (Id)
                {
                    case 0:
                        value = "cake.png";
                        break;
                    case 1:
                        value = "cookie.png";
                        break;
                    case 2:
                        value = "cupcake.png";
                        break;
                    case 3:
                        value = "donut.png";
                        break;
                    case 4:
                        value = "macaron.png";
                        break;
                    case 5:
                        value = "pie.png";
                        break;
                    case 6:
                        value = "puff_pastry.png";
                        break;
                    case 7:
                        value = "roll.png";
                        break;
                }

                flippedUri = value; 
            }
        }

        public bool IsFlipped { get; set; }

        public Tile(int id)
        {
            Id = id;
            IsFlipped = false;
        }
    }
}
