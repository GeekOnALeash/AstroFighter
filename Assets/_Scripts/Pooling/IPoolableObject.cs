// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
namespace Com.StellarPixels.Pooling
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEngine;

	/// <summary>
	/// An object which can be stored in a <see cref="PrefabPool"/>.
	/// </summary>
	public interface IPoolableObject
	{
		/// <summary>
		/// Gets or sets the prefab this object is based on.
		/// </summary>
		IPoolableObject Prefab { get; set; }

		/// <summary>
		/// Gets the gameObject this IPoolableObject is connected to.
		/// </summary>
		[SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Needs to be lowercase.")]
		[SuppressMessage("ReSharper", "SA1300", Justification = "Needs to be lowercase.")]
		GameObject gameObject { get; }
	}
}
