namespace Com.StellarPixels.AstroFighter.Handlers
{
	using System;
	using Com.StellarPixels.AstroFighter.Helpers;
	using UnityEngine;

	public class HealthHandler : MonoBehaviour
	{
		private HitPointHelper _hpHelper;

		private void Start()
		{
			_hpHelper = new HitPointHelper();
		}
	}
}