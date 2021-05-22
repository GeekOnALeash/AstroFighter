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
		private ObjectPool projectilePool;

		[SerializeField]
		private ObjectPool explosionPool;

		/// <summary>
		/// Returns the object back to the pool.
		/// </summary>
		/// <param name="poolable">Poolable object to return.</param>
		public static void Return([NotNull] PoolableObject poolable)
			=> poolable.gameObject.SetActive(false);

		/// <summary>
		/// Gets bullet and sets position.
		/// </summary>
		/// <param name="poolName">Name of the pool.</param>
		/// <param name="position">Position to set.</param>
		/// <returns>Item from the pool.</returns>
		[NotNull]
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public PoolableObject GetProjectileAtPosition(
			[NotNull] string poolName, Vector2 position)
		{
			var newProjectile = projectilePool.GetPooledObject(poolName);
			newProjectile.transform.position = position;
			return newProjectile;
		}

		/// <summary>
		/// Gets bullet and sets position.
		/// </summary>
		/// <param name="poolName">Name of the pool.</param>
		/// <param name="position">Position to set.</param>
		/// <returns>Item from the pool.</returns>
		[NotNull]
		public PoolableObject GetExplosionAtPosition([NotNull] string poolName, Vector2 position)
		{
			var newExplosion = explosionPool.GetPooledObject(poolName);
			newExplosion.transform.position = position;
			return explosionPool.GetPooledObject(poolName);
		}
	}
}