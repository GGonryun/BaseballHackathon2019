using UnityEngine;

namespace Andtech {

	/// <summary>
	/// A 3D subspace.
	/// </summary>
	public class Basis : MonoBehaviour {
		public Vector3 Origin {
			get {
				return globalization.GetColumn(3);
			}
		}
		public Quaternion Rotation {
			get {
				return globalization.rotation;
			}
		}
		public Vector3 Scale {
			get {
				return globalization.lossyScale;
			}
		}
		public Vector3 this[int index] {
			get {
				switch (index) {
					case 0:
						return globalization.MultiplyVector(Vector3.right);
					case 1:
						return globalization.MultiplyVector(Vector3.up);
					case 2:
						return globalization.MultiplyVector(Vector3.forward);
					default:
						throw new System.IndexOutOfRangeException();
				}
			}
		}

		private Matrix4x4 localization;
		private Matrix4x4 globalization;

		public void Setup() {
			Vector3 basis0 = transform.right;
			Vector3 basis1 = transform.up;
			Vector3 basis2 = transform.forward;

			basis0 *= transform.localScale.x;
			basis1 *= transform.localScale.y;
			basis2 *= transform.localScale.z;

			Setup(basis0, basis1, basis2, transform.position);
		}

		public void Setup(Vector3 basis0, Vector3 basis1, Vector3 basis2, Vector3 origin) {
			localization = MatrixUtility.GetLocalizationMatrix(basis0, basis1, basis2, origin);
			globalization = localization.inverse;
		}

		/// <summary>
		/// Converts to the basis' coordinate system.
		/// </summary>
		/// <param name="vector">The position to convert.</param>
		/// <returns>The equivalent position in basis localspace coordinates.</returns>
		public Vector3 Localize(Vector3 vector) {
			return localization.MultiplyPoint3x4(vector);
		}

		/// <summary>
		/// Converts from the basis' coordinate system.
		/// </summary>
		/// <param name="vector">The position to convert.</param>
		/// <returns>The equaivalent position in worldspace coordinates</returns>
		public Vector3 Globalize(Vector3 vector) {
			return globalization.MultiplyPoint3x4(vector);
		}
	}
}
