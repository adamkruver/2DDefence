using System;
using UnityEngine;

namespace Sources.Common.Pool
{
    public class PoolBehaviour : MonoBehaviour, IPoolable
    {
        public event Action Released;
        
        public void Release()
        {
            Released?.Invoke();
        }
    }
}