using System;
using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Base class for defining singleton MonoBehaviours.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance.</typeparam>
	public abstract class SingletonBehaviour<T> : MonoBehaviour, IInitializable where T : MonoBehaviour {
		public static T Current {
			get {
				if (!HasSingleton)
					throw new NullReferenceException(messageNull);

				return (T)current;
			}
			set {
				if (!ReferenceEquals(value, null) && HasSingleton)
					throw new Exception(messageExists);

				current = value;
			}
		}		
		public static bool HasSingleton {
			get {
				return !ReferenceEquals(current, null);
			}
		}

		private static MonoBehaviour current;

		internal static readonly string messageNull = "Singleton reference not set to an instance of an object.";
		internal static readonly string messageExists = "Singleton reference already set to an instance of an object.";

		#region INTERFACE
		public virtual void Initialize() {
			current = this;
		}
		#endregion INTERFACE
	}
}
