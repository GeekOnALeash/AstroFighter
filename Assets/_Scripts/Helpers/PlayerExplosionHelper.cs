namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc/>
	public sealed class PlayerExplosionHelper : ExplosionHelper
	{
		[SerializeField]
		private BoolReference playerDestroyed;

		/// <inheritdoc/>
		public override void Explode()
		{
			playerDestroyed.Value = true;
			base.Explode();
		}
	}
}