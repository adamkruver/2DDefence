using System;

namespace Assets.Sources.Services
{
    public interface IService: IDisposable
    {
        void Enable();
        void Disable();
    }
}