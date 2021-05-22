namespace Com.StellarPixels.AstroFighter.Handlers
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Cinemachine;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Dolly cart handler.
	/// </summary>
	public sealed class DollyCartHandler : MonoBehaviour
	{
		[SerializeField]
		private bool startOnLoad;

		[SerializeField]
		private FloatVariable dollySpeed;

		private CinemachineDollyCart _dollyCart;

		/// <summary>
		/// Sets speed of the Dolly Cart.
		/// </summary>
		public FloatVariable DollySpeed
		{
			set => dollySpeed = value;
		}

		/// <summary>
		/// Unity Start event.
		/// </summary>
		/// <exception cref="MissingComponentException">Dolly cart null.</exception>
		/// <exception cref="NullReferenceException">Speed variable is null.</exception>
		public void Start()
		{
			_dollyCart = GetComponent<CinemachineDollyCart>();

			if (_dollyCart is null)
			{
				throw new MissingComponentException("CinemachineDollyCart is null but is required.");
			}

			if (dollySpeed is null)
			{
				throw new NullReferenceException("Dolly speed variable atom is null!");
			}

			if (startOnLoad)
			{
				StartMoving();
			}
		}

		/// <summary>
		/// Starts the dolly cart.
		/// </summary>
		/// <exception cref="NullReferenceException">CinemachineDollyCart is null but is required.</exception>
		/// <returns>True if value applied.</returns>
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public bool StartMoving()
		{
			if (dollySpeed.Value <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(dollySpeed.Value));
			}

			_dollyCart.m_Speed = dollySpeed.Value;

			return true;
		}
	}
}