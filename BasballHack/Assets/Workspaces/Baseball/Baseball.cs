using UnityEngine;

namespace Unsorted {

	public class Baseball : MonoBehaviour {
		public int id;
		public new Rigidbody rigidbody;

		public bool Frozen {
			get {
				return !rigidbody.useGravity;
			}
		}

		public void Freeze() {
			rigidbody.useGravity = false;
		}

		public void Unfreeze() {
			rigidbody.useGravity = true;
		}
	}
}
