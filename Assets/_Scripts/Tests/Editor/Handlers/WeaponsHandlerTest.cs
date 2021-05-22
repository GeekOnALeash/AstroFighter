namespace Com.StellarPixels.AstroFighter.Tests.Handlers
{
	using System;
	using Com.StellarPixels.AstroFighter.Behaviours;
	using NUnit.Framework;
	using UnityEngine;

	[TestFixture]
	public class WeaponsHandlerTest
	{
		private GameObject _gameObject;
		private Weapons _weaponsHandler;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_weaponsHandler = _gameObject.AddComponent<Weapons>();
		}

		[Test]
		public void ThrowsNullReferenceExceptionIfFirringPointsIsEmpty()
		{
			Assert.Throws<NullReferenceException>(() => _weaponsHandler.IncreaseFirePower(true));
		}
	}
}