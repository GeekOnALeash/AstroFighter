namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using Com.StellarPixels.AstroFighter.Behaviours;
	using Com.StellarPixels.AstroFighter.Helpers;
	using NUnit.Framework;
	using UnityEngine;

	/// <summary>
	/// Tests for the Explosion class.
	/// </summary>
	[TestFixture]
	public class ExplosionTest
	{
		private GameObject _gameObject;
		private Explosion _explosion;

		/// <summary>
		/// One time setup for the tests.
		/// </summary>
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_explosion = _gameObject.AddComponent<Explosion>();
		}

		/// <summary>
		/// Test that the gameObject is active.
		/// </summary>
		[Test]
		public void GameObjectIsSetActive()
		{
			Assert.IsTrue(_gameObject.activeSelf);
		}

		/// <summary>
		/// Test that the gameObject is inactive after Destroy is called.
		/// </summary>
		[Test]
		public void GameObjectIsSetToInactiveWhenDestroyIsCalled()
		{
			_explosion.Destroy();
			Assert.IsFalse(_gameObject.activeSelf);
		}
	}
}