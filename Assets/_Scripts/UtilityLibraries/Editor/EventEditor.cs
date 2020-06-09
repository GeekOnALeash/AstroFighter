// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Editor
{
	using com.ArkAngelApps.TheAvarice.Scriptable.Events;
	using UnityEditor;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Raise button for events in inspector.
	/// </summary>
	[CustomEditor(typeof(GameEvent))]
	public sealed class EventEditor : UnityEditor.Editor
	{
		/// <inheritdoc/>
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			GUI.enabled = Application.isPlaying;

			GameEvent e = target as GameEvent;

			if (!GUILayout.Button("Raise"))
			{
				return;
			}

			if (e != null)
			{
				e.Raise();
			}
		}
	}
}