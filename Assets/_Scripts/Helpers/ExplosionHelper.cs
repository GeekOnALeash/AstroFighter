// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System.Diagnostics.CodeAnalysis;
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

		/// <inheritdoc />
		/// <summary>
		/// Explode the gameObject.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public virtual void Explode()
		{
			PoolBehaviour.Instance.GetExplosionAtPosition(explosion.PoolName, transform.position);
			PoolBehaviour.Instance.Return(this);
		}
	}
}
