using System;
using UnityEngine;

namespace Andtech.ResourceManagement {

	/// <summary>
	/// Base class for a resource.
	/// Use resources for performing commonly used functions.
	/// The resource should communicate by staging its result.
	/// </summary>
	public abstract class Resource<T> : MonoBehaviour where T : Stage {
		public T Stage {
			get;
			protected set;
		}

		/// <summary>
		/// Allows stage events to be relayed by this resource.
		/// </summary>
		/// <param name="stage">The stage to use during registration.</param>
		protected void RegisterStageEvents(Stage stage) {
			stage.Opened += UploadedStage;
			stage.Uploaded += UpdatedStage;
			stage.Closed += UnloadedStage;
		}

		/// <summary>
		/// Stops stage events from being relayed by this resource.
		/// </summary>
		/// <param name="stage">The stage to use duration unregistration.</param>
		protected void UnregisterStageEvents(Stage stage) {
			stage.Opened -= UploadedStage;
			stage.Uploaded -= UpdatedStage;
			stage.Closed -= UnloadedStage;
		}

		#region VIRTUAL
		/// <summary>
		/// Starts the processing of the resource.
		/// </summary>
		public virtual void Open() {
			RegisterStageEvents(Stage);
		}

		/// <summary>
		/// Stops the pocessing of the resource.
		/// </summary>
		public virtual void Close() {
			UnregisterStageEvents(Stage);
		}
		#endregion VIRTUAL

		#region EVENT
		public event EventHandler UploadedStage;
		public event EventHandler UpdatedStage;
		public event EventHandler UnloadedStage;

		protected virtual void OnStage(EventArgs e) {
			UploadedStage?.Invoke(this, e);
		}

		protected virtual void OnUpdateStage(EventArgs e) {
			UpdatedStage?.Invoke(this, e);
		}

		protected virtual void OnUnstage(EventArgs e) {
			UnloadedStage?.Invoke(this, e);
		}
		#endregion EVENT
	}
}
