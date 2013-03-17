﻿using System.Runtime.Serialization;
using Vixen.Module;

namespace Recording {
	[DataContract]
	public class RecordingData : ModuleDataModelBase {
		[DataMember]
		public bool Enabled { get; set; }

		override public IModuleDataModel Clone() {
			IModuleDataModel newInstance = MemberwiseClone() as IModuleDataModel;
			return newInstance;
		}
	}
}
