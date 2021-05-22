// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using Com.StellarPixels.AstroFighter.Behaviours;
	using Com.StellarPixels.AstroFighter.Helpers;
	using NUnit.Framework;
	using UnityEngine;

	/// <summary>
	/// Tests for the WayPoint class.
	/// </summary>
	[TestFixture]
	public class WayPointTest
	{
		private GameObject _gameObject;
		private WayPoint _wayPoint;

		/// <summary>
		/// One time setup for the tests.
		/// </summary>
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_wayPoint = _gameObject.AddComponent<WayPoint>();
		}

		/// <summary>
		/// Tests if GetPosition is equal to Vector2.zero.
		/// </summary>
		[Test]
		public void PositionIsSetToDefaultTransformPosition()
		{
			Assert.AreEqual(Vector2.zero, _wayPoint.GetPosition());
		}

		/// <summary>
		/// Tests if the speed is set to the default value of 0.35f.
		/// </summary>
		[Test]
		public void SpeedEquals0Point35DefaultValue()
		{
			var tmp = _wayPoint.Speed;
			Assert.AreEqual(0.35f, _wayPoint.Speed);
		}
	}
}