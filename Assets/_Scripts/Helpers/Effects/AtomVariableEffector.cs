// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers.Effects
{
	using JetBrains.Annotations;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <summary>
	/// Variable effector base.
	/// </summary>
	/// <typeparam name="T">Base type for variable.</typeparam>
	public abstract class AtomVariableEffector<T> : ScriptableObject, IEffector
	{
		[SerializeField]
		private EffectType effectType;

		[SerializeField]
		private T valueToApply;

		[SerializeField]
		private StringConstant targetTag;

		[SerializeField]
		private bool destroyAfterUse;

		/// <summary>
		/// Gets a value indicating whether to destroy after use.
		/// </summary>
		internal bool DestroyAfterUse => destroyAfterUse;

		/// <summary>
		/// Gets value to be applied by the effect.
		/// </summary>
		protected T ValueToApply => valueToApply;

		/// <summary>
		/// Gets effect type.
		/// </summary>
		protected EffectType EffectType => effectType;

		/// <summary>
		/// Gets target tag string.
		/// </summary>
		private StringConstant TargetTag => targetTag;

		/// <inheritdoc/>
		public abstract bool ApplyTo(GameObject go);

		/// <summary>
		/// Compare tag to TargetTag.
		/// </summary>
		/// <param name="go">GameObject to check.</param>
		/// <returns>True if tags match.</returns>
		protected bool CompareTag([NotNull] GameObject go) => go.CompareTag(TargetTag.Value);
	}
}