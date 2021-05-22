namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System.Diagnostics.CodeAnalysis;
	using Cinemachine;
	using Com.StellarPixels.AstroFighter.Handlers;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Switches virtual cameras.
	/// </summary>
	public sealed class VirtualCamSwitcher : MonoBehaviour
	{
		[SerializeField]
		private CinemachineVirtualCamera vcam1;

		[SerializeField]
		private CinemachineVirtualCamera vcam2;

		[SerializeField]
		private DollyCartHandler dollyCart;

		[SuppressMessage("ReSharper", "InvertIf", Justification = "Update method.")]
		private void Update()
		{
			// TODO: this is temporary to test switching.
			if (Input.GetKey(KeyCode.Z))
			{
				vcam1.Priority = 0;
				vcam2.Priority = 10;
				dollyCart.StartMoving();
			}
		}
	}
}