using System.Runtime.CompilerServices;
using UnityEngine;

namespace Spaware {

	public static class ColorExtensions {

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		/// <summary>
		/// Set the transparency of the current Color
		/// </summary>
		/// <param name="color"></param>
		/// <param name="alpha"></param>
		/// <returns></returns>
		public static Color Alpha(this Color color, float alpha) {
			color.a = alpha;

			return color;
		}
	}
}
