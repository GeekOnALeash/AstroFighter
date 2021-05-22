// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Editor
{
	using System;
	using Com.StellarPixels.UtilityLibraries.Attributes;
	using JetBrains.Annotations;
	using UnityEditor;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Drawer for scene asset file fields.
	/// </summary>
	[CustomPropertyDrawer(typeof(SceneAttribute))]
	public class SceneDrawer : PropertyDrawer
	{
		/// <inheritdoc />
		public override void OnGUI(Rect position, [NotNull] SerializedProperty property, GUIContent label)
		{
			if (property.propertyType == SerializedPropertyType.String)
			{
				var sceneObject = GetSceneObject(property.stringValue);
				var scene = EditorGUI.ObjectField(position, label, sceneObject, typeof(SceneAsset), true);
				if (scene == null) {
					property.stringValue = string.Empty;
				} else if (scene.name != property.stringValue)
				{
					var sceneObj = GetSceneObject(scene.name);
					if (sceneObj == null)
					{
						Debug.LogWarning($"The scene {scene.name} cannot be used. To use this scene add it to the build settings for the project");
					} else
					{
						property.stringValue = scene.name;
					}
				}
			}
			else
			{
				EditorGUI.LabelField(position, label.text, "Use [Scene] with strings.");
			}
		}

		/// <summary>
		/// Gets the scene object asset.
		/// </summary>
		/// <param name="sceneObjectName">Name of the scene to get.</param>
		/// <returns>The scene requested.</returns>
		[CanBeNull]
		protected SceneAsset GetSceneObject([CanBeNull] string sceneObjectName)
		{
			if (string.IsNullOrEmpty(sceneObjectName))
			{
				return null;
			}

			foreach (var editorScene in EditorBuildSettings.scenes)
			{
				if (editorScene.path.IndexOf(sceneObjectName, StringComparison.Ordinal) != -1)
				{
					return AssetDatabase.LoadAssetAtPath(editorScene.path, typeof(SceneAsset)) as SceneAsset;
				}
			}

			Debug.LogWarning($"Scene [{sceneObjectName}] cannot be used. Add this scene to the 'Scenes in the Build' in build settings.");
			return null;
		}
	}
}