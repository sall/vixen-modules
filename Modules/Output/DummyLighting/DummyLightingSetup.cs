﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VixenModules.Output.DummyLighting
{
	public partial class DummyLightingSetup : Form
	{
		public DummyLightingSetup(RenderStyle renderStyle, string formTitle)
		{
			InitializeComponent();
			RenderStyle = renderStyle;
			FormTitle = formTitle;
		}

		RenderStyle _style;
		public RenderStyle RenderStyle
		{
			get { return _style; }
			set
			{
				_style = value;
				if (_style == RenderStyle.Monochrome)
					radioButtonMonochrome.Checked = true;
				else if (_style == RenderStyle.RGBMultiChannel)
					radioButtonMultiRGB.Checked = true;
				else if (_style == RenderStyle.RGBSingleChannel)
					radioButtonSingleRGB.Checked = true;
			}	
		}

		public string FormTitle
		{
			get { return textBoxWindowTitle.Text; }
			set { textBoxWindowTitle.Text = value; }
		}

		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonMonochrome.Checked)
				RenderStyle = RenderStyle.Monochrome;
			if (radioButtonMultiRGB.Checked)
				RenderStyle = RenderStyle.RGBMultiChannel;
			if (radioButtonSingleRGB.Checked)
				RenderStyle = RenderStyle.RGBSingleChannel;
		}
	}
}
