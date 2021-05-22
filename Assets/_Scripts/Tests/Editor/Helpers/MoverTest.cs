using NUnit.Framework;

namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using System;
	using Com.StellarPixels.AstroFighter.Behaviours;
	using Com.StellarPixels.AstroFighter.Helpers;
	using UnityEngine;

	[TestFixture]
	public class MoverTest
	{
		private GameObject _gameObject;
		private Mover _mover;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_mover = _gameObject.AddComponent<Mover>();
			_mover.Start();
		}

		/// <summary>
		/// Tests value of MoveDirection vector.
		/// </summary>
		[Test]
		public void DirectionVectorEquals_0_1_WhenMoveDirectionIsUp()
		{
			var moveDirection = Mover.GetDirectionVector(MoveDirection.Up);

			Vector2 expectedVector = new Vector2(0, 1);

			Assert.AreEqual(expectedVector, moveDirection);
		}

		/// <summary>
		/// Tests value of MoveDirection vector.
		/// </summary>
		[Test]
		public void DirectionVectorEquals_0_Negative1_WhenMoveDirectionIsDown()
		{
			var moveDirection = Mover.GetDirectionVector(MoveDirection.Down);

			Vector2 expectedVector = new Vector2(0, -1);

			Assert.AreEqual(expectedVector, moveDirection);
		}

		/// <summary>
		/// Tests value of MoveDirection vector.
		/// </summary>
		[Test]
		public void DirectionVectorEquals_1_0_WhenMoveDirectionIsRight()
		{
			var moveDirection = Mover.GetDirectionVector(MoveDirection.Right);

			Vector2 expectedVector = new Vector2(1, 0);

			Assert.AreEqual(expectedVector, moveDirection);
		}

		/// <summary>
		/// Tests value of MoveDirection vector.
		/// </summary>
		[Test]
		public void DirectionVectorEquals_Negative1_0_WhenMoveDirectionIsLeft()
		{
			var moveDirection = Mover.GetDirectionVector(MoveDirection.Left);

			Vector2 expectedVector = new Vector2(-1, 0);

			Assert.AreEqual(expectedVector, moveDirection);
		}

		/// <summary>
		/// Tests value of MoveDirection vector.
		/// </summary>
		[Test]
		public void ThrowsArgumentOutOfRangeExceptionWhenInvalidValueSetForMoveDirection()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Mover.GetDirectionVector((MoveDirection) int.MaxValue));
		}
	}
}