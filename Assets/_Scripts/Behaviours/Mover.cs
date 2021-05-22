// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Helpers;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Moves object.
	/// </summary>
	public sealed class Mover : MonoBehaviour
	{
		[SerializeField]
		private MoveDirection direction;

		[SerializeField]
		private FloatReference speed;

		private Movement _movement;
		private Vector2 _vector;

		[SuppressMessage("ReSharper", "SA1600", Justification = "Public for unit tests.")]
		public void Start()
		{
			_movement = new Movement(speed);
		}

		[ExcludeFromCodeCoverage]
		private void Update()
		{
			_vector = GetDirectionVector(direction);
			Move(_vector);
		}

		/// <summary>
		/// Gets vector from movement direction.
		/// </summary>
		/// <param name="newDirection">Movement direction.</param>
		/// <returns>Movement vector.</returns>
		/// <exception cref="ArgumentOutOfRangeException">Default value.</exception>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public static Vector2 GetDirectionVector(MoveDirection newDirection)
		{
			switch (newDirection)
			{
				case MoveDirection.Up:
					return new Vector2(0, 1);
				case MoveDirection.Down:
					return new Vector2(0, -1);
				case MoveDirection.Left:
					return new Vector2(-1, 0);
				case MoveDirection.Right:
					return new Vector2(1, 0);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		[ExcludeFromCodeCoverage]
		private void Move(Vector2 vector)
		{
			AddToPosition(_movement.CalculateVector(vector, Time.deltaTime));
		}

		[ExcludeFromCodeCoverage]
		private void AddToPosition(Vector3 position)
		{
			transform.position += position;
		}
	}
}