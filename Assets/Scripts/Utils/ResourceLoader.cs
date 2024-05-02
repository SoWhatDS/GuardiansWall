
using UnityEngine;

namespace GuardiansWall.Utils
{
    internal static class ResourceLoader 
    {
        public static Sprite LoadSprite(string path)
        {
            return Resources.Load<Sprite>(path);
        }

        public static GameObject LoadPrefab(string path)
        {
            return Resources.Load<GameObject>(path);
        }

        public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();

            if (result == null)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}
