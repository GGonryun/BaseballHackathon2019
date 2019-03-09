using System;

namespace Andtech.ResourceManagement {

	/// <summary>
	/// Base class for exposed storage space. Listeners must read the stage to receive the result.
	/// </summary>
	public class Stage {
		/// <summary>
		/// Is the stage ready to use?
		/// </summary>
		public bool Ready {
			get {
				return ready;
			}
			set {
				if (ready == value)
					return;

				ready = value;
				if (ready)
					OnOpen(EventArgs.Empty);
				else
					OnClose(EventArgs.Empty);
			}
		}

		private bool ready;

		/// <summary>
		/// Uploads any changes made to the stage.
		/// </summary>
		public void Upload() {
			OnUpload(EventArgs.Empty);
		}

		/// <summary>
		/// Uploads the changes made to the stage (does not alter the state of the stage).
		/// </summary>
		public void UploadOneShot() {
			OnUpload(EventArgs.Empty);
		}

		#region EVENT
		/// <summary>
		/// Triggered once the stage becomes usable.
		/// </summary>
		public event EventHandler Opened;
		/// <summary>
		/// Triggered whenever the stage is updated.
		/// </summary>
		public event EventHandler Uploaded;
		/// <summary>
		/// Triggered once the state becomes unusable.
		/// </summary>
		public event EventHandler Closed;

		protected virtual void OnOpen(EventArgs e) {
			Opened?.Invoke(this, e);
		}

		protected virtual void OnUpload(EventArgs e) {
			Uploaded?.Invoke(this, e);
		}

		protected virtual void OnClose(EventArgs e) {
			Closed?.Invoke(this, e);
		}
		#endregion EVENT
	}
}
