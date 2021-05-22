namespace Com.StellarPixels.AstroFighter.Scriptable.Planes
{
	using Com.StellarPixels.AstroFighter.Pooling;
	using UnityEngine;

	[CreateAssetMenu(fileName = "NewProjectile", menuName = "Scriptable/Planes/Projectile", order = 2)]
	public sealed class ScriptableProjectile : ScriptableObject
	{
		[SerializeField]
		private PoolableItem _poolableItem;

		/// <summary>
		/// Gets the poolable item.
		/// </summary>
		public PoolableItem PoolableItem => _poolableItem;

		[SerializeField]
		private int firingPoints = 3;

		public int FiringPoints => firingPoints;

		[SerializeField]
		private int allowedWeaponSlots;

		public int AllowedWeaponSlots => allowedWeaponSlots;

		[SerializeField]
		private int weaponSlotsToStartWith;

		public int WeaponSlotsToStartWith => weaponSlotsToStartWith;

		[SerializeField]
		private bool autoFire;

		public bool AutoFire => autoFire;

		[SerializeField]
		private float firingRate;

		public float FiringRate => firingRate;
	}
}