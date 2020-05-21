namespace Com.StellarPixels.AstroFighter.Handlers
{
	using Com.StellarPixels.AstroFighter.Scriptable.System;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for the camera (Not cinemachine vcam).
	/// </summary>
	[RequireComponent(typeof(Camera))]
	public sealed class CameraHandler : MonoBehaviour
	{
		private Camera _camera;

		private void Awake()
		{
			_camera = GetComponent<Camera>();
		}

		private void Start()
		{
			SystemVariables.Instance.mainCamera = _camera;
		}
	}
}