// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Scriptable
{
	using Com.StellarPixels.AstroFighter.Helpers.Effects;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Increases fire power (Firing points) of the weapons.
	/// </summary>
	[CreateAssetMenu(fileName = "IncreaseFirePower", menuName = "Scriptable/PickUps/IncreaseFirePower", order = 0)]
	public sealed class IncreaseFirePower : BoolVariableEffector { }
}