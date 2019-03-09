using UnityEngine;

namespace Unsorted {

	public class SoundPlayer : MonoBehaviour {
		public AudioSource audioSource;

		public static SoundPlayer current;

		void Awake() {
			current = this;
		}

		public static void PlayHit() {
			current.audioSource.Play();
		}
	}
}
