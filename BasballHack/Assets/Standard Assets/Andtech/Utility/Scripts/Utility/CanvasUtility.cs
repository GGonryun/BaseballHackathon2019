using UnityEngine;

namespace Andtech {

	public static class CanvasUtility {
		
		public static Vector2 GetScreenPosition(this Canvas canvas, Vector2 position) {
			RectTransform canvasTransform = (RectTransform)canvas.transform;
			Vector2 center = canvasTransform.sizeDelta * canvasTransform.pivot;

			return (Vector2)canvasTransform.InverseTransformPoint(position) + center;
		}

		public static Vector2 GetWorldPosition(this Canvas canvas, Vector2 position) {
			RectTransform canvasTransform = (RectTransform)canvas.transform;
			Vector3 localPosition = canvasTransform.TransformPoint(position);

			return localPosition;
		}
	}
}
