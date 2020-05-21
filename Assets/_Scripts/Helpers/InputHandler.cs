namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Handler for player input.
	/// </summary>
	public sealed class InputHandler : MonoBehaviour
	{
		[SerializeField]
		private Vector2Variable movementAxis;

		[SerializeField]
		private BoolVariable verticalPressed;

		[SerializeField]
		private BoolVariable horizontalPressed;

		private void Update()
		{
			verticalPressed.SetValue(WasVerticalPressed());
			horizontalPressed.SetValue(WasHorizontalPressed());

			SetAxis();
		}

		private void SetAxis()
		{
			var axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			movementAxis.SetValue(axis);
		}

		/// <summary>
		/// Was vertical key pressed.
		/// </summary>
		/// <returns>True if vertical key was pressed.</returns>
		private static bool WasVerticalPressed()
			=> Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

		/// <summary>
		/// Was horizontal key pressed.
		/// </summary>
		/// <returns>True if horizontal key was pressed.</returns>
		private static bool WasHorizontalPressed()
			=> Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);
	}
}