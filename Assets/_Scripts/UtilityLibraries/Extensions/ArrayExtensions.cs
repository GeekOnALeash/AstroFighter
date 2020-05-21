// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Extensions
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using Random = UnityEngine.Random;

	/// <summary>
	/// Extensions for Array collection.
	/// </summary>
	internal static class ArrayExtensions
	{
		/// <summary>
		/// Returns a random element from an array of any type.
		/// </summary>
		/// <param name="array">Array collection.</param>
		/// <typeparam name="T">Type of the array.</typeparam>
		/// <returns>Element from the array picked at random.</returns>
		internal static T RandomItem<T>([CanBeNull] this T[] array)
		{
			if (array == null || array.Length <= 0)
			{
				return default;
			}

			return array.Length == 1 ? array[0] : array[Random.Range(0, array.Length)];
		}

		/// <summary>
		/// Returns a random element from an array of any type within set range.
		/// </summary>
		/// <param name="array">Array collection.</param>
		/// <typeparam name="T">Type of the array.</typeparam>
		/// <param name="max">Maximum range value [exclusive].</param>
		/// <returns>Element from the array picked at random within a range.</returns>
		internal static T RandomItemWithMax<T>([CanBeNull] this T[] array, int max)
		{
			if (array == null || array.Length <= 0 || max > array.Length)
			{
				return default;
			}

			return array.Length == 1 ? array[0] : array[Random.Range(0, max)];
		}

		/// <summary>
		/// Converts an array to a list.
		/// </summary>
		/// <param name="source">Array collection.</param>
		/// <param name="count">Size.</param>
		/// <typeparam name="T">Type of the array.</typeparam>
		/// <returns>List from array.</returns>
		/// <exception cref="ArgumentNullException">Source is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">Count is out of range.</exception>
		[NotNull]
		internal static List<T> ToList<T>([NotNull] this IEnumerable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source));
			}

			if (count < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}

			var list = new List<T>(count);
			foreach (var item in source)
			{
				list.Add(item);
			}

			return list;
		}
	}
}