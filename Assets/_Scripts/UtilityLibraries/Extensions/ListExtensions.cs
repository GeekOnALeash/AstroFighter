// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Extensions
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;

	/// <summary>
	/// Extensions for list collection.
	/// </summary>
	internal static class ListExtensions
	{
		/// <summary>
		/// Converts an list to an array.
		/// </summary>
		/// <param name="source">List collection.</param>
		/// <param name="count">Size.</param>
		/// <typeparam name="T">Type of the list.</typeparam>
		/// <returns>Array from list.</returns>
		/// <exception cref="ArgumentNullException">Source is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Count is out of range.</exception>
		[NotNull]
		public static T[] ToArray<T>([NotNull] this IEnumerable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (count < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}

			var array = new T[count];
			var i = 0;
			foreach (var item in source)
			{
				array[i++] = item;
			}

			return array;
		}
	}
}