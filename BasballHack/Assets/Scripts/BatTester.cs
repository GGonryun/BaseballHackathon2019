using System;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

namespace Unsorted {

	[Serializable]
	public struct BatHitInfo {
		public Vector3 velocity;
		public RaycastHit raycastHit;
	}

	[Serializable]
	public class HitUnityEvent : UnityEvent<BatHitInfo> {	}

	public class BatTester : MonoBehaviour {
		public LayerMask collisionMask;
		public Transform root;
		public Transform tip;
		public float radius;
		public float width;

		public float timer;
		public float delay;

		public Transform target;
		public HitUnityEvent hitUnityEvent;

		public bool TimeLocked {
			get {
				return timer > 0.0F;
			}
		}

		public SteamVR_Behaviour_Pose pose;

		void LateUpdate() {
			Quaternion rotation = root.rotation;
			Vector3 pointA = root.position;
			Vector3 pointB = tip.position;
			Vector3 direction = width * root.forward;

			Debug.DrawLine(Vector3.zero, pointA, Color.red);
			Debug.DrawLine(Vector3.zero, pointB, Color.green);
		}

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			Quaternion rotation = root.rotation;
			Vector3 pointA = root.position;
			Vector3 pointB = tip.position;
			Vector3 direction = width * root.forward;

			RaycastHit hitInfo;
			if (!TimeLocked && Physics.CapsuleCast(pointA, pointB, radius, direction, out hitInfo, collisionMask.value)) {
				Vector3 point = hitInfo.point;
				Vector3 velocity = pose.GetVelocity();

				// Debugging
				Debug.DrawRay(point, velocity, Color.red, delay);
				Debug.LogFormat("HIT {0}", hitInfo.collider.name);
				target.position = point;

				// Invoke events
				BatHitInfo batHitInfo = new BatHitInfo {
					raycastHit = hitInfo,
					velocity = velocity
				};
				hitUnityEvent.Invoke(batHitInfo);

				// Reset timer
				timer = delay;
			}

			Debug.DrawRay(pointA, direction, Color.red);
			Debug.DrawRay(pointB, direction, Color.green);

			// Iteration management
			timer -= Time.deltaTime;
		}

		protected virtual void OnDrawGizmos() {
			Gizmos.DrawLine(root.position, tip.position);
			Gizmos.DrawWireSphere(root.position, radius);
			Gizmos.DrawWireSphere(tip.position, radius);
		}
        #endregion MONOBEHAVIOUR
	}
}
