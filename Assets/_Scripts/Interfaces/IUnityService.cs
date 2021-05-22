namespace Com.StellarPixels.AstroFighter.Interfaces
{
	using UnityEngine;

	/// <summary>
	/// Interface for unity services.
	/// </summary>
	public interface IUnityService
	{
		/// <summary>
		/// Gets the delta time.
		/// </summary>
		/// <returns>Delta time.</returns>
		float GetDeltaTime();

		/// <summary>
		/// Gets the axis of input.
		/// </summary>
		/// <param name="axisName">Axis name.</param>
		/// <returns>Axis value.</returns>
		float GetAxis(string axisName);

		/// <summary>
		/// Checks if key was pressed.
		/// </summary>
		/// <param name="keyCode">Key to check.</param>
		/// <returns>True if pressed.</returns>
		bool GetKey(KeyCode keyCode);
	}
}