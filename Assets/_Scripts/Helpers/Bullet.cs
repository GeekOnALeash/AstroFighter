// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="ExplosionHelper" />
	/// <summary>
	/// Helper for fired bullet.
	/// </summary>
	public sealed class Bullet : ExplosionHelper
	{
		[SerializeField]
		private Target target;

		[SerializeField]
		private IntReference attackPoints;

		private void OnBecameInvisible()
		{
			ReturnToPool();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			if (other.CompareTag("UpperBoundary"))
			{
				ReturnToPool();
			}

			if (other.gameObject.CompareTag("FX"))
			{
				return;
			}

			if (target == Target.Enemy && other.gameObject.CompareTag("Player"))
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
