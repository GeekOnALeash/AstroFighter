namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.Pooling;
	using UnityEngine;

	/// <inheritdoc cref="IExplode" />
	/// <summary>
	/// Helper for objects that can be exploded.
	/// </summary>
	public class ExplosionHelper : MonoBehaviour, IExplode
	{
		[SerializeField]
		private Explosion explosion;

		/// <inheritdoc />
		/// <summary>
		/// Explode the gameObject.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public virtual void Explode()
		{
			var test = PrefabPool.Get(explosion);
			test.gameObject.transform.position = transform.position;

			var poolable = gameObject.GetComponent<IPoolableObject>();

			if (!(poolable is null))
			{
				PrefabPool.Return(poolable);
				return;
			}

			Destroy(gameObject);
		}
	}
}
