// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using UnityAtoms.BaseAtoms;

	/// <inheritdoc cref="ITakesDamage" />
	/// <summary>
	/// Helper for objects that can take damage.
	/// </summary>
	public sealed class HitPointHelper
	{
		private readonly IntReference _hitPoints;


		/// <summary>
		/// Initializes a new instance of the <see cref="HitPointHelper"/> class.
		/// </summary>
		/// <param name="hitPoints">IntReference hitPoints UnityAtoms.</param>
		public HitPointHelper(IntReference hitPoints) => _hitPoints = hitPoints;

		/// <summary>
		/// Current hit points.
		/// </summary>
		public IntReference HitPoints => _hitPoints;

		/// <summary>
		/// Gets a value indicating whether the objects HP has dropped to zero.
		/// </summary>
		public bool IsZero { get; private set; }

		/// <summary>
		/// Cause damage to object.
		/// </summary>
		/// <param name="amount">Amount of damage to cause.</param>
		public void CauseDamage(int amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), $"{nameof(amount)} can not be negative or zero.");
			}

			_hitPoints.Value -= amount;

			if (_hitPoints.Value <= 0)
			{
				IsZero = true;
			}
		}

		/// <summary>
		/// Destroy instantly the object.
		/// </summary>
		public void DestroyInstantly()
		{
			CauseDamage(_hitPoints.Value);
		}
	}
}