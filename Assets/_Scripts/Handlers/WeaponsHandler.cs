// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Handlers
{
	using System.Collections.Generic;
	using Com.StellarPixels.AstroFighter.Helpers;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for the ships firing points.
	/// </summary>
	public sealed class WeaponsHandler : MonoBehaviour
	{
		private const int MaxFiringPoints = 5;

		[SerializeField]
		private List<Weapon> firingPoints;

		private int _currentFiringPoints = 1;

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

			if (_currentFiringPoints >= MaxFiringPoints)
			{
				return;
			}

			DisableAll();

			_currentFiringPoints += 2;

			for (int id = 0; id < _currentFiringPoints; id++)
			{
				firingPoints[id].ResetWeapon();
			}
		}

		private void DisableAll()
		{
			foreach (var firingPoint in firingPoints)
			{
				firingPoint.enabled = false;
			}
		}
	}
}