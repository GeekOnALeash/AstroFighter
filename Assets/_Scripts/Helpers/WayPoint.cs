namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Path finding way point.
	/// </summary>
	public sealed class WayPoint : MonoBehaviour
	{
		[SerializeField]
		private float speed;

		/// <summary>
		/// Speed of travel.
		/// </summary>
		internal float Speed => speed;

		/// <summary>
		/// Gets the lerp velocity.
		/// </summary>
		/// <returns>WayPoint position.</returns>
		internal Vector2 GetPosition() => transform.position;
	}
}