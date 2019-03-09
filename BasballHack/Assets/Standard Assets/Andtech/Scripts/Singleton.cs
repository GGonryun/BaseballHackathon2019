using System;

namespace Andtech {

	/// <summary>
	/// Base class for defining singletons.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance.</typeparam>
	public abstract class Singleton<T> {
		public static T Current {
			get {
				if (!HasSingleton)
					throw new NullReferenceException(messageNull);

				return current;
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

		private static T current;

		internal static readonly string messageNull = "Singleton reference not set to an instance of an object.";
		internal static readonly string messageExists = "Singleton reference already set to an instance of an object.";
	}
}
