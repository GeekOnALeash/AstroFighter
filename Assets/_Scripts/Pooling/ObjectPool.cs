namespace Com.StellarPixels.AstroFighter.Pooling
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Individual pool.
	/// </summary>
	[Serializable]
	public class ObjectPool : MonoBehaviour
	{
		[SerializeField]
		private List<PoolableItem> itemsToPool;

		private Dictionary<string, List<PoolableObject>> _pool;

		private void Start()
		{
			InitialisePool();
		}

		/// <summary>
		/// Gets pooled object.
		/// </summary>
		/// <param name="poolName">Name of the pool.</param>
		/// <returns>Object from pool.</returns>
		[NotNull]
		[SuppressMessage("ReSharper", "SA1202", Justification = "Unity events first.")]
		internal PoolableObject GetPooledObject([NotNull] string poolName)
		{
			if (!_pool.ContainsKey(poolName))
			{
				throw new NullReferenceException("!_pool.ContainsKey(poolName)");
			}

			var pool = _pool[poolName];

			foreach (var item in pool)
			{
				if (item.gameObject.activeInHierarchy)
				{
					continue;
				}

				item.gameObject.SetActive(true);
				return item;
			}

			var newItem = CreateNewItem(itemsToPool[0]);
			newItem.gameObject.SetActive(true);

			return newItem;
		}

		private void ResetPool()
		{
			_pool = new Dictionary<string, List<PoolableObject>>(itemsToPool.Count);
		}

		private void InitialisePool()
		{
			ResetPool();

			if (itemsToPool.Count == 0)
			{
				Debug.Log("No items to pool.");
				return;
			}

			foreach (var item in itemsToPool)
			{
				if (item is null)
				{
					return;
				}

				if (!_pool.ContainsKey(item.PoolName))
				{
					_pool[item.PoolName] = new List<PoolableObject>(item.InitialPoolCapacity);
				}

				for (int id = 0; id < item.PreloadSize; id++)
				{
					CreateNewItem(item);
				}
			}
		}

		/// <summary>
		/// Creates a new poolable item.
		/// </summary>
		/// <returns>Newly pooled item.</returns>
		[NotNull]
		private PoolableObject CreateNewItem([NotNull] PoolableItem poolableItem)
		{
			var poolable = Instantiate(poolableItem.PoolableObject, transform, true);
			poolable.gameObject.SetActive(false);
			_pool[poolableItem.PoolName].Add(poolable);

			return poolable;
		}
	}
}