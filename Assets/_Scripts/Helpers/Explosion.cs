namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.Pooling;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <summary>
	/// Explosion.
	/// </summary>
	public class Explosion : MonoBehaviour, IPoolableObject
	{
		/// <summary>
		/// Used as an animation function.
		/// </summary>
		[UsedImplicitly]
		public void Destroy()
		{
			PrefabPool.Return(this);
		}

		public IPoolableObject Prefab { get; set; }
	}
}