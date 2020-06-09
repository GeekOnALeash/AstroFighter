// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Editor
{
	using Editor = UnityEditor.Editor;
#if UNITY_EDITOR
	using UnityEditor;
#endif
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Clear playerPrefs.
	/// </summary>
	public sealed class ClearPlayerPrefs : Editor
	{
		[MenuItem("Edit/Custom/Clear All PlayerPrefs")]
		private static void ClearAll()
		{
			PlayerPrefs.DeleteAll();
			Debug.Log("PlayerPrefs cleared");
		}
	}
}