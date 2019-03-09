
namespace Andtech.Extensions {

	public static class IntExtensions {

		/// <summary>
		/// Wraps the value between <paramref name="min"/> (inclusive) and <paramref name="max"/> (inclusive).
		/// </summary>
		/// <param name="x">The value to wrap.</param>
		/// <param name="min">The minimum value for the result.</param>
		/// <param name="max">The maximum value for the result.</param>
		/// <returns>The wrapped value.</returns>
		public static int Wrap(this int x, int min, int max) {
			int rangePlusOne = (max - min) + 1;

			if (x < min) {
				int distance = max - x;
				return max - (distance % rangePlusOne);
			}
			else {
				int distance = x - min;
				return (distance % rangePlusOne) + (min);
			}
		}

		/// <summary>
		/// Wraps the value between <paramref name="min"/> (inclusive) and <paramref name="max"/> (inclusive).
		/// </summary>
		/// <param name="x">The value to wrap.</param>
		/// <param name="min">The minimum value for the result.</param>
		/// <param name="max">The maximum value for the result.</param>
		/// <param name="wrapCounts">The required number of times the value would need to wrap.</param>
		/// <returns>The wrapped value.</returns>
		public static int Wrap(this int x, int min, int max, out int wrapCounts) {
			int rangePlusOne = (max - min) + 1;

			if (x < min) {
				int distance = max - x;
				wrapCounts = distance / rangePlusOne;
				return max - (distance % rangePlusOne);
			}
			else {
				int distance = x - min;
				wrapCounts = distance / rangePlusOne;
				return (distance % rangePlusOne) + (min);
			}
		}
	}
}
