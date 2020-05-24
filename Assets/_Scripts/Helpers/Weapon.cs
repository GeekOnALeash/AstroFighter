namespace Com.StellarPixels.AstroFighter.Helpers
{
	using System.Diagnostics.CodeAnalysis;
	using Com.StellarPixels.Pooling;
	using UnityAtoms.BaseAtoms;
	using UnityEngine;

	/// <inheritdoc cref="IWeapon" />
	/// <summary>
	/// Weapon that can be fired.
	/// </summary>
	[RequireComponent(typeof(AudioSource))]
	public sealed class Weapon : MonoBehaviour, IWeapon
	{
		[SerializeField]
		private Bullet bullet;

		[SerializeField]
		private bool autoFire;

		[SerializeField]
		private FloatReference fireRate;

		private AudioSource _audioSource;

		private float _timer;

		private void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		private void Update()
		{
			AttemptToFire();
		}

		private void AttemptToFire()
		{
			if (autoFire)
			{
				_timer -= Time.deltaTime;

				if (!(_timer < 0))
				{
					return;
				}

				Fire();

				_timer = fireRate;

				return;
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Fire();
			}
		}

		/// <inheritdoc />
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		public void Fire()
		{
			if (bullet is null)
			{
				return;
			}

			var newBullet = PrefabPool.Get(bullet);
			newBullet.gameObject.transform.position = transform.position;

			PlaySound();
		}

		private void PlaySound()
		{
			// ReSharper disable once UseNullPropagation
			if (_audioSource is null)
			{
				return;
			}

			_audioSource.Play();
		}
	}
}
