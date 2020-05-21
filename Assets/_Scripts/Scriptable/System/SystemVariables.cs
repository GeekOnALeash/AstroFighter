namespace Com.StellarPixels.AstroFighter.Scriptable.System
{
	using com.ArkAngelApps.TheAvarice.Scriptable;
	using com.ArkAngelApps.TheAvarice.Scriptable.Events;
	using global::System;
	using UnityEngine;

	/// <summary>
	/// System variables singleton scriptable object.
	/// </summary>
	[CreateAssetMenu(fileName = "_SystemVariables", menuName = "Scriptable/System/SystemVariables", order = 1)]
	public sealed class SystemVariables : SingletonScriptableObject<SystemVariables>
	{
		internal Camera mainCamera;

		[Serializable]
		public struct Settings
		{
			[Serializable]
			public struct UI
			{
				public GameEvent showFPSEvent;
			}

			public UI ui;

			[Serializable]
			public struct Debug
			{
				public bool debug;
			}

			public Debug debug;
		}

		public Settings settings;
	}
}