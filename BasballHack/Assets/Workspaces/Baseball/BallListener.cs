using UnityEngine;

namespace Unsorted {

	public class BallListener : MonoBehaviour {

		protected virtual void OnCollisionEnter() {
			Baseball baseball = GetComponentInParent<Baseball>();
			if (baseball.Frozen) {
				baseball.Unfreeze();

				StartCoroutine(WebRequestAttempt.PostRequest(baseball.id.ToString()));

				SoundPlayer.PlayHit();
				Debug.Log(baseball.id);
			}
		}
	}
}
