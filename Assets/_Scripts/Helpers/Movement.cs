namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
	using UnityEngine;

	/// <summary>
	/// Movement Helper.
	/// </summary>
	public class Movement
	{
		private readonly float _speed;

		public float Speed => _speed;

		/// <summary>
		/// Initializes a new instance of the <see cref="Movement"/> class.
		/// </summary>
		/// <param name="speed">Speed of movement.</param>
		public Movement(float speed) => _speed = speed;

		/// <summary>
		/// Calculate the vector to move to.
		/// </summary>
		/// <param name="vector">Vector to move to.</param>
		/// <param name="time">time to be multiplied with speed.</param>
		/// <returns>Vector2 to move towards.</returns>
		public Vector2 CalculateVector(Vector2 vector, float time)
		{
			if (vector == Vector2.zero)
			{
				throw new ArgumentOutOfRangeException(
													nameof(vector),
													$"{nameof(vector)} can have zero for both x and y, this would be multiplying by zero.");
			}

			return vector * (time * _speed);
		}
	}
}