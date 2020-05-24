// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Moves object.
	/// </summary>
	public sealed class Mover : MonoBehaviour
	{
		[SerializeField]
		private Vector2 speed = new Vector2(0.0f, 2.0f);

		private Rigidbody2D _rigidbody2D;
		private bool _stopMovement;

		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			DoMovement();
		}

		private void DoMovement()
		{
			if (_stopMovement || _rigidbody2D is null)
			{
				return;
			}

			_rigidbody2D.velocity = speed;
		}

		private void StopMovement()
		{
			_stopMovement = true;

			if (_rigidbody2D is null)
			{
				return;
			}

			_rigidbody2D.velocity = Vector2.zero;
			_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}
}