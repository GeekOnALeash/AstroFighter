// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
namespace Com.StellarPixels.Pooling
{
	using UnityEngine;

	/// <inheritdoc cref="IPoolableObject" />
	/// <summary>
	/// Poolable objects base class.
	/// </summary>
	public sealed class PoolableObject : MonoBehaviour, IPoolableObject
	{
		/// <inheritdoc/>
		public IPoolableObject Prefab { get; set; }
	}
}
