// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers.Effects
{
	using UnityEngine;

	/// <summary>
	/// Interface for effector.
	/// </summary>
	internal interface IEffector
	{
		/// <summary>
		/// Applies the effect.
		/// </summary>
		/// <param name="go">GameObject.</param>
		/// <returns>True if applied successfully.</returns>
		bool ApplyTo(GameObject go);
	}
}