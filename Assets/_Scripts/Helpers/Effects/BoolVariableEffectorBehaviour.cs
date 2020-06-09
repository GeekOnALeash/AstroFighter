// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers.Effects
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Behaviour for bool variable effect.
	/// </summary>
	[AddComponentMenu("AstroFighter/Behaviours/Bool Variable Effector")]
	public class BoolVariableEffectorBehaviour : VariableEffectorBehaviour
	{
		[SerializeField]
		private BoolVariableEffector effector;

		/// <inheritdoc/>
		protected override void Apply(GameObject go)
		{
			bool applied = effector.ApplyTo(go);

			if (applied && effector.DestroyAfterUse)
			{
				Destroy();
			}
		}
	}
}