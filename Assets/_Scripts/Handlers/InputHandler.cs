namespace Com.StellarPixels.AstroFighter.Handlers
{
	using System.Diagnostics.CodeAnalysis;
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

		/// <summary>
		/// Sets movement axis property to be used for unit tests.
		/// </summary>
		protected Vector2Variable MovementAxis
		{
			set => movementAxis = value;
		}

		/// <summary>
		/// Sets verticalPressed property to be used for unit tests.
		/// </summary>
		protected BoolVariable VerticalPressed
		{
			set => verticalPressed = value;
		}

		/// <summary>
		/// Sets horizontalPressed property to be used for unit tests.
		/// </summary>
		protected BoolVariable HorizontalPressed
		{
			set => horizontalPressed = value;
		}

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
		protected static bool WasVerticalPressed()
			=> Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

		/// <summary>
		/// Was horizontal key pressed.
		/// </summary>
		/// <returns>True if horizontal key was pressed.</returns>
		protected static bool WasHorizontalPressed()
			=> Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

		/// <summary>
		/// Sets values to input bools.
		/// </summary>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		protected void SetInputs()
		{
			verticalPressed.SetValue(WasVerticalPressed());
			horizontalPressed.SetValue(WasHorizontalPressed());
		}

		private void SetAxis()
		{
			var axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			movementAxis.SetValue(axis);
		}
	}
}