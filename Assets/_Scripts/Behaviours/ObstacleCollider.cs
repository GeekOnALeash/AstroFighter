namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using Com.StellarPixels.AstroFighter.Interfaces;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Helper for collision with an obstacle.
	/// </summary>
	public sealed class ObstacleCollider : MonoBehaviour
	{
		[SerializeField]
		private bool destroySelfAswell;

		private void OnCollisionEnter2D([NotNull] Collision2D other)
		{
			var takesDamage = other.gameObject.GetComponent<ITakesDamage>();
			takesDamage?.DestroyInstantly();

			if (!destroySelfAswell)
			{
				return;
			}

			var selfTakesDamage = gameObject.GetComponent<ITakesDamage>();
			selfTakesDamage?.DestroyInstantly();
		}
	}
}
