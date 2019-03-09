using UnityEngine;

namespace Unsorted {

	public class Tee : MonoBehaviour {
		public Transform origin;
		public Baseball prefab;
		public Transform folder;

		public new ParticleSystem particleSystem;

		public int counter;

		public void Set() {
			Baseball baseball = Instantiate(prefab, folder);
			baseball.id = ++counter;
			baseball.Freeze();
			baseball.transform.position = origin.position;
			baseball.transform.rotation = origin.rotation;

			particleSystem.Clear();
			particleSystem.Play();
		}
	}
}
