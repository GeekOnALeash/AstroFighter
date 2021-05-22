namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.AstroFighter.Helpers;
	using Com.StellarPixels.AstroFighter.Interfaces;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for player input.
	/// </summary>
	public class InputHandler : MonoBehaviour
	{
		[SerializeField]
		private Vector2Variable movementAxis;

		[SerializeField]
		private BoolVariable verticalPressed;

		[SerializeField]
		private BoolVariable horizontalPressed;

		private IUnityService _unityService;

		/// <inheritdoc cref="IUnityService"/>
		[ExcludeFromCodeCoverage]
		public IUnityService UnityService
		{
			set => _unityService = value;
		}

		[ExcludeFromCodeCoverage]
		private void Start()
		{
			// ReSharper disable once ConvertIfStatementToNullCoalescingAssignment
			if (_unityService is null)
			{
				_unityService = new UnityService();
			}
		}

		[ExcludeFromCodeCoverage]
		private void Update()
		{
			SetInputs();
			SetAxis();
		}

		/// <summary>
		/// Was vertical key pressed.
		/// </summary>
		/// <returns>True if vertical key was pressed.</returns>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public bool WasVerticalPressed()
			=> _unityService.GetKey(KeyCode.UpArrow) || _unityService.GetKey(KeyCode.DownArrow);

		/// <summary>
		/// Was horizontal key pressed.
		/// </summary>
		/// <returns>True if horizontal key was pressed.</returns>
		public bool WasHorizontalPressed()
			=> _unityService.GetKey(KeyCode.UpArrow) || _unityService.GetKey(KeyCode.DownArrow);

		/// <summary>
		/// Sets values to input bools.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void SetInputs()
		{
			if (horizontalPressed is null || verticalPressed is null)
			{
				throw new NullReferenceException();
			}

			verticalPressed.SetValue(WasVerticalPressed());
			horizontalPressed.SetValue(WasHorizontalPressed());
		}

		[ExcludeFromCodeCoverage]
		private void SetAxis()
		{
			var axis = new Vector2(_unityService.GetAxis("Horizontal"), _unityService.GetAxis("Vertical"));
			movementAxis.SetValue(axis);
		}
	}
}