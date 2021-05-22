namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using Com.StellarPixels.AstroFighter.Pooling;
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Helper for building explosions.
	/// </summary>
	public sealed class BuildingExplosionHelper : ExplosionHelper
	{
		[SerializeField]
		private UnityEvent onDestroyed;

		/// <inheritdoc />
		/// <summary>
		/// Explode the gameObject.
		/// </summary>
		public override void Explode(bool objectDestroyed)
		{
			if (!objectDestroyed)
			{
				return;
			}

			PoolBehaviour.Instance.GetExplosionAtPosition(Explosion.PoolName, transform.position);
			onDestroyed.Invoke();
			enabled = false;
		}
	}
}