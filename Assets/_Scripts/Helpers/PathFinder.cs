// Copyright (c) Stellar Pixels. All rights reserved.

namespace Com.StellarPixels.AstroFighter.Helpers
{
	using Com.StellarPixels.UtilityLibraries;
	using Com.StellarPixels.UtilityLibraries.Attributes;
	using UnityEngine;

	/// <summary>
	/// Class for path finding between way points.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public sealed class PathFinder : CachedTransformBase
	{
		[SerializeField]
		private bool useWaypoints;

		[ShowWhen(nameof(useWaypoints), false)]
		[SerializeField]
		private bool isStationery;

		[ShowWhen(nameof(useWaypoints), true)]
		[SerializeField]
		private WayPoint[] wayPoints;

		private int _nextWayPoint;
		private bool _isVisble;
		private bool _pathComplete;
		private WayPoint _wayPoint;

		private void FixedUpdate()
		{
			if (!isStationery && _isVisble && !_pathComplete)
			{
				StartMovement();
			}
		}

		private void StartMovement()
		{
			_wayPoint = GetNextWayPoint();

			if (_wayPoint is null)
			{
				return;
			}

			var step = Time.deltaTime * _wayPoint.Speed;
			transform.position = Vector2.Lerp(transform.position, _wayPoint.GetPosition(), step);

			if (Vector2.Distance(transform.position, _wayPoint.GetPosition()) < 0.01f)
			{
				_nextWayPoint += 1;
			}
		}

		private WayPoint GetNextWayPoint()
		{
			if (_nextWayPoint < wayPoints.Length)
			{
				var waypoint = wayPoints[_nextWayPoint];
				return waypoint;
			}

			_pathComplete = true;

			return null;
		}

		private void OnBecameVisible()
		{
			_isVisble = true;
		}

		private void OnBecameInvisible()
		{
			_isVisble = false;
		}
	}
}