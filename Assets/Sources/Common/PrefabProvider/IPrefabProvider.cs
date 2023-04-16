using UnityEngine;

namespace Assets.Sources.Common.PrefabProvider
{
    public interface IPrefabProvider<out T> where T : Object
    {
        T GetPrefab();
    }
}