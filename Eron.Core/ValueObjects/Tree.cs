using System.Collections.Generic;

namespace Eron.Core.ValueObjects
{
    public class TreeItem<T>
    {
        public T Item { get; set; }

        public IEnumerable<TreeItem<T>> Children { get; set; }
    }
}
