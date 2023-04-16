using System;

namespace Sources.Common.Pool
{
    public interface IPoolable
    {
        event Action Released;
        void Release();
    }
}