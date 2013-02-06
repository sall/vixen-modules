﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Commands;
using Vixen.Sys.Dispatch;

namespace VixenModules.Output.Hill320 {
	class CommandHandler : CommandDispatch {
		public byte Value { get; private set; }

		public void Reset() {
			Value = 0;
		}

		public override void Handle(_8BitCommand obj) {
			Value = obj.CommandValue;
		}
	}
}
