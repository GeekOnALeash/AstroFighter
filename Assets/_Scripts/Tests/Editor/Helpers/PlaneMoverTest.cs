using NUnit.Framework;

namespace Com.StellarPixels.AstroFighter.Tests.Helpers
{
	using Com.StellarPixels.AstroFighter.Behaviours;
	using Com.StellarPixels.AstroFighter.Handlers;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	[TestFixture]
	public class PlaneMoverTest
	{
		private GameObject _gameObject;
		private Vector2Variable _movementAxis;
		private PlaneMover _planeMover;

		private GameObject _cameraGameObject;
		private CameraHandler _cameraHandler;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_gameObject = new GameObject();
			_planeMover = _gameObject.AddComponent<PlaneMover>();

			_movementAxis = ScriptableObject.CreateInstance<Vector2Variable>();

			_planeMover.MovementAxis = _movementAxis;

			_cameraGameObject = new GameObject();
			_cameraHandler = _cameraGameObject.AddComponent<CameraHandler>();
		}
	}
}