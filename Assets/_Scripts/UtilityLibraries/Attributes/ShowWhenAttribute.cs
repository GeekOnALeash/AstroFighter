// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Attributes
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using JetBrains.Annotations;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Attribute used to show or hide the Field depending on certain conditions.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field)]
	[SuppressMessage("ReSharper", "SA1401", Justification = "Used for custom inspector.")]
	[SuppressMessage("ReSharper", "SA1600", Justification = "Third party class.")]
	public sealed class ShowWhenAttribute : PropertyAttribute
	{
		public readonly object comparationValue;
		public readonly object[] comparationValueArray;
		public readonly string conditionFieldName;

		/// <summary>
		/// Initializes a new instance of the <see cref="ShowWhenAttribute"/> class.
		///  Attribute used to show or hide the Field depending on certain conditions.
		/// </summary>
		/// <param name="conditionFieldName">Name of the bool condition Field.</param>
		public ShowWhenAttribute(string conditionFieldName) => this.conditionFieldName = conditionFieldName;

		/// <summary>
		/// Initializes a new instance of the <see cref="ShowWhenAttribute"/> class.
		///  Attribute used to show or hide the Field depending on certain conditions.
		/// </summary>
		/// <param name="conditionFieldName">Name of the Field to compare (bool, enum, int or float).</param>
		/// <param name="comparationValue">Value to compare.</param>
		public ShowWhenAttribute(string conditionFieldName, object comparationValue = null)
		{
			this.conditionFieldName = conditionFieldName;
			this.comparationValue = comparationValue;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ShowWhenAttribute"/> class.
		/// Attribute used to show or hide the Field depending on certain conditions.
		/// </summary>
		/// <param name="conditionFieldName">Name of the Field to compare (bool, enum, int or float).</param>
		/// <param name="comparationValueArray">Array of values to compare (only for enums).</param>
		[UsedImplicitly]
		public ShowWhenAttribute(string conditionFieldName, object[] comparationValueArray = null)
		{
			this.conditionFieldName = conditionFieldName;
			this.comparationValueArray = comparationValueArray;
		}
	}
}