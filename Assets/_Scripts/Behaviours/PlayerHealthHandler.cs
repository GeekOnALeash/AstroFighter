// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for player health.
	/// </summary>
	public sealed class PlayerHealthHandler : HealthHandler
	{
		[SerializeField]
		private BoolEvent destroyed;

		/// <inheritdoc/>
		public override void Destroy()
		{
			destroyed.Raise(true);
		}
	}
}