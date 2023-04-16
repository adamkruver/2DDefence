namespace Assets.Sources.Common.PrefabProvider
{
    public class PrefabConfig
    {
        public virtual string GetPath<T>()
        {
            return typeof(T).Name;
        }
    }
}