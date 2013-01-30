using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Module.App;

namespace VixenModules.App.VixenScheduler
{
	public class VixenSchedulerDescriptor : AppModuleDescriptorBase {
        private Guid _typeId = new Guid("{D986203B-2AA0-4B5F-A7A8-D0023334C185}");

		public override string TypeName {
			get { return "Light Show Scheduler"; }
		}

		public override Guid TypeId {
			get { return _typeId; }
		}

		public override string Author {
			get { return "Vixen Team"; }
		}

		public override string Description {
			get { return "Schedules automated execution of sequences and programs"; }
		}

		public override string Version {
			get { return "0.1"; }
		}

		public override Type ModuleClass {
			get { return typeof(VixenSchedulerModule); }
		}

		public override Type ModuleStaticDataClass {
			get { return typeof(SchedulerData); }
		}
	}
}
