// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="ITakesDamage" />
	/// <summary>
	/// Helper for objects that can take damage.
	/// </summary>
	[RequireComponent(typeof(ExplosionHelper))]
	public sealed class HitPointHelper : MonoBehaviour, ITakesDamage
	{
		[SerializeField]
		private IntReference hitPoints;

		/// <inheritdoc/>
		public void CauseDamage(int amount)
		{
			hitPoints.Value -= amount;

			if (hitPoints.Value <= 0)
			{
				Destroy();
			}
		}

		/// <inheritdoc/>
		public void DestroyInstantly()
		{
			CauseDamage(hitPoints.Value);
		}

		private void Destroy()
		{
			var explosion = gameObject.GetComponent<IExplode>();
			explosion?.Explode();
		}
	}
}