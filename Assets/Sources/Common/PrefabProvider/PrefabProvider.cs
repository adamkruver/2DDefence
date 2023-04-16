using UnityEngine;

namespace Assets.Sources.Common.PrefabProvider
{
    public class PrefabProvider<T> : IPrefabProvider<T> where T: Object
    {
        private readonly PrefabConfig _prefabConfig = new PrefabConfig();

        public T GetPrefab() 
        {
            return Resources.Load<T>(_prefabConfig.GetPath<T>());       
        }
    }
}