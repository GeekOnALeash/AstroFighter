// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Handlers;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="IMoveable" />
	/// <summary>
	/// Moves the ship.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class PlaneMover : MonoBehaviour
	{
		private const float DollyCartSpeedDivisor = 9f;

		[SerializeField]
		private FloatVariable dollySpeed;

		[SerializeField]
		private CameraHandler cameraHandler;

		[SerializeField]
		private float lerpDuration = 6.0F;

		[SerializeField]
		private BoolVariable verticalPressed;

		[SerializeField]
		private Vector2Variable movementAxis;

		private Vector2 _screenPos;

		private IUnityService _unityService;

		public Vector2Variable MovementAxis
		{
			get => movementAxis;
			set => movementAxis = value;
		}

		/// <summary>
		/// Unity Start event.
		/// </summary>
		public void Start()
		{
			// ReSharper disable once ConvertIfStatementToNullCoalescingAssignment
			if (_unityService is null)
			{
				_unityService = new UnityService();
			}
		}

		private void FixedUpdate()
		{
			DoMovement();
		}

		/// <summary>
		/// Do the movement.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void DoMovement()
		{
			Vector2 rbPos = transform.position;

			Vector2 newVector = movementAxis.Value;
			newVector.y = verticalPressed.Value ? movementAxis.Value.y : dollySpeed.Value / DollyCartSpeedDivisor;
			newVector *= lerpDuration * Time.deltaTime;
			rbPos += newVector;
			Vector2 pos = cameraHandler.GetClampedPosition(rbPos);

			var lerp = Vector3.Lerp(
									rbPos,
									cameraHandler.GetViewportToWorldPoint(pos),
									_unityService.GetDeltaTime() * lerpDuration);

			transform.position = lerp;
		}
	}
}
