using System.Linq;
using UnityEngine;

namespace Spooky.Utilities.Core
{
    public abstract class SingletonSO<T> : ScriptableObject where T : ScriptableObject
    {
        private static T instance { get; set; }
        public static T Instance
        {
            get
            {
                if (!instance)
                {
                    var asset = Resources.LoadAll<T>("");
                    if (asset.Length == 0)
                    {
                        Debug.LogError("An instance of " + typeof(T) +
                           " is needed in the scene, but there is none.");
                    }

                    instance = asset[0];
                }

                return instance;
            }
        }
    }
}