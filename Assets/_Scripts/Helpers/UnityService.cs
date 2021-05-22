namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.AstroFighter.Interfaces;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Access class for unity services.
	/// </summary>
	public class UnityService : IUnityService
	{
		/// <inheritdoc/>
		public float GetDeltaTime() => Time.deltaTime;

		/// <inheritdoc/>
		public float GetAxis(string axisName) => Input.GetAxis(axisName);

		public bool GetKey(KeyCode keyCode) => Input.GetKey(keyCode);
	}
}