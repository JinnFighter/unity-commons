using Assets.Scripts.Pools;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Content
{
    public class PooledReferenceContent<T> : IContent<T> where T : MonoBehaviour
    {
        private readonly IPool<T> _pool = new Pool<T>();

        private readonly AssetReference _assetReference;

        public PooledReferenceContent(AssetReference assetReference)
        {
            _assetReference = assetReference;
        }

        public void Destroy(T content)
        {
            var gameObject = content.gameObject;
            gameObject.SetActive(false);
            gameObject.transform.position = new Vector3(0, -10000, 0);
            _pool.Add(content);
        }

        public T Generate() => GetContent();

        public T Generate(Transform parent)
        {
            var content = GetContent();
            content.transform.SetParent(parent);
            return content;
        }

        public T Generate(Transform parent, Vector3 position)
        {
            var content = GetContent();
            content.transform.SetParent(parent);
            content.transform.position = position;
            return content;
        }

        public T Generate(Vector3 position)
        {
            var content = GetContent();
            content.transform.position = position;
            return content;
        }

        private T GetContent()
        {
            T content;
            if (_pool.Has())
            {
                content = _pool.Get();
            }
            else
            {
                content = Addressables.Instantiate(_assetReference).Result.GetComponent<T>();
            }

            content.gameObject.SetActive(true);
            return content;
        }
    }
}