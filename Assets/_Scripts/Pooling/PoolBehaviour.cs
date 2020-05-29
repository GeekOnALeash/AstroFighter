// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Pooling
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.UtilityLibraries;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Pooling Behaviour.
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class PoolBehaviour : GenericSingletonClass<PoolBehaviour>
	{
		[SerializeField]
		private ObjectPool bulletPool;

		[SerializeField]
		private ObjectPool explosionPool;

		/// <summary>
		/// Gets bullet and sets position.
		/// </summary>
		/// <param name="poolName">Name of the pool.</param>
		/// <param name="position">Position to set.</param>
		/// <returns>Item from the pool.</returns>
		[NotNull]
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		internal PoolableObject GetBulletAtPosition(string poolName, Vector2 position)
		{
			var newBullet = bulletPool.GetPooledObject(poolName);
			newBullet.transform.position = position;
			return newBullet;
		}

		/// <summary>
		/// Gets bullet and sets position.
		/// </summary>
		/// <param name="poolName">Name of the pool.</param>
		/// <param name="position">Position to set.</param>
		/// <returns>Item from the pool.</returns>
		[NotNull]
		internal PoolableObject GetExplosionAtPosition(string poolName, Vector2 position)
		{
			var newExplosion = explosionPool.GetPooledObject(poolName);
			newExplosion.transform.position = position;
			return explosionPool.GetPooledObject(poolName);
		}

		internal void Return([NotNull] PoolableObject poolable) => poolable.gameObject.SetActive(false);
	}
}