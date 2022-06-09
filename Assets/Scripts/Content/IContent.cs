using UnityEngine;

namespace Assets.Scripts.Content
{
    public interface IContent<T>
    {
        T Generate();
        T Generate(Transform parent);
        T Generate(Transform parent, Vector3 position);
        T Generate(Vector3 position);
        void Destroy(T content);
    }
}