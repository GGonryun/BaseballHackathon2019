﻿using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Useful vector functions.
	/// </summary>
	public static class VectorUtility {

		/// <summary>
		/// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.right"/>.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <returns>The projected copy of <paramref name="vector"/>.</returns>
		public static Vector3 ProjectOnPlaneX(Vector3 vector) {
			return new Vector3(0.0f, vector.y, vector.z);
		}

		/// <summary>
		/// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.up"/>.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <returns>The projected copy of <paramref name="vector"/>.</returns>
		public static Vector3 ProjectOnPlaneY(Vector3 vector) {
			return new Vector3(vector.x, 0.0f, vector.z);
		}

		/// <summary>
		/// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.forward"/>.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <returns>The projected copy of <paramref name="vector"/>.</returns>
		public static Vector3 ProjectOnPlaneZ(Vector3 vector) {
			return new Vector3(vector.x, vector.y, 0.0f);
		}

		/// <summary>
		/// Optimized version of an orthogonal projection onto a line spanned by <paramref name="onNormal"/>.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <param name="onNormal">The vector which defines the line (normalized).</param>
		/// <returns>The projected copy of <paramref name="vector"/>.</returns>
		public static Vector3 ProjectOptimized(Vector3 vector, Vector3 onNormal) {
			return Vector3.Dot(vector, onNormal) * onNormal;
		}

		/// <summary>
		/// Optimized version of orthogonal projection onto a plane defined by <paramref name="planeNormal"/>.
		/// </summary>
		/// <param name="vector">The vector to project.</param>
		/// <param name="planeNormal">The vector which defines the line (normalized).</param>
		/// <returns>The projected copy of <paramref name="vector"/>.</returns>
		public static Vector3 ProjectOnPlaneOptimized(Vector3 vector, Vector3 planeNormal) {
			return vector - ProjectOptimized(vector, planeNormal);
		}

		/// <summary>
		/// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.right"/>.
		/// </summary>
		/// <param name="vector">The vector to use in the cross product.</param>
		/// <returns>The cross product of <paramref name="vector"/>.</returns>
		public static Vector3 CrossRight(Vector3 vector) {
			return new Vector3(0.0f, vector.z, -vector.y);
		}

		/// <summary>
		/// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.up"/>.
		/// </summary>
		/// <param name="vector">The vector to use in the cross product.</param>
		/// <returns>The cross product of <paramref name="vector"/>.</returns>
		public static Vector3 CrossUp(Vector3 vector) {
			return new Vector3(-vector.z, 0.0f, vector.x);
		}

		/// <summary>
		/// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.forward"/>.
		/// </summary>
		/// <param name="vector">The vector to use in the cross product.</param>
		/// <returns>The cross product of <paramref name="vector"/>.</returns>
		public static Vector3 CrossForward(Vector3 vector) {
			return new Vector3(vector.y, -vector.x, 0.0f);
		}

		/// <summary>
		/// Computes the intersection of (1) the ray defined by <paramref name="point"/> and <paramref name="direction"/> and the XZ plane.
		/// </summary>
		/// <param name="point">The position of the ray.</param>
		/// <param name="direction">The direction of the ray.</param>
		/// <returns>The position of the intersection.</returns>
		public static Vector3 GetPlaneIntersection(Vector3 point, Vector3 direction) {
			float t = -point.y / direction.y;
			return point + t * direction;
		}

		/// <summary>
		/// Computes the intersection of (1) the ray defined by <paramref name="point"/> and <paramref name="direction"/> and (2) the plane defined by <paramref name="planeOrigin"/> and <paramref name="planeNormal"/>.
		/// </summary>
		/// <param name="point">The position of the ray.</param>
		/// <param name="direction">The direction of the ray.</param>
		/// <param name="planeOrigin">Any position on the plane.</param>
		/// <param name="planeNormal">The normal of the plane.</param>
		/// <returns>The position of the intersection.</returns>
		public static Vector3 GetPlaneIntersection(Vector3 point, Vector3 direction, Vector3 planeOrigin, Vector3 planeNormal) {
			float t = (Vector3.Dot(planeNormal, planeOrigin) - Vector3.Dot(planeNormal, point)) / Vector3.Dot(planeNormal, direction);
			return point + t * direction;
		}
	}
}
