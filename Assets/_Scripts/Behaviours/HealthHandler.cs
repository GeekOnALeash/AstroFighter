namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="ITakesDamage" />
	/// <summary>
	/// Handler for object health.
	/// </summary>
	public class HealthHandler : MonoBehaviour, ITakesDamage
	{
		[SerializeField]
		private IntReference hitPoints;

		private HitPointHelper _hpHelper;

		private void Start()
		{
			_hpHelper = new HitPointHelper(hitPoints);
		}

		/// <inheritdoc/>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void CauseDamage(int amount)
		{
			_hpHelper.CauseDamage(amount);

			if (_hpHelper.IsZero)
			{
				Destroy();
			}
		}

		public void DestroyInstantly()
		{
			_hpHelper.DestroyInstantly();
			Destroy();
		}

		public virtual void Destroy()
		{
			IExplode explode = GetComponent<IExplode>();
			explode.Explode(true);
		}
	}
}