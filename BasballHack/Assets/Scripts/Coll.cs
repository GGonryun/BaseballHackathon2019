using UnityEngine;

namespace Unsorted {

	public class Coll : MonoBehaviour {

		public void OnCollisionStay(Collision collision) {
			ContactPoint contact = collision.GetContact(0);
			Vector3 point = contact.point;

			Debug.DrawRay(point, contact.normal * 100, Color.blue, 1.0F);
			Debug.DrawLine(Vector3.zero, point * 100, Color.green, 1.0F);

			Debug.Log("STAY");
		}
	}
}
