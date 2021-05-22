using NUnit.Framework;

namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using System;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using NSubstitute;
	using UnityEngine;
	using UnityEngine.TestTools;

	[TestFixture]
	public class MovementTest
	{
		private Movement _movement;
		private float _speed = 5.0f;
		private float _time = 2.0f;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_movement = new Movement(_speed);
		}

		[Test]
		public void SpeedIsSetTo5()
		{
			Assert.AreEqual(5.0f, _movement.Speed);
		}

		[Test]
		public void CalculatedVectorIsNotSameAsSuppliedVecrtor()
		{
			Vector2 vector = Vector2.one;
			Assert.AreNotEqual(vector, _movement.CalculateVector(vector, _time));
		}

		/// <summary>
		/// If the supplied vector has zero for both x and y, throw exception.
		/// </summary>
		[Test]
		public void ThrowsExceptionWhenZeroValuedVectorIsSupplied()
		{
			Vector2 zeroVector = Vector2.zero;
			Assert.Throws<ArgumentOutOfRangeException>(() => _movement.CalculateVector(zeroVector, _time));
			var unityService = Substitute.For<IUnityService>();
		}
	}
}