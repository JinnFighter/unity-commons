using UnityEngine;

namespace Assets.Scripts.Content
{
    public class NotInstantiatedContent<T> : IContent<T>
    {
        private readonly T _content;

        public NotInstantiatedContent(T content)
        {
            _content = content;
        }

        public void Destroy(T content)
        {
        }

        public T Generate() => _content;

        public T Generate(Transform parent) => _content;

        public T Generate(Transform parent, Vector3 position) => _content;

        public T Generate(Vector3 position) => _content;
    }
}