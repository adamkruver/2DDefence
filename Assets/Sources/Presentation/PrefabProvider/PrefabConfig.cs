using System;
using System.Collections.Generic;

namespace Assets.Sources.Presentation.PrefabProvider
{
    public class PrefabConfig
    {
        private readonly Dictionary<Type, string> _prefabPaths = new Dictionary<Type, string>()
        {
        };

        public string GetPath<T>()
        {
            Type type = typeof(T);
            
            if(_prefabPaths.ContainsKey(type))
                return _prefabPaths[typeof(T)];

            return type.Name;
        }
    }
}