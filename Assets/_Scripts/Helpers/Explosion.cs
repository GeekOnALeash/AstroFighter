namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.AstroFighter.Pooling;
	using JetBrains.Annotations;

	/// <summary>
	/// Explosion.
	/// </summary>
	public class Explosion : PoolableObject
	{
		/// <summary>
		/// Used as an animation function.
		/// </summary>
		[UsedImplicitly]
		public void Destroy()
		{
			gameObject.SetActive(false);
		}
	}
}