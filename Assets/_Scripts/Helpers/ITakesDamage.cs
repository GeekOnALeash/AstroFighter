namespace Com.StellarPixels.AstroFighter.Helpers
{
	/// <summary>
	/// Interface for objects that take damage.
	/// </summary>
	internal interface ITakesDamage
	{
		/// <summary>
		/// Cause damage to the object.
		/// </summary>
		/// <param name="amount">Amount of damage to cause.</param>
		void CauseDamage(int amount);

		/// <summary>
		/// Destroys the object instantly.
		/// </summary>
		void DestroyInstantly();
	}
}