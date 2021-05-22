// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using Com.StellarPixels.AstroFighter.Interfaces;
	using Com.StellarPixels.AstroFighter.Pooling;
	using UnityEngine;

	/// <inheritdoc cref="IExplode" />
	/// <summary>
	/// Helper for objects that can be exploded.
	/// </summary>
	public class ExplosionHelper : PoolableObject, IExplode
	{
		[SerializeField]
		private PoolableItem explosion;

		protected PoolableItem Explosion => explosion;

		/// <inheritdoc />
		/// <summary>
		/// Explode the gameObject.
		/// </summary>
		public virtual void Explode(bool objectDestroyed)
		{
			if (!objectDestroyed)
			{
				return;
			}

			PoolBehaviour.Instance.GetExplosionAtPosition(Explosion.PoolName, transform.position);
			PoolBehaviour.Return(this);
		}
	}
}
