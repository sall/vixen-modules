﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Module.EffectEditor;

namespace VixenModules.EffectEditor.LevelTypeEditor
{
	public class LevelTypeEditor : EffectEditorModuleInstanceBase
	{
		override public IEffectEditorControl CreateEditorControl()
		{
			return new LevelTypeEditorControl();
		}
	}
}
