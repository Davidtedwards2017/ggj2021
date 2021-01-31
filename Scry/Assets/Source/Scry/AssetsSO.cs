using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AssetsSO<T> : ScriptableObject where T : ScriptableObject
{
	public List<T> Assets;

#if UNITY_EDITOR

	private void OnValidate()
	{
		BuildUp();
	}

	[UnityEditor.InitializeOnLoadMethod]
	private void BuildUp()
	{
		Assets = GetReagentAssets();
	}

	private List<T> GetReagentAssets()
	{
		var collection = new List<T>();

		string[] AssetGuids = UnityEditor.AssetDatabase.FindAssets("t:" + typeof(T).Name);
		foreach (string guid in AssetGuids)
		{
			string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
			var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
			if (asset != null)
			{
				collection.Add(asset);
			}
		}

		return collection;
	}
#endif
}
