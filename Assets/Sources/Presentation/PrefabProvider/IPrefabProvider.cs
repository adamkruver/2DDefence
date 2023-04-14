using UnityEngine;

namespace Assets.Sources.Presentation.PrefabProvider
{
    public interface IPrefabProvider<out T> where T : Object
    {
        T GetPrefab();
    }
}