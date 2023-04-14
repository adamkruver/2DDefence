using Assets.Sources.Presentation.PrefabProvider;
using UnityEngine;

namespace Assets.Sources.Presentation.Factory
{
    public class Factory<T> : IFactory<T> where T : Object
    {
        private readonly IPrefabProvider<T> _prefabProvider;

        public Factory(IPrefabProvider<T> prefabProvider)
        {
            _prefabProvider = prefabProvider;
        }

        public Factory() : this(new PrefabProvider<T>())
        {
        }

        public T Create()
        {
            return GameObject.Instantiate(_prefabProvider.GetPrefab());
        }
    }
}