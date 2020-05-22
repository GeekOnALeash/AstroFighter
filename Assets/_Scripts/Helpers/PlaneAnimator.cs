namespace Com.StellarPixels.AstroFighter.Helpers
{
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Animator helper for ships.
	/// </summary>
	[RequireComponent(typeof(Animator))]
	public sealed class PlaneAnimator : MonoBehaviour
	{
		private static readonly int __HorizontalAxis = Animator.StringToHash("horizontalAxis");

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Vector2Variable movementAxis;

		private void FixedUpdate()
		{
			DoAnimations();
		}

		private void DoAnimations()
		{
			animator.SetFloat(__HorizontalAxis, movementAxis.Value.x);
		}
	}
}