namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using System;
	using Com.StellarPixels.AstroFighter.Helpers;
	using NUnit.Framework;
	using UnityEngine;

	/// <summary>
	/// Test for the health slider class.
	/// </summary>
	public sealed class HealthSliderTest
	{
		private GameObject _gameObject;
		private HealthSlider _healthSlider;

		/// <summary>
		/// One time setup for the tests.
		/// </summary>
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_healthSlider = _gameObject.AddComponent<HealthSlider>();
			_healthSlider.Start();
		}

		/// <summary>
		/// Setup to be run before each test.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			_healthSlider.ResetSlider();
		}

		/// <summary>
		/// Tests the slider is equal to 100.
		/// </summary>
		[Test]
		public void FillEquals100()
		{
			Assert.AreEqual(100, _healthSlider.GetSliderValue());
		}

		/// <summary>
		/// Tests the slider is equal to 80, after setting value to 80.
		/// </summary>
		[Test]
		public void FillEquals80AfterSettingValue()
		{
			_healthSlider.SetSliderValue(80);
			Assert.AreEqual(80, _healthSlider.GetSliderValue());
		}

		/// <summary>
		/// Tests the slider is equal to 80 after decreasing by 20.
		/// </summary>
		[Test]
		public void FillEquals80AfterDecreasingValueBy20()
		{
			_healthSlider.DecreaseValueByAmount(20);
			Assert.AreEqual(80, _healthSlider.GetSliderValue());
		}

		/// <summary>
		/// Test the slider can not be set below negative.
		/// </summary>
		[Test]
		public void ThrowsExceptionIfNegativeValueUsedWithSetSliderValueMethod()
		{
			Assert.Throws<ArgumentException>(() => _healthSlider.SetSliderValue(-20));
		}

		/// <summary>
		/// Test the slider can not be set above max value.
		/// </summary>
		[Test]
		public void IsClampedToMaxWhenValueSetHigher()
		{
			_healthSlider.SetSliderValue(200);
			Assert.AreEqual(100, _healthSlider.GetSliderValue());
		}

		/// <summary>
		/// Test the slider can not be decreased below negative.
		/// </summary>
		[Test]
		public void IsClampedToZeroWhenValueDecreasedBelowNegative()
		{
			_healthSlider.DecreaseValueByAmount(120);
			Assert.AreEqual(0, _healthSlider.GetSliderValue());
		}
	}
}
