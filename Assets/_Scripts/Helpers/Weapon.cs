// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Handlers;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for all firing points of the individual weapon.
	/// </summary>
	public sealed class Weapon : MonoBehaviour
	{
		[SerializeField]
		private List<ProjectileHandler> weapons;

		[SerializeField]
		private bool autoFire;

		[SerializeField]
		private FloatReference fireRate;

		private float _timer;

		private void Update()
		{
			AttemptToFire();
		}

		/// <summary>
		/// Resets weapon auto fire timer.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		internal void ResetWeapon()
		{
			_timer = fireRate;
			enabled = true;
		}

		private void AttemptToFire()
		{
			if (autoFire)
			{
				_timer -= Time.deltaTime;

				if (!(_timer <= 0))
				{
					return;
				}

				_timer = fireRate;
			} else if (!Input.GetKeyDown(KeyCode.Space))
			{
				return;
			}

			Fire();
		}

		private void Fire()
		{
			foreach (var bullet in weapons)
			{
				bullet.Fire();
			}
		}
	}
}