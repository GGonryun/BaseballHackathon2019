using UnityEngine;
using UnityEngine.Events;

namespace Andtech {

	public class UnityInitializer : Initializer {
		/// <summary>
		/// List of initialization methods.
		/// </summary>
		[Tooltip("List of initialization methods.")]
		public UnityEvent onInitialize;

		#region OVERRIDE
		public override void Initialize() {
			if (!RequiresInitialization)
				return;
			
			onInitialize.Invoke();
			Destruct();
		}
		#endregion OVERRIDE
	}
}
