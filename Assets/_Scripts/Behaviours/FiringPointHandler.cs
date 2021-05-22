// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using Com.StellarPixels.AstroFighter.Pooling;
	using UnityEngine;

	/// <inheritdoc cref="IWeapon" />
	/// <summary>
	/// Weapon that can be fired.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public sealed class FiringPointHandler : MonoBehaviour, IWeapon
	{
		private PoolableItem projectile;

		[SerializeField]
		private AudioSource audioSource;

		// TODO: Find away to disable and enable the firing point so only allowed points are active.
		private bool _isEnabled = false;

		/// <inheritdoc />
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void Fire()
		{
			if (projectile is null || _isEnabled == false)
			{
				return;
			}

			PoolBehaviour.Instance.GetProjectileAtPosition(projectile.PoolName, transform.position);

			PlaySound();
		}

		/// <summary>
		/// Sets Poolable Item as the new projectile.
		/// </summary>
		/// <param name="newProjectile">Poolable Item to set as new projectile.</param>
		internal void SetProjectile(PoolableItem newProjectile, bool shouldEnable = true)
		{
			projectile = newProjectile;
			_isEnabled = shouldEnable;
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
