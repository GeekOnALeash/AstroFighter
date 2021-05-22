// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers.Effects
{
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Int variable effector.
	/// </summary>
	[CreateAssetMenu(fileName = "IntVariableEffector", menuName = "Scriptable/PickUps/IntVariableEffector", order = 1)]
	public sealed class IntVariableEffector : AtomVariableEffector<int>
	{
		[SerializeField]
		private IntVariable variableToEffect;

		/// <inheritdoc/>
		public override bool ApplyTo([NotNull] GameObject go)
		{
			if (!CompareTag(go))
			{
				return false;
			}

			// ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault
			switch (EffectType)
			{
				case EffectType.Increase:
					variableToEffect.Add(ValueToApply);
					return true;
				case EffectType.Decrease:
					variableToEffect.Subtract(ValueToApply);
					return true;
			}

			return false;
		}
	}
}