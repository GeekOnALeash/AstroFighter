namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.AstroFighter.Pooling;
	using JetBrains.Annotations;

	/// <inheritdoc />
	/// <summary>
	/// Explosion.
	/// </summary>
	public sealed class Explosion : PoolableObject
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