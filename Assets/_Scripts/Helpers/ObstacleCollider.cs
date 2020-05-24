namespace Com.StellarPixels.AstroFighter.Helpers
{
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Helper for collision with an obstacle.
	/// </summary>
	public sealed class ObstacleCollider : MonoBehaviour
	{
		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			var takesDamage = other.gameObject.GetComponent<ITakesDamage>();
			takesDamage?.DestroyInstantly();
		}
	}
}
