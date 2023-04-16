using UnityEngine;

namespace Assets.Sources.Common.Factory
{
    public interface IFactory<out T> where T : Object
    {
        T Create();
    }
}