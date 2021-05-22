// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Scriptable.Planes;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for the ships firing points.
	/// </summary>
	public sealed class Weapons : MonoBehaviour
	{
		[SerializeField]
		private ScriptableProjectile projectile;

		[SerializeField]
		private List<Weapon> weaponSlots;

		private int _totalWeaponSlots = 5;
		private int _currentWeaponSlots = 1;

		private void Start()
		{
			if (projectile is null)
			{
				DisableAll();
			} else
			{
				SetProjectile(projectile);
			}
		}

		public void SetProjectile([NotNull] ScriptableProjectile newProjectile)
		{
			projectile = newProjectile;

			if (newProjectile.AllowedWeaponSlots > weaponSlots.Count)
			{
				_totalWeaponSlots = weaponSlots.Count;
			} else
			{
				_totalWeaponSlots = newProjectile.AllowedWeaponSlots;
			}

			_currentWeaponSlots = newProjectile.WeaponSlotsToStartWith;

			int currentWeaponSlot = 1;

			foreach (var firingSlot in weaponSlots)
			{
				if (currentWeaponSlot > newProjectile.AllowedWeaponSlots)
				{
					break;
				}

				currentWeaponSlot++;

				int currentFiringPoints = 0;

				foreach (var firingPoint in firingSlot.FiringPoints)
				{
					if (currentFiringPoints >= newProjectile.FiringPoints)
					{
						firingPoint.SetProjectile(null, false);
						break;
					}

					currentFiringPoints++;

					firingPoint.SetProjectile(newProjectile.PoolableItem);
				}

				firingSlot.FireRate = projectile.FiringRate;
				firingSlot.AutoFire = projectile.AutoFire;
				firingSlot.TotalFiringPoints = projectile.FiringPoints;
				firingSlot.ResetWeapon();
			}

			UpdateFirePower();
		}

		/// <summary>
		/// Increases firepower.
		/// </summary>
		/// <param name="eventBool">Bool supplied by event.</param>
		public void IncreaseFirePower(bool eventBool)
		{
			if (eventBool == false)
			{
				return;
			}

			if (CheckSlots())
			{
				return;
			}

			_currentWeaponSlots += 2;

			UpdateFirePower();
		}

		private bool CheckSlots()
		{
			if (_currentWeaponSlots >= _totalWeaponSlots)
			{
				return true;
			}

			if (weaponSlots.Count == 0)
			{
				throw new NullReferenceException("Firing points is empty.");
			}

			return false;
		}

		private void UpdateFirePower()
		{
			if (CheckSlots())
			{
				return;
			}

			DisableAll();

			for (int id = 0; id < _currentWeaponSlots; id++)
			{
				weaponSlots[id].ResetWeapon();
			}
		}

		[ExcludeFromCodeCoverage]
		private void DisableAll()
		{
			foreach (var firingPoint in weaponSlots)
			{
				firingPoint.enabled = false;
			}
		}
	}
}