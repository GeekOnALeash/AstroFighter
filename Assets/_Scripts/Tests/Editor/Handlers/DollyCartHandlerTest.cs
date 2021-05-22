using NUnit.Framework;

namespace Com.StellarPixels.AstroFighter.Tests.Handlers
{
	using System;
	using Cinemachine;
	using Com.StellarPixels.AstroFighter.Handlers;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	[TestFixture]
	public class DollyCartHandlerTest
	{
		private GameObject _gameObject;
		private DollyCartHandler _dollyCart;
		private CinemachineDollyCart _cinemachineDollyCart;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_dollyCart = _gameObject.AddComponent<DollyCartHandler>();
		}

		[SetUp]
		public void Setup()
		{
			_cinemachineDollyCart = _gameObject.AddComponent<CinemachineDollyCart>();
		}

		[TearDown]
		public void TearDown()
		{
			GameObject.DestroyImmediate(_cinemachineDollyCart);
			_cinemachineDollyCart = null;
		}

		[Test]
		public void ThrowsMissingComponentExceptionIfCinemachineDollyCartMissing()
		{
			GameObject.DestroyImmediate(_cinemachineDollyCart);
			Assert.Throws<MissingComponentException>(() => _dollyCart.Start());
		}

		[Test]
		public void ThrowsNullReferenceExceptionIfDollySpeedAtomIsNull()
		{
			_dollyCart.DollySpeed = null;
			Assert.Throws<NullReferenceException>(() => _dollyCart.Start());
		}

		[Test]
		public void ThrowsArgumentOutOfRangeExceptionIfSpeedIsZeroOnMovementStart()
		{
			var speed = ScriptableObject.CreateInstance<FloatVariable>();
			speed.Value = 0.0f;

			_dollyCart.DollySpeed = speed;

			_dollyCart.Start();
			Assert.Throws<ArgumentOutOfRangeException>(() => _dollyCart.StartMoving());
		}

		[Test]
		public void StartMovingSuccesfull()
		{
			var speed = ScriptableObject.CreateInstance<FloatVariable>();
			speed.Value = 5.0f;

			_dollyCart.DollySpeed = speed;

			_dollyCart.Start();
			Assert.IsTrue(_dollyCart.StartMoving());
		}
	}
}