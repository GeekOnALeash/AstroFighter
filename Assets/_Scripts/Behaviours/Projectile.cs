// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
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
		private StringTagArray targetTags;

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

			if (!targetTags.CompareTag(other.tag))
			{
				return;
			}

			var hitPointHelper = other.gameObject.GetComponent<ITakesDamage>();

			// ReSharper disable once UseNullPropagation
			if (hitPointHelper != null)
			{
				hitPointHelper.CauseDamage(attackPoints);
			}

			Explode(true);
		}

		private void ReturnToPool() => gameObject.SetActive(false);
	}
}
