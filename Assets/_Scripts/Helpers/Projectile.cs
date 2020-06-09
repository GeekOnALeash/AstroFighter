// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="ExplosionHelper" />
	/// <summary>
	/// Helper for fired bullet.
	/// </summary>
	public sealed class Projectile : ExplosionHelper
	{
		[SerializeField]
		private StringConstant targetTag;

		[SerializeField]
		private IntReference attackPoints;

		// ReSharper disable once SuggestBaseTypeForParameter
		private static bool WasUpperBoundary([NotNull] Collider2D other)
			=> other.CompareTag("UpperBoundary");

		private void OnBecameInvisible()
		{
			ReturnToPool();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (WasUpperBoundary(other))
			{
				ReturnToPool();
				return;
			}

			if (!other.CompareTag(targetTag.Value) && !other.CompareTag("Obstacle"))
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

		private void ReturnToPool() => gameObject.SetActive(false);
	}
}
