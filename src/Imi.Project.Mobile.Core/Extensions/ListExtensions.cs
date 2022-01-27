using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Imi.Project.Mobile.Core.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> list)
        {
            var collection = new ObservableCollection<T>();
            foreach (var item in list)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
