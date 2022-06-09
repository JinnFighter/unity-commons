using UnityEngine;

namespace Assets.Scripts.Content
{
    public class InstantiatedContent<T> : IContent<T> where T : MonoBehaviour
    {
        private readonly T _originalContent;

        public InstantiatedContent(T content)
        {
            _originalContent = content;
        }

        public void Destroy(T content) => Object.Destroy(content.gameObject);

        public T Generate() => Object.Instantiate(_originalContent);

        public T Generate(Transform parent) => Object.Instantiate(_originalContent, parent);

        public T Generate(Transform parent, Vector3 position) => Object.Instantiate(_originalContent, position, Quaternion.identity, parent);

        public T Generate(Vector3 position) => Object.Instantiate(_originalContent, position, Quaternion.identity);
    }
}