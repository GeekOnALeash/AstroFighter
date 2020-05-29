namespace Com.StellarPixels.AstroFighter.Editor.Tests
{
	using System;
	using Com.StellarPixels.AstroFighter.Helpers;
	using NUnit.Framework;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Tests the input handler.
	/// </summary>
	[TestFixture]
	public class InputHandlerTest : InputHandler
	{
		/// <summary>
		/// Tests that vertical input was not pressed.
		/// </summary>
		[Test]
		public void VerticalWasNotPressed()
		{
			Assert.IsFalse(WasVerticalPressed());
		}

		/// <summary>
		/// Tests that horizontal input was not pressed.
		/// </summary>
		[Test]
		public void HorizontalWasNotPressed()
		{
			Assert.IsFalse(WasHorizontalPressed());
		}

		/// <summary>
		/// If atom variables are not set returns null.
		/// </summary>
		[Test]
		public void AtomVariableThrowsNull()
		{
			Assert.Throws<NullReferenceException>(SetInputs);
		}

		/// <summary>
		/// Setup for tests.
		/// </summary>
		private void Setup()
		{
			MovementAxis = ScriptableObject.CreateInstance<Vector2Variable>();
			VerticalPressed = ScriptableObject.CreateInstance<BoolVariable>();
			HorizontalPressed = ScriptableObject.CreateInstance<BoolVariable>();
		}
	}
}