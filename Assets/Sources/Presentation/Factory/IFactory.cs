using UnityEngine;

namespace Assets.Sources.Presentation.Factory
{
    public interface IFactory<out T> where T : Object
    {
        T Create();
    }
}