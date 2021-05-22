// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers.Effects
{
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Bool variable effector.
	/// </summary>
	public class BoolVariableEffector : AtomVariableEffector<bool>
	{
		[SerializeField]
		private BoolEvent variableToEffect;

		/// <inheritdoc/>
		public override bool ApplyTo([NotNull] GameObject go)
		{
			if (!CompareTag(go))
			{
				return false;
			}

			variableToEffect.Raise(ValueToApply);

			return true;
		}
	}
}