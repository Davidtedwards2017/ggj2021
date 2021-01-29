using Spooky.Utilities.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Spooky.Assets
{
	public abstract class AssetLibrary<T,Y> : SingletonSO<Y> 
		where T : ScriptableObject 
		where Y : ScriptableObject
	{
        public List<T> Assets;

#if UNITY_EDITOR
		[UnityEditor.InitializeOnLoadMethod]
        void OnValidate()
        {
			Assets = BuildAssetCollection();
		}

		private List<T> BuildAssetCollection()
		{
			var collection = new List<T>();

			string[] AssetGuids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);
			foreach (string guid in AssetGuids)
			{
				string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
				var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
	
				if (ShouldAddAsset(asset))
                {
					collection.Add(asset);
                }
			}

			return collection;
		}

		protected virtual bool ShouldAddAsset(T asset)
        {
			return true;
        }

#endif
	}
}