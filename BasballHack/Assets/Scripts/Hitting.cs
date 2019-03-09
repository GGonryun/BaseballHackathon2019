using UnityEngine;

namespace Unsorted {

	public class Hitting : MonoBehaviour {
		public new Rigidbody rigidbody;

		void OnCollisionEnter(Collision collision) {
			ContactPoint contact = collision.GetContact(0);
			Vector3 point = contact.point;
			Vector3 velocity = rigidbody.GetPointVelocity(point);

			Debug.DrawRay(point, contact.normal, Color.blue, 1.0F);
			Debug.DrawLine(Vector3.zero, point, Color.green, 1.0F);
			Debug.DrawRay(point, velocity, Color.yellow, 1.0F);

			Debug.Log("ENTER");
		}

		void OnCollisionStay(Collision collision) {
			ContactPoint contact = collision.GetContact(0);
			Vector3 point = contact.point;
			Vector3 velocity = rigidbody.GetPointVelocity(point);

			Debug.DrawRay(point, contact.normal, Color.blue, 1.0F);
			Debug.DrawLine(Vector3.zero, point, Color.green, 1.0F);
			Debug.DrawRay(point, velocity, Color.yellow, 1.0F);

			Debug.Log("STAYING");
		}
	}
}
