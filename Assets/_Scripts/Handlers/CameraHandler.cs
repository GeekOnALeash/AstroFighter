namespace Com.StellarPixels.AstroFighter.Handlers
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for the camera (Not cinemachine vcam).
	/// </summary>
	[RequireComponent(typeof(Camera))]
	public sealed class CameraHandler : MonoBehaviour
	{
		private const float BoundsMin = 0.14f;
		private const float BoundsMax = 0.86f;

		private Camera _camera;

		private void Awake()
		{
			_camera = GetComponent<Camera>();
		}

		/// <summary>
		/// Clamps position to camera bounds.
		/// </summary>
		/// <param name="positionToClamp">Position to clamp.</param>
		/// <returns>Clamped position.</returns>
		internal Vector2 GetClampedPosition(Vector2 positionToClamp)
		{
			Vector2 newPosition = _camera.WorldToViewportPoint(positionToClamp);
			newPosition.x = Mathf.Clamp(newPosition.x, BoundsMin, BoundsMax);
			newPosition.y = Mathf.Clamp(newPosition.y, BoundsMin, BoundsMax);

			return newPosition;
		}

		/// <summary>
		/// Gets ViewportToWorldPoint from Camera component.
		/// </summary>
		/// <param name="position">Position to get.</param>
		/// <returns>ViewportToWorldPoint.</returns>
		internal Vector2 GetViewportToWorldPoint(Vector2 position)
			=> _camera.ViewportToWorldPoint(position);
	}
}