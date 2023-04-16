using System;
using UnityEngine;

namespace Sources.Common.Pool
{
    public class PoolItem<T> : IDisposable where T : MonoBehaviour, IPoolable
    {
        private readonly GameObjectPool<T> _pool;

        public PoolItem(T @object, GameObjectPool<T> pool)
        {
            Object = @object;
            _pool = pool;
            Object.Released += OnReleased;
        }

        public T Object { get; }

        private void OnReleased()
        {
            _pool.Return(this);
        }

        public void Dispose()
        {
            Object.Released -= OnReleased;
        }
    }
}