using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Base class for scripts which initialize target(s).
	/// </summary>
	[DefaultExecutionOrder(-999)]
	public abstract class Initializer : MonoBehaviour, IInitializable {
		/// <summary>
		/// How should the initializer be invoked?
		/// </summary>
		[Tooltip("How should the initializer be invoked?")]
		public Invocation initializationMode;
		/// <summary>
		/// How should the initializer perform destruction (after initialization)
		/// </summary>
		[Tooltip("How should the initializer perform destruction (after initialization)?")]
		public DestructionMode destructionMode;

		protected virtual bool RequiresInitialization {
			get {
				return enabled;
			}
		}

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			if (initializationMode == Invocation.OnAwake)
				Initialize();
		}

		protected virtual void Start() {
			if (initializationMode == Invocation.OnStart)
				Initialize();
		}
		#endregion MONOBEHAVIOUR

		#region VIRTUAL

		/// <summary>
		/// Destroys the appropriate target of this initializer.
		/// </summary>
		public virtual void Destruct() {
			// Perform destruction
			switch (destructionMode) {
				case DestructionMode.Component:
					Destroy(this);
					break;
				case DestructionMode.GameObject:
					Destroy(gameObject);
					break;
				default:
					enabled = false;
					break;
			}
		}
		#endregion VIRTUAL

		#region ABSTRACT
		/// <summary>
		/// Perform initialization.
		/// </summary>
		public abstract void Initialize();
		#endregion ABSTRACT
	}
}
