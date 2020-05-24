// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.AstroFighter.Scriptable.System;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;
	using UnityEngine.Assertions;

	/// <inheritdoc />
	/// <summary>
	/// Moves the ship.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class PlaneMover : MonoBehaviour
	{
		private const float BoundsMin = 0.14f;
		private const float BoundsMax = 0.86f;

		// TODO: Figure a way to calculate this based on the dolly cart speed and loosely coupling them, as the dolly speed will affect how this will look.
		private const float DefaultVertical = 0.5f;

		[SerializeField]
		private float lerpDuration = 6.0F;

		[SerializeField]
		private BoolVariable verticalPressed;

		[SerializeField]
		private Vector2Variable movementAxis;

		private Rigidbody2D _rigidbody2D;
		private Vector2 _screenPos;

		private void Start()
		{
			_rigidbody2D = GetComponent<Rigidbody2D>();
			Assert.IsNotNull(_rigidbody2D, "_rigidbody2D is null");
		}

		private void FixedUpdate()
		{
			DoMovement();
		}

		/// <summary>
		/// Do the movement.
		/// </summary>
		private void DoMovement()
		{
			var rbPos = _rigidbody2D.position;

			Vector2 newVector = movementAxis.Value;
			newVector.y = verticalPressed.Value ? movementAxis.Value.y : DefaultVertical;
			newVector *= lerpDuration * Time.deltaTime;
			rbPos += newVector;

			Vector2 pos = SystemVariables.Instance.mainCamera.WorldToViewportPoint(rbPos);
			pos.x = Mathf.Clamp(pos.x, BoundsMin, BoundsMax);
			pos.y = Mathf.Clamp(pos.y, BoundsMin, BoundsMax);

			var lerp = Vector3.Lerp(
									rbPos,
									SystemVariables.Instance.mainCamera.ViewportToWorldPoint(pos),
									Time.deltaTime * lerpDuration);

			_rigidbody2D.position = lerp;
		}
	}
}
