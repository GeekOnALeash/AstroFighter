namespace Com.StellarPixels.AstroFighter.Tests.Handlers
{
	using System;
	using Com.StellarPixels.AstroFighter.Behaviours;
	using Com.StellarPixels.AstroFighter.Handlers;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using NSubstitute;
	using NUnit.Framework;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Tests the input handler.
	/// </summary>
	[TestFixture]
	public class InputHandlerTest
	{
		private GameObject _gameObject;
		private InputHandler _inputHandler;
		private IUnityService _unityService;

		/// <summary>
		/// One Time Setup.
		/// </summary>
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_inputHandler = _gameObject.AddComponent<InputHandler>();
		}

		/// <summary>
		/// Setup to be run before each test.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			_unityService = Substitute.For<IUnityService>();
			_inputHandler.UnityService = _unityService;
		}

		/// <summary>
		/// Tests that vertical input was not pressed.
		/// </summary>
		[Test]
		public void VerticalWasNotPressed()
		{
			Assert.IsFalse(_inputHandler.WasVerticalPressed());
		}

		/// <summary>
		/// Tests that horizontal input was not pressed.
		/// </summary>
		[Test]
		public void HorizontalWasNotPressed()
		{
			Assert.IsFalse(_inputHandler.WasHorizontalPressed());
		}

		/// <summary>
		/// Tests that horizontal input was pressed.
		/// </summary>
		[Test]
		public void HorizontalWasPressed()
		{
			_unityService.GetKey(KeyCode.UpArrow).Returns(true);
			Assert.IsTrue(_inputHandler.WasHorizontalPressed());
		}

		/// <summary>
		/// Tests that horizontal input was pressed.
		/// </summary>
		[Test]
		public void VerticalWasPressed()
		{
			_unityService.GetKey(KeyCode.UpArrow).Returns(true);
			Assert.IsTrue(_inputHandler.WasVerticalPressed());
		}

		[Test]
		public void ThrowsNullReferenceExceptionIfPressedAtomsVariablesNull()
		{
			Assert.Throws<NullReferenceException>(() => _inputHandler.SetInputs());
		}
	}
}