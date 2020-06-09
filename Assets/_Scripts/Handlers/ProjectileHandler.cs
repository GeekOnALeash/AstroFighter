// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Handlers
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Pooling;
	using UnityEngine;

	/// <inheritdoc cref="IWeapon" />
	/// <summary>
	/// Weapon that can be fired.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public sealed class ProjectileHandler : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private PoolableItem projectile;

		[SerializeField]
		private AudioSource audioSource;

		/// <inheritdoc />
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void Fire()
		{
			if (projectile is null)
			{
				return;
			}

			PoolBehaviour.Instance.GetProjectileAtPosition(projectile.PoolName, transform.position);

			PlaySound();
		}

		private void PlaySound()
		{
			// ReSharper disable once UseNullPropagation
			if (audioSource is null)
			{
				return;
			}

			audioSource.Play();
		}
	}
}
