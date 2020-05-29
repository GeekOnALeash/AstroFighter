// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Singleton instance of class.
	/// </summary>
	/// <typeparam name="T">Class to make singleton.</typeparam>
	[DisallowMultipleComponent]

	// ReSharper disable once ClassCanBeSealed.Global
	public class GenericSingletonClass<T> : MonoBehaviour
		where T : Component
	{
		private static T __instance;

		/// <summary>
		/// Gets singleton instance.
		/// </summary>
		protected internal static T Instance
		{
			get
			{
				if (!(__instance is null))
				{
					return __instance;
				}

				__instance = FindObjectOfType<T>();

				if (!(__instance is null))
				{
					return __instance;
				}

				var obj = new GameObject { name = typeof(T).Name };
				__instance = obj.AddComponent<T>();

				return __instance;
			}
		}
	}
}