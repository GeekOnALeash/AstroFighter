namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System;
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
		public void Start()
		{
			if (slider == null)
			{
				slider = gameObject.AddComponent<Slider>();
			}
		}

		/// <summary>
		/// Resets the slider to default value.
		/// </summary>
		public void ResetSlider()
		{
			slider.wholeNumbers = true;
			slider.maxValue = 100;
			slider.value = 100;
		}

		/// <summary>
		/// Gets slider value.
		/// </summary>
		/// <returns>Value of the slider.</returns>
		public int GetSliderValue() => (int) slider.value;

		/// <summary>
		/// Sets slider value to amount.
		/// </summary>
		/// <param name="amount">Amount to set to slider.</param>
		public void SetSliderValue(int amount)
		{
			if (amount < 0)
			{
				throw new ArgumentException($"{nameof(amount)} can not be negative, to decrease us: {nameof(DecreaseValueByAmount)} method.");
			}

			SetValue(ClampAmount(amount));
		}

		/// <summary>
		/// Decrease slider by set amount.
		/// </summary>
		/// <param name="amount">Amount to decrease the slider by.</param>
		public void DecreaseValueByAmount(int amount) => SetValue(ClampAmount((int) slider.value - amount));

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