namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.Pooling;
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="ExplosionHelper" />
	/// <summary>
	/// Helper for fired bullet.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class Bullet : ExplosionHelper, IPoolableObject
	{
		[SerializeField]
		private IntReference attackPoints;

		private void OnBecameInvisible()
		{
			PrefabPool.Return(this);
		}

		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("FX"))
			{
				return;
			}

			var hitPointHelper = other.gameObject.GetComponent<ITakesDamage>();

			// ReSharper disable once UseNullPropagation
			if (hitPointHelper != null)
			{
				hitPointHelper.CauseDamage(attackPoints);
			}

			Explode();
		}

		public IPoolableObject Prefab { get; set; }
	}
}
