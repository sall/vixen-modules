﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Common.ScriptSequence.Script;

namespace VixenModules.Editor.ScriptEditor {
	public partial class SourceFileTabPage : UserControl {
		private SourceFile _sourceFile;

		public event EventHandler SelectionChanged;

		public SourceFileTabPage(SourceFile sourceFile) {
			InitializeComponent();
			SourceFile = sourceFile;
		}

		public SourceFile SourceFile {
			get {
				Commit();
				return _sourceFile; 
			}
			set {
				_sourceFile = value;
				scintilla.Text = value.Contents;
			}
		}

		public void Commit() {
			_sourceFile.Contents = scintilla.Text;
			scintilla.Modified = false;
		}

		public bool IsModified {
			get { return scintilla.Modified; }
		}

		public Point CaretLocation { get; private set; }

		protected virtual void OnSelectionChanged(EventArgs e) {
			if(SelectionChanged != null) {
				SelectionChanged(this, e);
			}
		}

		private Point _GetCaretLocation() {
			int x = scintilla.GetColumn(scintilla.Caret.Position);
			int y = scintilla.Lines.Current.Number;
			return new Point(x, y);
		}

		private void scintilla_SelectionChanged(object sender, EventArgs e) {
			CaretLocation = _GetCaretLocation();
			OnSelectionChanged(e);
		}
	}
}
