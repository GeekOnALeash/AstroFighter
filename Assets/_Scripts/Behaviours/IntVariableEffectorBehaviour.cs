// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using Com.StellarPixels.AstroFighter.Helpers.Effects;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Behaviour for int variable effect.
	/// </summary>
	[AddComponentMenu("AstroFighter/Behaviours/Int Variable Effector")]
	public sealed class IntVariableEffectorBehaviour : VariableEffectorBehaviour
	{
		[SerializeField]
		private IntVariableEffector effector;

		/// <inheritdoc/>
		protected override void Apply([NotNull] GameObject go)
		{
			bool applied = effector.ApplyTo(go);

			if (applied && effector.DestroyAfterUse)
			{
				Destroy();
			}
		}
	}
}