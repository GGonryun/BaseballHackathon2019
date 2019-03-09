using System;
using System.Collections;
using System.Collections.Generic;

namespace Andtech.Extensions {

	/// <summary>
	/// Useful extension methods for lists.
	/// </summary>
	public static class IListExtensions {

		/// <summary>
		/// Returns all elements from the index <paramref name="first"/> (inclusive) to the last index (inclusive).
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="list">The list to slice.</param>
		/// <param name="first">The index of the first element in the sliced portion.</param>
		/// <returns>The sliced portion.</returns>
		public static IList Slice<T>(this IList<T> list, int first) {
			return Slice(list, first, list.Count - 1);
		}

		/// <summary>
		/// Returns all elements from the index <paramref name="first"/> (inclusive) to the index <paramref name="last"/> (inclusive).
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="list">The list to slice.</param>
		/// <param name="first">The index of the first element in the sliced portion.</param>
		/// <param name="last">The index of the last element in the sliced portion.</param>
		/// <returns>The sliced portion.</returns>
		public static IList Slice<T>(this IList<T> list, int first, int last) {
			if (first < 0)
				first = 0;
			if (last > list.Count - 1)
				last = list.Count - 1;
			if (last < first)
				return new T[0];

			int n = last - first + 1;
			IList sliced = new T[n];
			for (int i = 0; i < n; i++) {
				sliced[i] = list[first + i];
			}
			return sliced;
		}

		public static IList GetRange<T>(this IList<T> list, int count) {
			return GetRange(list, 0, count);
		}

		/// <summary>
		/// Returns <paramref name="count"/> elements starting from the index <paramref name="first"/>.
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="list">The list to slice.</param>
		/// <param name="first">The index of the first element in the sliced portion.</param>
		/// <param name="count">The count of elements to get.</param>
		/// <returns>The sliced portion.</returns>
		public static IList GetRange<T>(this IList<T> list, int first, int count) {
			int last = first + count - 1;
			if (first < 0)
				first = 0;
			if (last > list.Count - 1)
				last = list.Count - 1;
			IList sliced = new T[count];
			for (int i = 0; i < count; i++) {
				sliced[i] = list[first + i];
			}
			return sliced;
		}

		/// <summary>
		/// Returns the index of the <paramref name="key"/>.
		/// If the element isn't found, the algorithm will return the index of the nearest preceeding element.
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="list">The list to search through.</param>
		/// <param name="key">The item to search for.</param>
		/// <returns>The index of the nearest element.</returns>
		public static int BinarySearchNearest<T>(this IList<T> list, T key) where T : IComparable<T> {
			// Calculate the heuristic
			int guess = (0 + (list.Count - 1)) >> 1;

			// Attempt a binary search on the entire list
			int index = BinarySearchNearest(list, key, 0, list.Count - 1, guess);

			// Clamp the index
			if (index < 0)
				return 0;

			if (index > list.Count - 1)
				return list.Count - 1;

			return index;
		}

		/// <summary>
		/// Returns the index of the <paramref name="key"/>.
		/// If the element isn't found, the algorithm will return the index of the nearest preceeding element.
		/// </summary>
		/// <typeparam name="T">The type of the data.</typeparam>
		/// <param name="list">The list to search through.</param>
		/// <param name="key">The item to search for.</param>
		/// <param name="guess">A heuristic for the algorithm.</param>
		/// <returns>The index of the nearest element.</returns>
		public static int BinarySearchNearest<T>(this IList<T> list, T key, int guess) where T : IComparable<T> {
			// Attempt a binary search on the entire list
			int index = BinarySearchNearest(list, key, 0, list.Count - 1, guess);

			// Clamp the index
			if (index < 0)
				return 0;

			if (index > list.Count - 1)
				return list.Count - 1;

			return index;
		}

		#region PIPELINE
		private static int BinarySearchNearest<T>(this IList<T> list, T key, int low, int high, int pivot) where T : IComparable<T> {
			if (high < low)
				return high;

			// Examine middle element
			int comparison = key.CompareTo(list[pivot]);

			if (comparison < 0)
				// Key is lower than the middle (in the current partition) element
				return BinarySearchNearest(list, key, low, pivot - 1, (low + high) >> 1);

			if (comparison > 0)
				// Key is larger than the middle (in the current partition) element
				return BinarySearchNearest(list, key, pivot + 1, high, (low + high) >> 1);

			return pivot;
		}
		#endregion PIPELINE
	}
}
