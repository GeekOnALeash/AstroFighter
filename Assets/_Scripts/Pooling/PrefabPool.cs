// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
namespace Com.StellarPixels.Pooling
{
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <summary>
	/// Used to easily pool GameObjects based on prefabs.
	/// </summary>
	internal static class PrefabPool
	{
		private static Dictionary<IPoolableObject, Queue<IPoolableObject>> __pools =
			new Dictionary<IPoolableObject, Queue<IPoolableObject>>();

		private static Transform __poolContainer;

		/// <summary>
		/// Resets prefab pool.
		/// </summary>
		public static void Reset()
		{
			if (!(__poolContainer is null))
			{
				Object.Destroy(__poolContainer.gameObject);
			}

			__poolContainer = null;
			__pools = new Dictionary<IPoolableObject, Queue<IPoolableObject>>();
		}

		/// <summary>
		/// Gets poolable object.
		/// </summary>
		/// <param name="prefab">Prefab to get.</param>
		/// <returns>Poolable object.</returns>
		[NotNull]
		internal static IPoolableObject Get([NotNull] IPoolableObject prefab)
		{
			IPoolableObject item;
			if (!__pools.ContainsKey(prefab))
			{
				__pools.Add(prefab, new Queue<IPoolableObject>());
			}

			if (__pools[prefab].Count > 0)
			{
				item = __pools[prefab].Dequeue();
				item.gameObject.transform.parent = null;
			} else
			{
				item = Object.Instantiate(prefab.gameObject).GetComponent<IPoolableObject>();
				item.Prefab = prefab;
			}

			return item;
		}

		/// <summary>
		/// Return to pool.
		/// </summary>
		/// <param name="itemToReturn">The poolable object to return.</param>
		internal static void Return([NotNull] IPoolableObject itemToReturn)
		{
			if (__poolContainer is null)
			{
				__poolContainer = new GameObject("Pool container").transform;
				__poolContainer.gameObject.SetActive(false);
			}

			if (!__pools.ContainsKey(itemToReturn.Prefab))
			{
				__pools.Add(itemToReturn.Prefab, new Queue<IPoolableObject>());
			}

			itemToReturn.gameObject.transform.SetParent(__poolContainer);
			itemToReturn.gameObject.SetActive(false);
			__pools[itemToReturn.Prefab].Enqueue(itemToReturn);
		}
	}
}