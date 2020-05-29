namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Cinemachine;
	using UnityEngine;

	/// <summary>
	/// An add-on module for Cinemachine Virtual Camera that locks the camera's X co-ordinate.
	/// </summary>
	[ExecuteInEditMode]
	[SaveDuringPlay]
	[AddComponentMenu("")] // Hide in menu
	public class LockCinemachineCameraX : CinemachineExtension
	{
		[Tooltip("Lock the camera's X position to this value")]
		[SerializeField]
		private float xPosition;

		/// <inheritdoc cref="CinemachineExtension.PostPipelineStageCallback"/>
		protected override void PostPipelineStageCallback(
			CinemachineVirtualCameraBase vcam,
			CinemachineCore.Stage stage,
			ref CameraState state,
			float deltaTime)
		{
			if (!enabled || stage != CinemachineCore.Stage.Body)
			{
				return;
			}

			var pos = state.RawPosition;
			pos.x = xPosition;
			state.RawPosition = pos;
		}
	}
}