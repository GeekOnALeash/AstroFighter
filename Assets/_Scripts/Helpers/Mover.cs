// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.UtilityLibraries.Attributes;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Moves object.
	/// </summary>
	public sealed class Mover : MonoBehaviour
	{
		[SerializeField]
		private bool useDirectVector;

		[SerializeField]
		[ShowWhen(nameof(useDirectVector), false)]
		private MoveDirection direction;

		[SerializeField]
		[ShowWhen(nameof(useDirectVector))]
		private Vector2 vector = new Vector2(0.0f, 10.0f);

		[SerializeField]
		[ShowWhen(nameof(useDirectVector), false)]
		private float speed = 10f;

		private void Update()
		{
			DoMovement();
		}

		private void DoMovement()
		{
			if (useDirectVector)
			{
				Move(vector);
				return;
			}

			switch (direction)
			{
				case MoveDirection.Up:
					MoveVertical(speed);
					return;
				case MoveDirection.Down:
					MoveVertical(-speed);
					return;
				case MoveDirection.Left:
					MoveHorizontal(-speed);
					return;
				case MoveDirection.Right:
					MoveHorizontal(speed);
					return;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		/// <summary>
		/// Move object.
		/// </summary>
		/// <param name="velocity">Velocity to move object.</param>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		private void Move(Vector2 velocity)
		{
			MoveVertical(velocity.y);
			MoveHorizontal(velocity.x);
		}

		private void MoveVertical(float velocity)
		{
			var positionToAdd = transform.up * (Time.deltaTime * velocity);
			AddToPosition(positionToAdd);
		}

		private void MoveHorizontal(float velocity)
		{
			var positionToAdd = transform.right * (Time.deltaTime * velocity);
			AddToPosition(positionToAdd);
		}

		private void AddToPosition(Vector3 position)
		{
			transform.position += position;
		}
	}
}