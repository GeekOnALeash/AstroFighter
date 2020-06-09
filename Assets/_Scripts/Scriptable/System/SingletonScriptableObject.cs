// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable All
namespace Com.StellarPixels.AstroFighter.Scriptable.System
{
	using global::System.Diagnostics.CodeAnalysis;
	using UnityEngine;

	[SuppressMessage("ReSharper", "SA1600", Justification = "Not my script.")]
	public class SingletonScriptableObject<T> : ScriptableObject
		where T : ScriptableObject
	{
		// Private reference to the scriptable object
		private static T __instance;
		private static bool __instantiated;

		internal static T Instance
		{
			get
			{
				if (__instantiated)
				{
					return __instance;
				}

				var singletonName = typeof(T).Name;

				// Look for the singleton on the resources folder
				var assets = Resources.LoadAll<T>(string.Empty);

				if (assets.Length > 1)
				{
					Debug.LogError($"Found multiple {singletonName}s on the resources folder. It is a Singleton ScriptableObject, there should only be one.");
				}

				if (assets.Length == 0)
				{
					__instance = CreateInstance<T>();
					Debug.LogError($"Could not find a {singletonName} on the resources folder. It was created at runtime, therefore it will not be visible on the assets folder and it will not persist.");
				} else
				{
					__instance = assets[0];
				}

				__instantiated = true;

				return __instance;
			}
		}
	}
}