using Andtech.Extensions;
using System;
using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Represents a discrete rotation around a single axis.
	/// </summary>
	/// <remarks>Uses LHR rotations.</remarks>
	[Serializable]
	public struct Rotation {
		/// <summary>
		/// The number of clockwise 90 degree turns.
		/// </summary>
		public int Turns {	
			get {
				return turns;
			}
			set {
				turns = value.Wrap(0, MAX - 1);
			}
		}
		/// <summary>
		/// The (clockwise) quadrant that the rotation lies in. (Read Only)
		/// </summary>
		/// <remarks>Quadrant values are on the interval [0, 4).</remarks>
		public int Quadrant {
			get {
				return 4 * turns / MAX;
			}
		}
		/// <summary>
		/// Direction vector around the X axis. The base direction is up.
		/// </summary>
		public Vector3Int DirectionX {
			get {
				bool even = (Turns % 2) == 0;
				Vector3Int forward = (even) ? new Vector3Int(0, 1, 0) : new Vector3Int(0, 1, 1);
				return forward.Rotate(0, Quadrant, 0);
			}
		}
		/// <summary>
		/// Direction vector around the Y axis. The base direction is forward.
		/// </summary>
		public Vector3Int DirectionY {
			get {
				bool even = (Turns % 2) == 0;
				Vector3Int forward = (even) ? new Vector3Int(0, 0, 1) : new Vector3Int(1, 0, 1);					
				return forward.Rotate(0, Quadrant, 0);
			}
		}
		/// <summary>
		/// Direction vector around the Z axis. The base direction is up.
		/// </summary>
		public Vector3Int DirectionZ {
			get {
				bool even = (Turns % 2) == 0;
				Vector3Int forward = (even) ? new Vector3Int(0, 1, 0) : new Vector3Int(1, 1, 0);
				return forward.Rotate(0, Quadrant, 0);
			}
		}
		/// <summary>
		/// Returns the actual angle (in degrees) represented by the rotation.
		/// </summary>
		public float EulerAngle {
			get {
				return TURNS2DEG * Turns;
			}
		}

		/// <summary>
		/// Number of clockwise 90 degree turns (internal).
		/// </summary>
		[SerializeField]
		private int turns;

		/// <summary>
		/// The maximum number of rotation fixtures.
		/// </summary>
		public const int MAX = 8;
		/// <summary>
		/// The number of turns per 1/2 revolution.
		/// </summary>
		public const int ONEHALFREV = MAX / 2;
		/// <summary>
		/// The number of turns per 1/4 revolution.
		/// </summary>
		public const int ONEFOURTHREV = MAX / 4;

		/// <summary>
		/// Turns-to-degrees conversion constant (Read Only).
		/// </summary>
		public const float TURNS2DEG = 360.0f / MAX;

		/// <summary>
		/// Turns-to-radians conversion constant (Read Only).
		/// </summary>
		public const float TURNS2RAD = 2.0f * Mathf.PI / MAX;

		/// <summary>
		/// Constructs a rotation with <paramref name="turns"/> clockwise 90 degree turns.
		/// </summary>
		/// <param name="turns"></param>
		public Rotation(int turns) {
			this.turns = turns.Wrap(0, MAX - 1);
		}

		#region OVERRIDE
		/// <summary>
		/// Determines whether the object is equal to this rotation.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>The object is equal to this rotation.</returns>
		public override bool Equals(object obj) {
			if (!base.Equals(obj))
				return false;

			return ((Rotation)obj).Turns == Turns;
		}

		public override int GetHashCode() {
			return Turns.GetHashCode();
		}

		public override string ToString() {
			return string.Format("{0} ({1} / {2})", EulerAngle, Turns, MAX);
		}
		#endregion OVERRIDE

		#region OPERATOR
		/// <summary>
		/// Adds the two rotations together.
		/// </summary>
		/// <param name="rotationA">The first rotation.</param>
		/// <param name="rotationB">The second rotation.</param>
		/// <returns>The resultant rotation.</returns>
		public static Rotation operator +(Rotation rotationA, Rotation rotationB) {
			return new Rotation(rotationA.turns + rotationB.turns);
		}

		/// <summary>
		/// Adds <paramref name="turns"/> to the rotation.
		/// </summary>
		/// <param name="rotation">The rotation to add to.</param>
		/// <param name="turns">The number of clockwise turns to add./</param>
		/// <returns>The resultant rotation.</returns>
		public static Rotation operator +(Rotation rotation, int turns) {
			return new Rotation(rotation.Turns + turns);
		}

		/// <summary>
		/// Adds <paramref name="turns"/> to the rotation.
		/// </summary>
		/// <param name="turns">The number of clockwise turns to add./</param>
		/// <param name="rotation">The rotation to add to.</param>
		/// <returns>The resultant rotation.</returns>
		public static Rotation operator +(int turns, Rotation rotation) {
			return rotation + turns;
		}

		/// <summary>
		/// Subtracts <paramref name="turns"/> from the rotation.
		/// </summary>
		/// <param name="rotation">The rotation to subtract from.</param>
		/// <param name="turns">The number of clockwise turns to subtract./</param>
		/// <returns>The resultant rotation.</returns>
		public static Rotation operator -(Rotation rotation, int turns) {
			return rotation + -turns;
		}

		/// <summary>
		/// Reverses the direction of the rotation.
		/// </summary>
		/// <param name="rotation">The rotation to reverse.</param>
		/// <returns>The reversed rotation.</returns>
		public static Rotation operator ~(Rotation rotation) {
			return rotation + (MAX >> 1);
		}

		/// <summary>
		/// Determines whether two rotation are equal.
		/// </summary>
		/// <param name="rotationA">The first rotation.</param>
		/// <param name="rotationB">The second rotation.</param>
		/// <returns>The two rotations are equal.</returns>
		public static bool operator ==(Rotation rotationA, Rotation rotationB) {
			return rotationA.Turns == rotationB.Turns;
		}

		/// <summary>
		/// Determines whether two rotation are different.
		/// </summary>
		/// <param name="rotationA">The first rotation.</param>
		/// <param name="rotationB">The second rotation.</param>
		/// <returns>The two rotations are different.</returns>
		public static bool operator !=(Rotation rotationA, Rotation rotationB) {
			return rotationA.Turns != rotationB.Turns;
		}

		/// <summary>
		/// Rotates the rotation by 1 clockwise 90 degree turn.
		/// </summary>
		/// <param name="rotation"></param>
		/// <returns></returns>
		public static Rotation operator ++(Rotation rotation) {
			return rotation + (MAX >> 2);
		}

		/// <summary>
		/// Rotates the rotation by 1 counter clockwise 90 degree turn.
		/// </summary>
		/// <param name="rotation"></param>
		/// <returns></returns>
		public static Rotation operator --(Rotation rotation) {
			return rotation - (MAX >> 2);
		}
		
		/// <summary>
		/// Unboxing operator for rotations to ints.
		/// </summary>
		/// <param name="rotation">The rotation to unbox.</param>
		public static implicit operator int(Rotation rotation) {
			return rotation.turns;
		}

		/// <summary>
		/// Autoboxing operator for ints to rotations.
		/// </summary>
		/// <param name="turns">The int to autobox.</param>
		public static implicit operator Rotation(int turns) {
			return new Rotation(turns);
		}
		#endregion OPERATOR
	}
}
