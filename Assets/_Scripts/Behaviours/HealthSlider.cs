namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using UnityEngine;
	using UnityEngine.UI;

	/// <inheritdoc />
	/// <summary>
	/// Controls the values of the health slider bar.
	/// </summary>
	public sealed class HealthSlider : MonoBehaviour
	{
		[SerializeField]
		private Slider slider;

		/// <inheritdoc cref="Start"/>
		private void Start()
		{
			if (slider == null)
			{
				slider = gameObject.AddComponent<Slider>();
			}
		}

		/// <summary>
		/// Sets slider value to amount.
		/// </summary>
		/// <param name="amount">Amount to set to slider.</param>
		public void SetSliderValue(int amount)
		{
			if (amount < 0)
			{
				return;
			}

			SetValue(ClampAmount(amount));
		}

		/// <summary>
		/// Restricts the amount to correct allowed values.
		/// </summary>
		/// <param name="amount">Amount to apply to slider.</param>
		/// <returns>Clamped amount.</returns>
		private int ClampAmount(int amount)
		{
			if (amount < 0)
			{
				return 0;
			}

			if (amount >= slider.maxValue)
			{
				return (int) slider.maxValue;
			}

			return amount;
		}

		private void SetValue(int amount)
		{
			slider.value = amount;
		}
	}
}