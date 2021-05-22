// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Editor
{
	using Com.StellarPixels.UtilityLibraries.Attributes;
	using UnityEditor;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Drawer for read only properties.
	/// </summary>
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	public sealed class ReadOnlyDrawer : PropertyDrawer
	{
		/// <inheritdoc />
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> EditorGUI.GetPropertyHeight(property, label, true);

		/// <inheritdoc />
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label, true);
			GUI.enabled = true;
		}
	}
}