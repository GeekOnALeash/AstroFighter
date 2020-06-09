// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Pooling
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Item to pool.
	/// </summary>
	[CreateAssetMenu(fileName = "PoolableItem", menuName = "Scriptable/Pool/PoolableItem", order = 0)]
	public sealed class PoolableItem : ScriptableObject
	{
		[SerializeField]
		private string poolName;

		[SerializeField]
		private PoolableObject poolableObject;

		[SerializeField]
		private int preloadSize;

		[SerializeField]
		private int initialPoolCapacity;

		/// <summary>
		/// Gets poolableObject prefab to pool.
		/// </summary>
		internal PoolableObject PoolableObject => poolableObject;

		/// <summary>
		/// Gets initial amount of prefabs to instantiate.
		/// </summary>
		internal int PreloadSize => preloadSize;

		/// <summary>
		/// Gets pool name.
		/// </summary>
		internal string PoolName => poolName;

		/// <summary>
		/// Gets initial capacity of the pool.
		/// </summary>
		internal int InitialPoolCapacity => initialPoolCapacity;
	}
}