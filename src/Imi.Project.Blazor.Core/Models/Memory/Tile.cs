using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models.Memory
{
    public class Tile
    {
        public int Id { get; set; }

        public string CoverUri { get; set; }
        public string FlippedUri { get; set; }
        public bool IsFlipped { get; set; }
        public bool IsFound { get; set; }

        public Tile(int id)
        {
            Id = id;
            CoverUri = "tile.png";
            FlippedUri = DetermineImage(id);
            IsFlipped = false;
            IsFound = false;
        }

        public string DetermineImage(int id)
        {
            string value = "";

            switch (id)
            {
                case 1:
                    value = "cake.png";
                    break;
                case 2:
                    value = "cookie.png";
                    break;
                case 3:
                    value = "cupcake.png";
                    break;
                case 4:
                    value = "donut.png";
                    break;
                case 5:
                    value = "macaron.png";
                    break;
                case 6:
                    value = "pie.png";
                    break;
                case 7:
                    value = "puff_pastry.png";
                    break;
                case 8:
                    value = "roll.png";
                    break;
            }

            return value;
        }
    }
}
