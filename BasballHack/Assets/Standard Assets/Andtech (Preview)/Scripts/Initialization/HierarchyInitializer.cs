using System.Collections.Generic;

namespace Andtech {

	public class HierarchyInitializer : Initializer {

		#region OVERRIDE
		public override void Initialize() {
			if (!RequiresInitialization)
				return;

			List<IInitializable> list = new List<IInitializable>();
			gameObject.GetComponentsInChildren(list);
			foreach (IInitializable initializable in list) {
				if (ReferenceEquals(initializable, this))
					continue;

				if (initializable is HierarchyInitializer)
					throw new System.NotSupportedException("You cannot nest HierarchyInitialzers");

				initializable.Initialize();
			}

			Destruct();
		}
		#endregion OVERRIDE
	}
}
