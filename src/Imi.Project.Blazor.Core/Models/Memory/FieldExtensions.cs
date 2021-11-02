using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Blazor.Core.Models.Memory
{
    public static class FieldExtensions
    {
        private static Random random = new Random();

        public static void ShuffleDeck<T>(this IList<T> deck)
        {
            int numberOfItems = deck.Count;
            while (numberOfItems > 1)
            {
                numberOfItems--;

                int randomizer = random.Next(numberOfItems + 1);

                T value = deck[randomizer];
                deck[randomizer] = deck[numberOfItems];
                deck[numberOfItems] = value;
            }
        }
    }
}
