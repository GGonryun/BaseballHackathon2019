using UnityEngine;

namespace Unsorted {

	public class Crowd : MonoBehaviour {
		public AudioClip clipCheer;
		public AudioClip clipBoo;

		public AudioSource source;

		public void Cheer() {
			source.clip = clipCheer;
			source.Play();
		}

		public void Boo() {
			source.clip = clipBoo;
			source.Play();
		}

	}
}
