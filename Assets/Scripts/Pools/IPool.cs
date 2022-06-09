namespace Assets.Scripts.Pools
{
    public interface IPool<T>
    {
        T Get();
        bool Has();
        void Add(T item);
    }
}