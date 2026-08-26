using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class FindAndReplaceForm : Form
{
	private TextEditorSearcher _search;

	private TextEditorControl _editor;

	public bool _lastSearchWasBackward;

	public bool _lastSearchLoopedAround;

	private Dictionary<TextEditorControl, HighlightGroup> _highlightGroups = new Dictionary<TextEditorControl, HighlightGroup>();

	private IContainer components;

	private Label label1;

	private Label lblReplaceWith;

	private TextBox txtLookFor;

	private TextBox txtReplaceWith;

	private Button btnFindNext;

	private Button btnReplace;

	private Button btnReplaceAll;

	private CheckBox chkMatchWholeWord;

	private CheckBox chkMatchCase;

	private Button btnHighlightAll;

	private Button btnCancel;

	private Button btnFindPrevious;

	private TextEditorControl Editor
	{
		get
		{
			return _editor;
		}
		set
		{
			_editor = value;
			_search.Document = _editor.Document;
			UpdateTitleBar();
		}
	}

	public bool ReplaceMode
	{
		get
		{
			return txtReplaceWith.Enabled;
		}
		set
		{
			Button button = btnReplace;
			bool visible = (btnReplaceAll.Enabled = value);
			button.Visible = visible;
			Label label = lblReplaceWith;
			visible = (txtReplaceWith.Enabled = value);
			label.Visible = visible;
			btnHighlightAll.Enabled = !value;
			base.AcceptButton = (value ? btnReplace : btnFindNext);
			UpdateTitleBar();
		}
	}

	public string LookFor => txtLookFor.Text;

	public FindAndReplaceForm()
	{
		InitializeComponent();
		_search = new TextEditorSearcher();
	}

	private void UpdateTitleBar()
	{
		string text = (ReplaceMode ? "Find & replace" : "Find");
		if (_editor != null && _editor.FileName != null)
		{
			text = text + " - " + Path.GetFileName(_editor.FileName);
		}
		if (_search.HasScanRegion)
		{
			text += " (selection only)";
		}
		Text = text;
	}

	public void ShowFor(TextEditorControl editor, bool replaceMode)
	{
		Editor = editor;
		_search.ClearScanRegion();
		SelectionManager selectionManager = editor.ActiveTextAreaControl.SelectionManager;
		if (selectionManager.HasSomethingSelected && selectionManager.SelectionCollection.Count == 1)
		{
			ISelection selection = selectionManager.SelectionCollection[0];
			if (selection.StartPosition.Line == selection.EndPosition.Line)
			{
				txtLookFor.Text = selectionManager.SelectedText;
			}
			else
			{
				_search.SetScanRegion(selection);
			}
		}
		else
		{
			Caret caret = editor.ActiveTextAreaControl.Caret;
			int num = TextUtilities.FindWordStart(editor.Document, caret.Offset);
			int num2 = TextUtilities.FindWordEnd(editor.Document, caret.Offset);
			txtLookFor.Text = editor.Document.GetText(num, num2 - num);
		}
		ReplaceMode = replaceMode;
		base.Owner = (Form)editor.TopLevelControl;
		Show();
		txtLookFor.SelectAll();
		txtLookFor.Focus();
	}

	private void btnFindPrevious_Click(object sender, EventArgs e)
	{
		FindNext(viaF3: false, searchBackward: true, "Text not found");
	}

	private void btnFindNext_Click(object sender, EventArgs e)
	{
		FindNext(viaF3: false, searchBackward: false, "Text not found");
	}

	public TextRange FindNext(bool viaF3, bool searchBackward, string messageIfNotFound)
	{
		if (string.IsNullOrEmpty(txtLookFor.Text))
		{
			MessageBox.Show("No string specified to look for!");
			return null;
		}
		_lastSearchWasBackward = searchBackward;
		_search.LookFor = txtLookFor.Text;
		_search.MatchCase = chkMatchCase.Checked;
		_search.MatchWholeWordOnly = chkMatchWholeWord.Checked;
		Caret caret = _editor.ActiveTextAreaControl.Caret;
		if (viaF3 && _search.HasScanRegion && !caret.Offset.IsInRange(_search.BeginOffset, _search.EndOffset))
		{
			_search.ClearScanRegion();
			UpdateTitleBar();
		}
		int beginAtOffset = caret.Offset - (searchBackward ? 1 : 0);
		TextRange textRange = _search.FindNext(beginAtOffset, searchBackward, out _lastSearchLoopedAround);
		if (textRange != null)
		{
			SelectResult(textRange);
		}
		else if (messageIfNotFound != null)
		{
			MessageBox.Show(messageIfNotFound);
		}
		return textRange;
	}

	private void SelectResult(TextRange range)
	{
		TextLocation startPosition = _editor.Document.OffsetToPosition(range.Offset);
		TextLocation endPosition = _editor.Document.OffsetToPosition(range.Offset + range.Length);
		_editor.ActiveTextAreaControl.SelectionManager.SetSelection(startPosition, endPosition);
		_editor.ActiveTextAreaControl.ScrollTo(startPosition.Line, startPosition.Column);
		_editor.ActiveTextAreaControl.Caret.Position = _editor.Document.OffsetToPosition(range.Offset + range.Length);
	}

	private void btnHighlightAll_Click(object sender, EventArgs e)
	{
		if (!_highlightGroups.ContainsKey(_editor))
		{
			_highlightGroups[_editor] = new HighlightGroup(_editor);
		}
		HighlightGroup highlightGroup = _highlightGroups[_editor];
		if (string.IsNullOrEmpty(LookFor))
		{
			highlightGroup.ClearMarkers();
			return;
		}
		_search.LookFor = txtLookFor.Text;
		_search.MatchCase = chkMatchCase.Checked;
		_search.MatchWholeWordOnly = chkMatchWholeWord.Checked;
		bool loopedAround = false;
		int beginAtOffset = 0;
		int num = 0;
		while (true)
		{
			TextRange textRange = _search.FindNext(beginAtOffset, searchBackward: false, out loopedAround);
			if ((textRange == null) | loopedAround)
			{
				break;
			}
			beginAtOffset = textRange.Offset + textRange.Length;
			num++;
			TextMarker marker = new TextMarker(textRange.Offset, textRange.Length, TextMarkerType.SolidBlock, Color.Yellow, Color.Black);
			highlightGroup.AddMarker(marker);
		}
		if (num == 0)
		{
			MessageBox.Show("Search text not found.");
		}
		else
		{
			Close();
		}
	}

	private void FindAndReplaceForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason != CloseReason.FormOwnerClosing)
		{
			if (base.Owner != null)
			{
				base.Owner.Select();
			}
			e.Cancel = true;
			Hide();
			_search.ClearScanRegion();
			_editor.Refresh();
		}
	}

	private void btnCancel_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void btnReplace_Click(object sender, EventArgs e)
	{
		if (string.Equals(_editor.ActiveTextAreaControl.SelectionManager.SelectedText, txtLookFor.Text, StringComparison.OrdinalIgnoreCase))
		{
			InsertText(txtReplaceWith.Text);
		}
		FindNext(viaF3: false, _lastSearchWasBackward, "Text not found.");
	}

	private void btnReplaceAll_Click(object sender, EventArgs e)
	{
		int num = 0;
		_editor.ActiveTextAreaControl.Caret.Position = _editor.Document.OffsetToPosition(_search.BeginOffset);
		_editor.Document.UndoStack.StartUndoGroup();
		try
		{
			while (FindNext(viaF3: false, searchBackward: false, null) != null && !_lastSearchLoopedAround)
			{
				num++;
				InsertText(txtReplaceWith.Text);
			}
		}
		finally
		{
			_editor.Document.UndoStack.EndUndoGroup();
		}
		if (num == 0)
		{
			MessageBox.Show("No occurrances found.");
			return;
		}
		MessageBox.Show($"Replaced {num} occurrances.");
		Close();
	}

	private void InsertText(string text)
	{
		TextArea textArea = _editor.ActiveTextAreaControl.TextArea;
		textArea.Document.UndoStack.StartUndoGroup();
		try
		{
			if (textArea.SelectionManager.HasSomethingSelected)
			{
				textArea.Caret.Position = textArea.SelectionManager.SelectionCollection[0].StartPosition;
				textArea.SelectionManager.RemoveSelectedText();
			}
			textArea.InsertString(text);
		}
		finally
		{
			textArea.Document.UndoStack.EndUndoGroup();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.label1 = new System.Windows.Forms.Label();
		this.lblReplaceWith = new System.Windows.Forms.Label();
		this.txtLookFor = new System.Windows.Forms.TextBox();
		this.txtReplaceWith = new System.Windows.Forms.TextBox();
		this.btnFindNext = new System.Windows.Forms.Button();
		this.btnReplace = new System.Windows.Forms.Button();
		this.btnReplaceAll = new System.Windows.Forms.Button();
		this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
		this.chkMatchCase = new System.Windows.Forms.CheckBox();
		this.btnHighlightAll = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.btnFindPrevious = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(12, 9);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(56, 13);
		this.label1.TabIndex = 0;
		this.label1.Text = "Fi&nd what:";
		this.lblReplaceWith.AutoSize = true;
		this.lblReplaceWith.Location = new System.Drawing.Point(12, 35);
		this.lblReplaceWith.Name = "lblReplaceWith";
		this.lblReplaceWith.Size = new System.Drawing.Size(72, 13);
		this.lblReplaceWith.TabIndex = 2;
		this.lblReplaceWith.Text = "Re&place with:";
		this.txtLookFor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtLookFor.Location = new System.Drawing.Point(90, 6);
		this.txtLookFor.Name = "txtLookFor";
		this.txtLookFor.Size = new System.Drawing.Size(236, 20);
		this.txtLookFor.TabIndex = 1;
		this.txtReplaceWith.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.txtReplaceWith.Location = new System.Drawing.Point(90, 32);
		this.txtReplaceWith.Name = "txtReplaceWith";
		this.txtReplaceWith.Size = new System.Drawing.Size(236, 20);
		this.txtReplaceWith.TabIndex = 3;
		this.btnFindNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnFindNext.Location = new System.Drawing.Point(251, 81);
		this.btnFindNext.Name = "btnFindNext";
		this.btnFindNext.Size = new System.Drawing.Size(75, 23);
		this.btnFindNext.TabIndex = 6;
		this.btnFindNext.Text = "&Find next";
		this.btnFindNext.UseVisualStyleBackColor = true;
		this.btnFindNext.Click += new System.EventHandler(btnFindNext_Click);
		this.btnReplace.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnReplace.Location = new System.Drawing.Point(89, 110);
		this.btnReplace.Name = "btnReplace";
		this.btnReplace.Size = new System.Drawing.Size(75, 23);
		this.btnReplace.TabIndex = 7;
		this.btnReplace.Text = "&Replace";
		this.btnReplace.UseVisualStyleBackColor = true;
		this.btnReplace.Click += new System.EventHandler(btnReplace_Click);
		this.btnReplaceAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnReplaceAll.Location = new System.Drawing.Point(170, 110);
		this.btnReplaceAll.Name = "btnReplaceAll";
		this.btnReplaceAll.Size = new System.Drawing.Size(75, 23);
		this.btnReplaceAll.TabIndex = 9;
		this.btnReplaceAll.Text = "Replace &All";
		this.btnReplaceAll.UseVisualStyleBackColor = true;
		this.btnReplaceAll.Click += new System.EventHandler(btnReplaceAll_Click);
		this.chkMatchWholeWord.AutoSize = true;
		this.chkMatchWholeWord.Location = new System.Drawing.Point(178, 58);
		this.chkMatchWholeWord.Name = "chkMatchWholeWord";
		this.chkMatchWholeWord.Size = new System.Drawing.Size(113, 17);
		this.chkMatchWholeWord.TabIndex = 5;
		this.chkMatchWholeWord.Text = "Match &whole word";
		this.chkMatchWholeWord.UseVisualStyleBackColor = true;
		this.chkMatchCase.AutoSize = true;
		this.chkMatchCase.Location = new System.Drawing.Point(90, 58);
		this.chkMatchCase.Name = "chkMatchCase";
		this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
		this.chkMatchCase.TabIndex = 4;
		this.chkMatchCase.Text = "Match &case";
		this.chkMatchCase.UseVisualStyleBackColor = true;
		this.btnHighlightAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnHighlightAll.Location = new System.Drawing.Point(109, 110);
		this.btnHighlightAll.Name = "btnHighlightAll";
		this.btnHighlightAll.Size = new System.Drawing.Size(136, 23);
		this.btnHighlightAll.TabIndex = 8;
		this.btnHighlightAll.Text = "Find && highlight &all";
		this.btnHighlightAll.UseVisualStyleBackColor = true;
		this.btnHighlightAll.Visible = false;
		this.btnHighlightAll.Click += new System.EventHandler(btnHighlightAll_Click);
		this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnCancel.Location = new System.Drawing.Point(251, 110);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(75, 23);
		this.btnCancel.TabIndex = 6;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = true;
		this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
		this.btnFindPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.btnFindPrevious.Location = new System.Drawing.Point(89, 81);
		this.btnFindPrevious.Name = "btnFindPrevious";
		this.btnFindPrevious.Size = new System.Drawing.Size(156, 23);
		this.btnFindPrevious.TabIndex = 6;
		this.btnFindPrevious.Text = "Find pre&vious";
		this.btnFindPrevious.UseVisualStyleBackColor = true;
		this.btnFindPrevious.Click += new System.EventHandler(btnFindPrevious_Click);
		base.AcceptButton = this.btnReplace;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.CancelButton = this.btnCancel;
		base.ClientSize = new System.Drawing.Size(338, 145);
		base.Controls.Add(this.chkMatchCase);
		base.Controls.Add(this.chkMatchWholeWord);
		base.Controls.Add(this.btnReplaceAll);
		base.Controls.Add(this.btnReplace);
		base.Controls.Add(this.btnHighlightAll);
		base.Controls.Add(this.btnCancel);
		base.Controls.Add(this.btnFindPrevious);
		base.Controls.Add(this.btnFindNext);
		base.Controls.Add(this.txtReplaceWith);
		base.Controls.Add(this.txtLookFor);
		base.Controls.Add(this.lblReplaceWith);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "FindAndReplaceForm";
		base.ShowIcon = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Find and replace";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FindAndReplaceForm_FormClosing);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
