using System;

namespace Eron.core.DataModel
{
    public class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}