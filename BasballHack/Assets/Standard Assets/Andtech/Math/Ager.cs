﻿
namespace Andtech {

	public struct Ager {
		public float Value {
			get;
			private set;
		}
		public int Count {
			get;
			private set;
		}
		public readonly float weight;

		public Ager(float weight = 0.5f) {
			Count = 0;
			Value = 0;
			this.weight = weight;
		}

		public void Add(float value) {
			if (Count++ == 0)
				Value = value;
			else {
				if (weight == 0.5f)
					Value = 0.5f * (Value + value);
				else
					Value = Value + weight * (-Value + value);
			}
		}
	}
}
