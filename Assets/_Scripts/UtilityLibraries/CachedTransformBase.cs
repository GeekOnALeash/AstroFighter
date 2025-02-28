// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Cache for gameObject transform.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class CachedTransformBase : MonoBehaviour
	{
		private Transform _thisTransform;

		// ReSharper disable once InconsistentNaming
		protected new Transform transform
		{
			get
			{
				if (_thisTransform == null)
				{
					_thisTransform = base.transform;
				}

				return _thisTransform;
			}
		}
	}
}