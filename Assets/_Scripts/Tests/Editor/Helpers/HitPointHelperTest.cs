namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using System;
	using Com.StellarPixels.AstroFighter.Helpers;
	using NUnit.Framework;
	using UnityAtoms.BaseAtoms;

	[TestFixture]
	public class HitPointHelperTest
	{
		private HitPointHelper _hitPointHelper;
		private IntReference hp;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			hp = new IntReference { Value = 100 };
			_hitPointHelper = new HitPointHelper(hp);
		}

		[SetUp]
		public void Setup()
		{
			hp.Value = 100;
		}

		[Test]
		public void HitPointsEqual100()
		{
			Assert.AreEqual(100, _hitPointHelper.HitPoints.Value);
		}

		[Test]
		public void HitPointsEqual50WhenIntReferenceValueSetInternally()
		{
			hp.Value = 50;
			Assert.AreEqual(50, _hitPointHelper.HitPoints.Value);
		}

		[Test]
		public void HitPointsEqual80When20DamageCaused()
		{
			_hitPointHelper.CauseDamage(20);
			Assert.AreEqual(80, _hitPointHelper.HitPoints.Value);
		}

		[Test]
		public void IsZeroSetToTrueWhenHitPointsIsZero()
		{
			_hitPointHelper.CauseDamage(100);
			Assert.IsTrue(_hitPointHelper.IsZero);
		}

		[Test]
		public void IsZeroSetToTrueWhenDestroyInstantly()
		{
			_hitPointHelper.DestroyInstantly();
			Assert.IsTrue(_hitPointHelper.IsZero);
		}

		[Test]
		public void ThrowsExceptionWhenNegativeValueSuppliedToCauseDamage()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _hitPointHelper.CauseDamage(-10));
		}

		[Test]
		public void ThrowsExceptionWhenZeroValueSuppliedToCauseDamage()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _hitPointHelper.CauseDamage(0));
		}
	}
}