// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for all firing points of the individual weapon.
	/// </summary>
	public sealed class Weapon : MonoBehaviour
	{
		private bool _autoFire;
		private float _fireRate;
		private int _totalFiringPoints;
		private float _timer;

		[SerializeField]
		private List<FiringPointHandler> firingPoints;

		internal List<FiringPointHandler> FiringPoints => firingPoints;

		public bool AutoFire
		{
			get => _autoFire;
			set => _autoFire = value;
		}

		public float FireRate
		{
			get => _fireRate;
			set => _fireRate = value;
		}

		public int TotalFiringPoints
		{
			get => _totalFiringPoints;
			set => _totalFiringPoints = value;
		}

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
			_timer = _fireRate;
			enabled = true;
		}

		private void AttemptToFire()
		{
			if (_autoFire)
			{
				_timer -= Time.deltaTime;

				if (!(_timer <= 0))
				{
					return;
				}

				_timer = _fireRate;
			} else if (!Input.GetKeyDown(KeyCode.Space))
			{
				return;
			}

			Fire();
		}

		private void Fire()
		{
			foreach (var bullet in firingPoints)
			{
				bullet.Fire();
			}
		}
	}
}