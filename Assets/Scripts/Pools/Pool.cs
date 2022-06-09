using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Pools
{
    public class Pool<T> : IPool<T>
    {
        private readonly Stack<T> _items = new();

        public void Add(T item) => _items.Push(item);

        public T Get() => _items.Pop();

        public bool Has() => _items.Any();
    }
}