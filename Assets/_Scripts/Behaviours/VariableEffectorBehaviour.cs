// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Behaviour for variable effect.
	/// </summary>
	public abstract class VariableEffectorBehaviour : MonoBehaviour
	{
		/// <inheritdoc cref="OnTriggerEnter2D" />
		public void OnTriggerEnter2D([NotNull] Collider2D other)
		{
			Apply(other.gameObject);
		}

		/// <summary>
		/// Apply effect.
		/// </summary>
		/// <param name="go">GameObject that collided with effector.</param>
		protected abstract void Apply(GameObject go);

		/// <summary>
		/// Destroys the effect item.
		/// </summary>
		protected void Destroy()
		{
			Destroy(gameObject);
		}
	}
}