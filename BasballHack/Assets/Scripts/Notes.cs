using System;
using UnityEngine;

namespace Unsorted {

	/// <summary>
	/// Use this to add descriptions to your GameObject.
	/// </summary>
	[Serializable]
	public class Notes : MonoBehaviour {
		[Tooltip("Put in any text you want people to see!")]
		public string text;
	}
}
