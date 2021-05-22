// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable once CheckNamespace
// ReSharper disable once MissingBlankLines
namespace Com.StellarPixels.UtilityLibraries.Attributes
{
	using System.Diagnostics.CodeAnalysis;
	using UnityEngine;

	/// <inheritdoc />
	/// <summary>
	/// Attribute to display a help box.
	/// </summary>
	[SuppressMessage("ReSharper", "SA1401", Justification = "Needed for unity editor visibility.")]
	[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global", Justification = "Needed for unity editor visibility.")]
	public sealed class HelpBoxAttribute : PropertyAttribute
	{
		/// <summary>
		/// Type of message.
		/// </summary>
		public HelpBoxMessageType messageType;

		/// <summary>
		/// Message text.
		/// </summary>
		public string text;

		/// <summary>
		/// Initializes a new instance of the <see cref="HelpBoxAttribute"/> class.
		/// </summary>
		/// <param name="text">Text to display in help box.</param>
		/// <param name="messageType">Type of help box to display.</param>
		public HelpBoxAttribute(string text, HelpBoxMessageType messageType = HelpBoxMessageType.None)
		{
			this.text = text;
			this.messageType = messageType;
		}
	}
}