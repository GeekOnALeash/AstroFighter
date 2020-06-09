// Copyright (c) Stellar Pixels. All rights reserved.

// ReSharper disable All
namespace Com.StellarPixels.AstroFighter.Scriptable
{
	using global::System;
	using global::System.Collections.Generic;
	using global::System.Diagnostics.CodeAnalysis;
	using JetBrains.Annotations;
	using UnityEngine;

	[SuppressMessage("ReSharper", "SA1600", Justification = "Not my class.")]
	[SuppressMessage("ReSharper", "SA1401", Justification = "Not my class.")]
	[SuppressMessage("ReSharper", "SA1202", Justification = "Not my class.")]
	public abstract class GenericScriptableObject<T> : ScriptableObject, ISerializationCallbackReceiver
	{
		[SerializeField]
		protected T value;

		[NonSerialized]
		protected T runtimeValue;

		protected virtual T RuntimeValue
		{
			get => runtimeValue;
			set => runtimeValue = value;
		}

		public static bool operator ==(
			[CanBeNull] GenericScriptableObject<T> left,
			[CanBeNull] GenericScriptableObject<T> right) => Equals(left, right);

		public static bool operator !=(
			[CanBeNull] GenericScriptableObject<T> left,
			[CanBeNull] GenericScriptableObject<T> right) => !Equals(left, right);

		internal virtual bool SetValue(T amount)
		{
			if (AreEqual(RuntimeValue, amount))
			{
				return true;
			}

			RuntimeValue = amount;

			return true;
		}

		public virtual T GetValue() => RuntimeValue;

		public virtual void OnBeforeSerialize() { }

		public virtual void OnAfterDeserialize()
		{
			RuntimeValue = value;
		}

		protected abstract bool AreEqual(T first, T second);

		protected bool Equals(GenericScriptableObject<T> other) => EqualityComparer<T>.Default.Equals(value, other.value);

		public override bool Equals(object obj)
		{
			while (true)
			{
				if (ReferenceEquals(null, obj))
				{
					return false;
				}

				if (ReferenceEquals(this, obj))
				{
					return true;
				}

				if (obj.GetType() != GetType())
				{
					return false;
				}

				obj = (GenericScriptableObject<T>) obj;
			}
		}

		public override int GetHashCode() => EqualityComparer<T>.Default.GetHashCode(value);
	}
}
