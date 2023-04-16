using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Common.Pool
{
    public class GameObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        private readonly Func<T> _factory;
        private Transform _parent;

        private Stack<PoolItem<T>> _objects = new Stack<PoolItem<T>>();

        public GameObjectPool(Func<T> factory)
        {
            _factory = factory;
            _parent = new GameObject(typeof(T).Name).transform;
            _parent.gameObject.SetActive(false);
        }

        public T Get()
        {
            PoolItem<T> item;

            if (_objects.TryPop(out item))
            {
                T @object = item.Object;
                @object.transform.parent = null;
                
                return @object;
            }

            item = new PoolItem<T>(_factory.Invoke(), this);
            return item.Object;
        }

        public void Return(PoolItem<T> item)
        {
            item.Object.transform.parent = _parent;
            _objects.Push(item);
        }
    }
}