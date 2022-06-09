using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.Content
{
    public class InstantiatedReferenceContent<T> : IContent<T> where T : MonoBehaviour
    {
        private readonly AssetReference _assetReference;

        public InstantiatedReferenceContent(AssetReference assetReference)
        {
            _assetReference = assetReference;
        }

        public void Destroy(T content) => Addressables.ReleaseInstance(content.gameObject);

        public T Generate() => Addressables.Instantiate(_assetReference).Result.GetComponent<T>();

        public T Generate(Transform parent)
        {
            var gameObject = Addressables.Instantiate(_assetReference).Result;
            gameObject.transform.SetParent(parent);
            return gameObject.GetComponent<T>();
        }

        public T Generate(Transform parent, Vector3 position)
        {
            var gameObject = Addressables.Instantiate(_assetReference).Result;
            gameObject.transform.SetParent(parent);
            gameObject.transform.position = position;
            return gameObject.GetComponent<T>();
        }

        public T Generate(Vector3 position)
        {
            var gameObject = Addressables.Instantiate(_assetReference).Result;
            gameObject.transform.position = position;
            return gameObject.GetComponent<T>();
        }
    }
}