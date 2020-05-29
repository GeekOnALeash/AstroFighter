namespace Com.StellarPixels.AstroFighter.Behaviours
{
	using System;
	using Com.StellarPixels.UtilityLibraries;
	using Com.StellarPixels.UtilityLibraries.Attributes;
	using Unity.Mathematics;
	using UnityEngine;
	using UnityEngine.Rendering;

	/// <inheritdoc />
	/// <summary>
	/// Adjusts sprite renderer sorting order based on position.
	/// </summary>
	[ExecuteInEditMode]
	public sealed class IsometricSpriteRenderer : CachedTransformBase
	{
		private const int IsometricRangePerYUnit = -10;

		[SerializeField]
		private bool usesSortingGroup = true;

		[ShowWhen(nameof(usesSortingGroup), false)]
		[SerializeField]
		private SpriteRenderer spriteRenderer;

		[ShowWhen(nameof(usesSortingGroup), true)]
		[SerializeField]
		private SortingGroup sortingGroup;

		[Tooltip("Will use this object to compute z-order")]
		[SerializeField]
		private Transform target;

		[Tooltip("Use this to offset the object slightly in front or behind the Target object")]
		[SerializeField]
		private int targetOffset;

		private float3 _position;
		private float3 _oldPosition;
		private float _sizeY;

		private void Start()
		{
			DoSetup();
		}

		private void LateUpdate()
		{
			_position = target.position;

			if (Math.Abs(_oldPosition.y - target.position.y) > 0.01f)
			{
				int sortingOrder = (int)((_position.y - (_sizeY / 2)) * IsometricRangePerYUnit) + targetOffset;

				if (usesSortingGroup)
				{
					sortingGroup.sortingOrder = sortingOrder;
				} else
				{
					spriteRenderer.sortingOrder = sortingOrder;
				}

				_oldPosition = _position;
			}
		}

		private void DoSetup()
		{
			// ReSharper disable once ConvertIfStatementToNullCoalescingAssignment
			if (target is null)
			{
				target = transform;
			}

			if (usesSortingGroup)
			{
				if (sortingGroup is null)
				{
					Debug.Log("Sorting group is null");
					return;
				}
			} else
			{
				if (spriteRenderer is null)
				{
					Debug.Log("Sprite Renderer is null");
					return;
				}
			}

			_sizeY = spriteRenderer.bounds.size.y;
		}
	}
}