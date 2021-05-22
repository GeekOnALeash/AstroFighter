// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Path finding way point.
	/// </summary>
	public sealed class WayPoint : MonoBehaviour
	{
		[SerializeField]
		private float speed = 0.35f;

		/// <summary>
		/// Gets speed of travel.
		/// </summary>
		public float Speed => speed;

		/// <summary>
		/// Gets the lerp velocity.
		/// </summary>
		/// <returns>WayPoint position.</returns>
		public Vector2 GetPosition() => transform.position;
	}
}