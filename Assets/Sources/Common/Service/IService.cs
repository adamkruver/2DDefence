using System;

namespace Assets.Sources.Common.Service
{
    public interface IService: IDisposable
    {
        void Enable();
        void Disable();
    }
}