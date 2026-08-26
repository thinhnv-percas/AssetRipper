using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.Document;

namespace TextEditor;

public class TextEditorExtended : UserControl
{
	public delegate void SaveHandle();

	public TextEditorControl editor_def;

	public string TextModeName;

	private ITextEditorProperties _editorSettings;

	public SaveHandle OnSave;

	private FindAndReplaceForm _findForm = new FindAndReplaceForm();

	private IContainer components;

	private OpenFileDialog openFileDialog;

	private SaveFileDialog saveFileDialog;

	private FontDialog fontDialog;

	private ToolStrip toolStrip;

	private ToolStripMenuItem fileToolStripMenuItem;

	private ToolStripMenuItem menuFileNew;

	private ToolStripMenuItem menuFileOpen;

	private ToolStripSeparator toolStripSeparator1;

	private ToolStripMenuItem menuFileSave;

	private ToolStripMenuItem menuFileSaveAs;

	private ToolStripMenuItem editToolStripMenuItem;

	private ToolStripMenuItem menuEditCut;

	private ToolStripMenuItem menuEditCopy;

	private ToolStripMenuItem menuEditPaste;

	private ToolStripMenuItem menuEditDelete;

	private ToolStripSeparator toolStripSeparator2;

	private ToolStripMenuItem menuEditFind;

	private ToolStripMenuItem menuEditReplace;

	private ToolStripMenuItem menuFindAgain;

	private ToolStripMenuItem menuFindAgainReverse;

	private ToolStripSeparator toolStripSeparator5;

	private ToolStripMenuItem menuToggleBookmark;

	private ToolStripMenuItem menuGoToNextBookmark;

	private ToolStripMenuItem menuGoToPrevBookmark;

	private Panel panel;

	private ToolStripMenuItem optionsToolStripMenuItem;

	private ToolStripMenuItem menuSplitTextArea;

	private ToolStripSeparator toolStripSeparator3;

	private ToolStripMenuItem menuShowSpacesTabs;

	private ToolStripMenuItem menuShowNewlines;

	private ToolStripMenuItem menuShowLineNumbers;

	private ToolStripMenuItem menuHighlightCurrentRow;

	private ToolStripMenuItem menuBracketMatchingStyle;

	private ToolStripMenuItem menuEnableVirtualSpace;

	private ToolStripSeparator toolStripSeparator4;

	private ToolStripMenuItem menuSetTabSize;

	private ToolStripMenuItem menuSetFont;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem toolStripMenuItem2;

	private ToolStripMenuItem toolStripMenuItem3;

	private ToolStripMenuItem toolStripMenuItem4;

	private ToolStripMenuItem toolStripMenuItem5;

	private ToolStripSeparator toolStripSeparator6;

	private ToolStripMenuItem toolStripMenuItem6;

	private ToolStripMenuItem toolStripMenuItem7;

	private ToolStripMenuItem toolStripMenuItem8;

	private ToolStripMenuItem toolStripMenuItem9;

	private ToolStripSeparator toolStripSeparator7;

	private ToolStripMenuItem toolStripMenuItem10;

	private ToolStripMenuItem toolStripMenuItem11;

	private ToolStripMenuItem toolStripMenuItem12;

	public bool ShowMenu
	{
		get
		{
			return toolStrip.Visible;
		}
		set
		{
			toolStrip.Visible = value;
		}
	}

	public bool ShowFileMenu
	{
		get
		{
			return fileToolStripMenuItem.Visible;
		}
		set
		{
			fileToolStripMenuItem.Visible = value;
		}
	}

	public bool IsReadOnly
	{
		get
		{
			return editor_def.IsReadOnly;
		}
		set
		{
			editor_def.IsReadOnly = value;
		}
	}

	public override string Text
	{
		get
		{
			return editor_def.Text;
		}
		set
		{
			editor_def.Text = value;
		}
	}

	private IEnumerable<TextEditorControl> AllEditors
	{
		get
		{
			yield return editor_def;
		}
	}

	private TextEditorControl ActiveEditor => editor_def;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public new event EventHandler TextChanged
	{
		add
		{
			editor_def.TextChanged += value;
		}
		remove
		{
			editor_def.TextChanged -= value;
		}
	}

	public void SetTextMode(string mode_name)
	{
		editor_def.SetHighlighting(mode_name);
	}

	public void SetCSharp(string text)
	{
		editor_def.SetHighlighting("C#");
		TextModeName = "C#";
		editor_def.Text = text;
	}

	public void SetCpp(string text)
	{
		editor_def.SetHighlighting("C++.NET");
		TextModeName = "C++.NET";
		editor_def.Text = text;
	}

	public void SetXML(string text)
	{
		editor_def.SetHighlighting("XML");
		TextModeName = "XML";
		editor_def.Text = text;
	}

	public void SetText(string text, string mode_name = null)
	{
		editor_def.SetHighlighting(mode_name ?? "TEXT");
		TextModeName = mode_name ?? "TEXT";
		editor_def.Text = text;
	}

	public string GetText()
	{
		return editor_def.Text;
	}

	public TextEditorExtended()
	{
		InitializeComponent();
		editor_def = new TextEditorControl();
		editor_def.Dock = DockStyle.Fill;
		panel.Controls.Add(editor_def);
		editor_def.Document.DocumentChanged += delegate
		{
			SetModifiedFlag(editor_def, flag: true);
		};
		if (_editorSettings == null)
		{
			_editorSettings = editor_def.TextEditorProperties;
			OnSettingsChanged();
		}
		else
		{
			editor_def.TextEditorProperties = _editorSettings;
		}
		AddNewTextEditor("New file");
	}

	private void menuFileNew_Click(object sender, EventArgs e)
	{
		AddNewTextEditor("New file");
	}

	internal TextEditorControl AddNewTextEditor(string title)
	{
		return editor_def;
	}

	private void menuFileOpen_Click(object sender, EventArgs e)
	{
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			OpenFiles(openFileDialog.FileName);
		}
	}

	private void OpenFiles(string fn)
	{
		TextEditorControl textEditorControl = AddNewTextEditor(Path.GetFileName(fn));
		try
		{
			textEditorControl.LoadFile(fn);
			SetModifiedFlag(textEditorControl, flag: false);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.GetType().Name);
			RemoveTextEditor(textEditorControl);
			return;
		}
		textEditorControl.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
		textEditorControl.Document.FoldingManager.UpdateFoldings(null, null);
	}

	private void menuFileClose_Click(object sender, EventArgs e)
	{
		if (ActiveEditor != null)
		{
			RemoveTextEditor(ActiveEditor);
		}
	}

	private void RemoveTextEditor(TextEditorControl editor)
	{
		editor_def.Text = "";
	}

	private void menuFileSave_Click(object sender, EventArgs e)
	{
		if (OnSave != null)
		{
			OnSave();
			return;
		}
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			DoSave(activeEditor);
		}
	}

	private bool DoSave(TextEditorControl editor)
	{
		if (string.IsNullOrEmpty(editor.FileName))
		{
			return DoSaveAs(editor);
		}
		try
		{
			editor.SaveFile(editor.FileName);
			SetModifiedFlag(editor, flag: false);
			return true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, ex.GetType().Name);
			return false;
		}
	}

	private void menuFileSaveAs_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			DoSaveAs(activeEditor);
		}
	}

	private bool DoSaveAs(TextEditorControl editor)
	{
		saveFileDialog.FileName = editor.FileName;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			try
			{
				editor.SaveFile(saveFileDialog.FileName);
				editor.Parent.Text = Path.GetFileName(editor.FileName);
				SetModifiedFlag(editor, flag: false);
				editor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name);
			}
		}
		return false;
	}

	private void DoEditAction(TextEditorControl editor, IEditAction action)
	{
		if (editor_def.IsViewOnly)
		{
			try
			{
				editor.ActiveTextAreaControl.TextArea.SelectionManager.ClearSelection();
			}
			catch
			{
			}
			if (action is Copy || action is Cut || action is Delete)
			{
				return;
			}
		}
		if (editor == null || action == null)
		{
			return;
		}
		TextArea textArea = editor.ActiveTextAreaControl.TextArea;
		editor.BeginUpdate();
		try
		{
			lock (editor.Document)
			{
				action.Execute(textArea);
				if (textArea.SelectionManager.HasSomethingSelected && textArea.AutoClearSelection && textArea.Document.TextEditorProperties.DocumentSelectionMode == DocumentSelectionMode.Normal)
				{
					textArea.SelectionManager.ClearSelection();
				}
			}
		}
		finally
		{
			editor.EndUpdate();
			textArea.Caret.UpdateCaretPosition();
		}
	}

	private void menuEditCut_Click(object sender, EventArgs e)
	{
		if (HaveSelection())
		{
			DoEditAction(ActiveEditor, new Cut());
		}
	}

	private void menuEditCopy_Click(object sender, EventArgs e)
	{
		if (HaveSelection())
		{
			DoEditAction(ActiveEditor, new Copy());
		}
	}

	private void menuEditPaste_Click(object sender, EventArgs e)
	{
		DoEditAction(ActiveEditor, new Paste());
	}

	private void menuEditDelete_Click(object sender, EventArgs e)
	{
		if (HaveSelection())
		{
			DoEditAction(ActiveEditor, new Delete());
		}
	}

	public void InsertText(string ins_text)
	{
		DoEditAction(ActiveEditor, new Insert
		{
			text = ins_text
		});
	}

	private bool HaveSelection()
	{
		if (editor_def.IsViewOnly)
		{
			return false;
		}
		return ActiveEditor?.ActiveTextAreaControl.TextArea.SelectionManager.HasSomethingSelected ?? false;
	}

	private void menuEditFind_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			_findForm.ShowFor(activeEditor, replaceMode: false);
		}
	}

	private void menuEditReplace_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			_findForm.ShowFor(activeEditor, replaceMode: true);
		}
	}

	private void menuFindAgain_Click(object sender, EventArgs e)
	{
		_findForm.FindNext(viaF3: true, searchBackward: false, $"Search text «{_findForm.LookFor}» not found.");
	}

	private void menuFindAgainReverse_Click(object sender, EventArgs e)
	{
		_findForm.FindNext(viaF3: true, searchBackward: true, $"Search text «{_findForm.LookFor}» not found.");
	}

	private void menuToggleBookmark_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			DoEditAction(ActiveEditor, new ToggleBookmark());
			activeEditor.IsIconBarVisible = activeEditor.Document.BookmarkManager.Marks.Count > 0;
		}
	}

	private void menuGoToNextBookmark_Click(object sender, EventArgs e)
	{
		DoEditAction(ActiveEditor, new GotoNextBookmark((Bookmark bookmark) => true));
	}

	private void menuGoToPrevBookmark_Click(object sender, EventArgs e)
	{
		DoEditAction(ActiveEditor, new GotoPrevBookmark((Bookmark bookmark) => true));
	}

	private void menuSplitTextArea_Click(object sender, EventArgs e)
	{
		ActiveEditor?.Split();
	}

	private void OnSettingsChanged()
	{
		menuShowSpacesTabs.Checked = _editorSettings.ShowSpaces;
		menuShowNewlines.Checked = _editorSettings.ShowEOLMarker;
		menuHighlightCurrentRow.Checked = _editorSettings.LineViewerStyle == LineViewerStyle.FullRow;
		menuBracketMatchingStyle.Checked = _editorSettings.BracketMatchingStyle == BracketMatchingStyle.After;
		menuEnableVirtualSpace.Checked = _editorSettings.AllowCaretBeyondEOL;
		menuShowLineNumbers.Checked = _editorSettings.ShowLineNumbers;
	}

	private void menuShowSpaces_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			bool showSpaces = (activeEditor.ShowTabs = !activeEditor.ShowSpaces);
			activeEditor.ShowSpaces = showSpaces;
			OnSettingsChanged();
		}
	}

	private void menuShowNewlines_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			activeEditor.ShowEOLMarkers = !activeEditor.ShowEOLMarkers;
			OnSettingsChanged();
		}
	}

	private void menuHighlightCurrentRow_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			activeEditor.LineViewerStyle = ((activeEditor.LineViewerStyle == LineViewerStyle.None) ? LineViewerStyle.FullRow : LineViewerStyle.None);
			OnSettingsChanged();
		}
	}

	private void menuBracketMatchingStyle_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			activeEditor.BracketMatchingStyle = ((activeEditor.BracketMatchingStyle != BracketMatchingStyle.After) ? BracketMatchingStyle.After : BracketMatchingStyle.Before);
			OnSettingsChanged();
		}
	}

	private void menuEnableVirtualSpace_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			activeEditor.AllowCaretBeyondEOL = !activeEditor.AllowCaretBeyondEOL;
			OnSettingsChanged();
		}
	}

	private void menuShowLineNumbers_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			activeEditor.ShowLineNumbers = !activeEditor.ShowLineNumbers;
			OnSettingsChanged();
		}
	}

	private void menuSetTabSize_Click(object sender, EventArgs e)
	{
		if (ActiveEditor != null)
		{
			string text = InputBox.Show("Specify the desired tab width.", "Tab size", _editorSettings.TabIndent.ToString());
			if (text != null && int.TryParse(text, out var result) && result.IsInRange(1, 32))
			{
				ActiveEditor.TabIndent = result;
			}
		}
	}

	private void menuSetFont_Click(object sender, EventArgs e)
	{
		TextEditorControl activeEditor = ActiveEditor;
		if (activeEditor != null)
		{
			fontDialog.Font = activeEditor.Font;
			if (fontDialog.ShowDialog(this) == DialogResult.OK)
			{
				activeEditor.Font = fontDialog.Font;
				OnSettingsChanged();
			}
		}
	}

	private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
	{
		foreach (TextEditorControl allEditor in AllEditors)
		{
			if (!IsModified(allEditor) || allEditor.IsViewOnly)
			{
				continue;
			}
			switch (MessageBox.Show(string.Format("Save changes to {0}?", allEditor.FileName ?? "new file"), "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
			{
			case DialogResult.Cancel:
				e.Cancel = true;
				break;
			case DialogResult.Yes:
				if (!DoSave(allEditor))
				{
					e.Cancel = true;
				}
				break;
			}
		}
	}

	private bool IsModified(TextEditorControl editor)
	{
		return editor.Parent.Text.EndsWith("*");
	}

	private void SetModifiedFlag(TextEditorControl editor, bool flag)
	{
		if (IsModified(editor) != flag)
		{
			Control control = editor.Parent;
			if (IsModified(editor))
			{
				control.Text = control.Text.Substring(0, control.Text.Length - 1);
			}
			else
			{
				control.Text += "*";
			}
		}
	}

	private void TextEditorForm_DragEnter(object sender, DragEventArgs e)
	{
		if (ActiveEditor.IsViewOnly)
		{
			e.Effect = DragDropEffects.None;
		}
		else if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			e.Effect = DragDropEffects.Copy;
		}
	}

	private void TextEditorForm_DragDrop(object sender, DragEventArgs e)
	{
		if (ActiveEditor.IsViewOnly)
		{
			e.Effect = DragDropEffects.None;
		}
		else if (e.Data.GetData(DataFormats.FileDrop) is string[] array && array.Length != 0)
		{
			OpenFiles(array[0]);
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
		this.components = new System.ComponentModel.Container();
		this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
		this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
		this.fontDialog = new System.Windows.Forms.FontDialog();
		this.toolStrip = new System.Windows.Forms.ToolStrip();
		this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
		this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
		this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
		this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEditCut = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
		this.menuEditFind = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEditReplace = new System.Windows.Forms.ToolStripMenuItem();
		this.menuFindAgain = new System.Windows.Forms.ToolStripMenuItem();
		this.menuFindAgainReverse = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
		this.menuToggleBookmark = new System.Windows.Forms.ToolStripMenuItem();
		this.menuGoToNextBookmark = new System.Windows.Forms.ToolStripMenuItem();
		this.menuGoToPrevBookmark = new System.Windows.Forms.ToolStripMenuItem();
		this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.menuSplitTextArea = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.menuShowSpacesTabs = new System.Windows.Forms.ToolStripMenuItem();
		this.menuShowNewlines = new System.Windows.Forms.ToolStripMenuItem();
		this.menuShowLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
		this.menuHighlightCurrentRow = new System.Windows.Forms.ToolStripMenuItem();
		this.menuBracketMatchingStyle = new System.Windows.Forms.ToolStripMenuItem();
		this.menuEnableVirtualSpace = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
		this.menuSetTabSize = new System.Windows.Forms.ToolStripMenuItem();
		this.menuSetFont = new System.Windows.Forms.ToolStripMenuItem();
		this.panel = new System.Windows.Forms.Panel();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStrip.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		base.SuspendLayout();
		this.openFileDialog.Multiselect = true;
		this.fontDialog.AllowVerticalFonts = false;
		this.fontDialog.ShowEffects = false;
		this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.fileToolStripMenuItem, this.editToolStripMenuItem, this.optionsToolStripMenuItem });
		this.toolStrip.Location = new System.Drawing.Point(0, 0);
		this.toolStrip.Name = "toolStrip";
		this.toolStrip.Size = new System.Drawing.Size(364, 25);
		this.toolStrip.TabIndex = 0;
		this.toolStrip.Text = "toolStrip1";
		this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.menuFileNew, this.menuFileOpen, this.toolStripSeparator1, this.menuFileSave, this.menuFileSaveAs });
		this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 25);
		this.fileToolStripMenuItem.Text = "&File";
		this.menuFileNew.Name = "menuFileNew";
		this.menuFileNew.ShortcutKeys = System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control;
		this.menuFileNew.Size = new System.Drawing.Size(155, 22);
		this.menuFileNew.Text = "&New";
		this.menuFileNew.Click += new System.EventHandler(menuFileNew_Click);
		this.menuFileOpen.Name = "menuFileOpen";
		this.menuFileOpen.ShortcutKeys = System.Windows.Forms.Keys.O | System.Windows.Forms.Keys.Control;
		this.menuFileOpen.Size = new System.Drawing.Size(155, 22);
		this.menuFileOpen.Text = "&Open...";
		this.menuFileOpen.Click += new System.EventHandler(menuFileOpen_Click);
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
		this.menuFileSave.Name = "menuFileSave";
		this.menuFileSave.ShortcutKeys = System.Windows.Forms.Keys.S | System.Windows.Forms.Keys.Control;
		this.menuFileSave.Size = new System.Drawing.Size(155, 22);
		this.menuFileSave.Text = "&Save";
		this.menuFileSave.Click += new System.EventHandler(menuFileSave_Click);
		this.menuFileSaveAs.Name = "menuFileSaveAs";
		this.menuFileSaveAs.Size = new System.Drawing.Size(155, 22);
		this.menuFileSaveAs.Text = "Save as...";
		this.menuFileSaveAs.Click += new System.EventHandler(menuFileSaveAs_Click);
		this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[13]
		{
			this.menuEditCut, this.menuEditCopy, this.menuEditPaste, this.menuEditDelete, this.toolStripSeparator2, this.menuEditFind, this.menuEditReplace, this.menuFindAgain, this.menuFindAgainReverse, this.toolStripSeparator5,
			this.menuToggleBookmark, this.menuGoToNextBookmark, this.menuGoToPrevBookmark
		});
		this.editToolStripMenuItem.Name = "editToolStripMenuItem";
		this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 25);
		this.editToolStripMenuItem.Text = "&Edit";
		this.menuEditCut.Name = "menuEditCut";
		this.menuEditCut.ShortcutKeys = System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control;
		this.menuEditCut.Size = new System.Drawing.Size(259, 22);
		this.menuEditCut.Text = "Cu&t";
		this.menuEditCut.Click += new System.EventHandler(menuEditCut_Click);
		this.menuEditCopy.Name = "menuEditCopy";
		this.menuEditCopy.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
		this.menuEditCopy.Size = new System.Drawing.Size(259, 22);
		this.menuEditCopy.Text = "&Copy";
		this.menuEditCopy.Click += new System.EventHandler(menuEditCopy_Click);
		this.menuEditPaste.Name = "menuEditPaste";
		this.menuEditPaste.ShortcutKeys = System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control;
		this.menuEditPaste.Size = new System.Drawing.Size(259, 22);
		this.menuEditPaste.Text = "&Paste";
		this.menuEditPaste.Click += new System.EventHandler(menuEditPaste_Click);
		this.menuEditDelete.Name = "menuEditDelete";
		this.menuEditDelete.Size = new System.Drawing.Size(259, 22);
		this.menuEditDelete.Text = "&Delete";
		this.menuEditDelete.Click += new System.EventHandler(menuEditDelete_Click);
		this.toolStripSeparator2.Name = "toolStripSeparator2";
		this.toolStripSeparator2.Size = new System.Drawing.Size(256, 6);
		this.menuEditFind.Name = "menuEditFind";
		this.menuEditFind.ShortcutKeys = System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Control;
		this.menuEditFind.Size = new System.Drawing.Size(259, 22);
		this.menuEditFind.Text = "&Find...";
		this.menuEditFind.Click += new System.EventHandler(menuEditFind_Click);
		this.menuEditReplace.Name = "menuEditReplace";
		this.menuEditReplace.ShortcutKeys = System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control;
		this.menuEditReplace.Size = new System.Drawing.Size(259, 22);
		this.menuEditReplace.Text = "Find and &replace...";
		this.menuEditReplace.Click += new System.EventHandler(menuEditReplace_Click);
		this.menuFindAgain.Name = "menuFindAgain";
		this.menuFindAgain.ShortcutKeys = System.Windows.Forms.Keys.F3;
		this.menuFindAgain.Size = new System.Drawing.Size(259, 22);
		this.menuFindAgain.Text = "Find &again";
		this.menuFindAgain.Click += new System.EventHandler(menuFindAgain_Click);
		this.menuFindAgainReverse.Name = "menuFindAgainReverse";
		this.menuFindAgainReverse.ShortcutKeys = System.Windows.Forms.Keys.F3 | System.Windows.Forms.Keys.Shift;
		this.menuFindAgainReverse.Size = new System.Drawing.Size(259, 22);
		this.menuFindAgainReverse.Text = "Find again (&reverse)";
		this.menuFindAgainReverse.Click += new System.EventHandler(menuFindAgainReverse_Click);
		this.toolStripSeparator5.Name = "toolStripSeparator5";
		this.toolStripSeparator5.Size = new System.Drawing.Size(256, 6);
		this.menuToggleBookmark.Name = "menuToggleBookmark";
		this.menuToggleBookmark.ShortcutKeys = System.Windows.Forms.Keys.F2 | System.Windows.Forms.Keys.Control;
		this.menuToggleBookmark.Size = new System.Drawing.Size(259, 22);
		this.menuToggleBookmark.Text = "Toggle bookmark";
		this.menuToggleBookmark.Click += new System.EventHandler(menuToggleBookmark_Click);
		this.menuGoToNextBookmark.Name = "menuGoToNextBookmark";
		this.menuGoToNextBookmark.ShortcutKeys = System.Windows.Forms.Keys.F2;
		this.menuGoToNextBookmark.Size = new System.Drawing.Size(259, 22);
		this.menuGoToNextBookmark.Text = "Go to next bookmark";
		this.menuGoToNextBookmark.Click += new System.EventHandler(menuGoToNextBookmark_Click);
		this.menuGoToPrevBookmark.Name = "menuGoToPrevBookmark";
		this.menuGoToPrevBookmark.ShortcutKeys = System.Windows.Forms.Keys.F2 | System.Windows.Forms.Keys.Shift;
		this.menuGoToPrevBookmark.Size = new System.Drawing.Size(259, 22);
		this.menuGoToPrevBookmark.Text = "Go to previous bookmark";
		this.menuGoToPrevBookmark.Click += new System.EventHandler(menuGoToPrevBookmark_Click);
		this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[11]
		{
			this.menuSplitTextArea, this.toolStripSeparator3, this.menuShowSpacesTabs, this.menuShowNewlines, this.menuShowLineNumbers, this.menuHighlightCurrentRow, this.menuBracketMatchingStyle, this.menuEnableVirtualSpace, this.toolStripSeparator4, this.menuSetTabSize,
			this.menuSetFont
		});
		this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
		this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 25);
		this.optionsToolStripMenuItem.Text = "&Options";
		this.menuSplitTextArea.Name = "menuSplitTextArea";
		this.menuSplitTextArea.Size = new System.Drawing.Size(331, 22);
		this.menuSplitTextArea.Text = "Split text area";
		this.menuSplitTextArea.Click += new System.EventHandler(menuSplitTextArea_Click);
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(328, 6);
		this.menuShowSpacesTabs.Name = "menuShowSpacesTabs";
		this.menuShowSpacesTabs.Size = new System.Drawing.Size(331, 22);
		this.menuShowSpacesTabs.Text = "Show spaces && tabs";
		this.menuShowSpacesTabs.Click += new System.EventHandler(menuShowSpaces_Click);
		this.menuShowNewlines.Name = "menuShowNewlines";
		this.menuShowNewlines.Size = new System.Drawing.Size(331, 22);
		this.menuShowNewlines.Text = "Show newlines";
		this.menuShowNewlines.Click += new System.EventHandler(menuShowNewlines_Click);
		this.menuShowLineNumbers.Name = "menuShowLineNumbers";
		this.menuShowLineNumbers.Size = new System.Drawing.Size(331, 22);
		this.menuShowLineNumbers.Text = "Show line numbers";
		this.menuShowLineNumbers.Click += new System.EventHandler(menuShowNewlines_Click);
		this.menuHighlightCurrentRow.Name = "menuHighlightCurrentRow";
		this.menuHighlightCurrentRow.Size = new System.Drawing.Size(331, 22);
		this.menuHighlightCurrentRow.Text = "Highlight current row";
		this.menuHighlightCurrentRow.Click += new System.EventHandler(menuHighlightCurrentRow_Click);
		this.menuBracketMatchingStyle.Name = "menuBracketMatchingStyle";
		this.menuBracketMatchingStyle.Size = new System.Drawing.Size(331, 22);
		this.menuBracketMatchingStyle.Text = "Highlight matching brackets when cursor is after";
		this.menuBracketMatchingStyle.Click += new System.EventHandler(menuBracketMatchingStyle_Click);
		this.menuEnableVirtualSpace.Name = "menuEnableVirtualSpace";
		this.menuEnableVirtualSpace.Size = new System.Drawing.Size(331, 22);
		this.menuEnableVirtualSpace.Text = "Allow cursor past end-of-line";
		this.menuEnableVirtualSpace.Click += new System.EventHandler(menuEnableVirtualSpace_Click);
		this.toolStripSeparator4.Name = "toolStripSeparator4";
		this.toolStripSeparator4.Size = new System.Drawing.Size(328, 6);
		this.menuSetTabSize.Name = "menuSetTabSize";
		this.menuSetTabSize.Size = new System.Drawing.Size(331, 22);
		this.menuSetTabSize.Text = "Set tab size...";
		this.menuSetTabSize.Click += new System.EventHandler(menuSetTabSize_Click);
		this.menuSetFont.Name = "menuSetFont";
		this.menuSetFont.Size = new System.Drawing.Size(331, 22);
		this.menuSetFont.Text = "Set font...";
		this.menuSetFont.Click += new System.EventHandler(menuSetFont_Click);
		this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel.Location = new System.Drawing.Point(0, 25);
		this.panel.Name = "panel";
		this.panel.Size = new System.Drawing.Size(364, 252);
		this.panel.TabIndex = 3;
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
		{
			this.toolStripMenuItem2, this.toolStripMenuItem3, this.toolStripMenuItem4, this.toolStripMenuItem5, this.toolStripSeparator6, this.toolStripMenuItem6, this.toolStripMenuItem7, this.toolStripMenuItem8, this.toolStripMenuItem9, this.toolStripSeparator7,
			this.toolStripMenuItem10, this.toolStripMenuItem11, this.toolStripMenuItem12
		});
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(260, 258);
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem2.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem2.Text = "Cu&t";
		this.toolStripMenuItem2.Click += new System.EventHandler(menuEditCut_Click);
		this.toolStripMenuItem3.Name = "toolStripMenuItem3";
		this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.C | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem3.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem3.Text = "&Copy";
		this.toolStripMenuItem3.Click += new System.EventHandler(menuEditCopy_Click);
		this.toolStripMenuItem4.Name = "toolStripMenuItem4";
		this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.V | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem4.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem4.Text = "&Paste";
		this.toolStripMenuItem4.Click += new System.EventHandler(menuEditPaste_Click);
		this.toolStripMenuItem5.Name = "toolStripMenuItem5";
		this.toolStripMenuItem5.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem5.Text = "&Delete";
		this.toolStripMenuItem5.Click += new System.EventHandler(menuEditDelete_Click);
		this.toolStripSeparator6.Name = "toolStripSeparator6";
		this.toolStripSeparator6.Size = new System.Drawing.Size(256, 6);
		this.toolStripMenuItem6.Name = "toolStripMenuItem6";
		this.toolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.F | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem6.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem6.Text = "&Find...";
		this.toolStripMenuItem6.Click += new System.EventHandler(menuEditFind_Click);
		this.toolStripMenuItem7.Name = "toolStripMenuItem7";
		this.toolStripMenuItem7.ShortcutKeys = System.Windows.Forms.Keys.H | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem7.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem7.Text = "Find and &replace...";
		this.toolStripMenuItem7.Click += new System.EventHandler(menuEditReplace_Click);
		this.toolStripMenuItem8.Name = "toolStripMenuItem8";
		this.toolStripMenuItem8.ShortcutKeys = System.Windows.Forms.Keys.F3;
		this.toolStripMenuItem8.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem8.Text = "Find &again";
		this.toolStripMenuItem8.Click += new System.EventHandler(menuFindAgain_Click);
		this.toolStripMenuItem9.Name = "toolStripMenuItem9";
		this.toolStripMenuItem9.ShortcutKeys = System.Windows.Forms.Keys.F3 | System.Windows.Forms.Keys.Shift;
		this.toolStripMenuItem9.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem9.Text = "Find again (&reverse)";
		this.toolStripMenuItem9.Click += new System.EventHandler(menuFindAgainReverse_Click);
		this.toolStripSeparator7.Name = "toolStripSeparator7";
		this.toolStripSeparator7.Size = new System.Drawing.Size(256, 6);
		this.toolStripMenuItem10.Name = "toolStripMenuItem10";
		this.toolStripMenuItem10.ShortcutKeys = System.Windows.Forms.Keys.F2 | System.Windows.Forms.Keys.Control;
		this.toolStripMenuItem10.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem10.Text = "Toggle bookmark";
		this.toolStripMenuItem10.Click += new System.EventHandler(menuToggleBookmark_Click);
		this.toolStripMenuItem11.Name = "toolStripMenuItem11";
		this.toolStripMenuItem11.ShortcutKeys = System.Windows.Forms.Keys.F2;
		this.toolStripMenuItem11.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem11.Text = "Go to next bookmark";
		this.toolStripMenuItem11.Click += new System.EventHandler(menuGoToNextBookmark_Click);
		this.toolStripMenuItem12.Name = "toolStripMenuItem12";
		this.toolStripMenuItem12.ShortcutKeys = System.Windows.Forms.Keys.F2 | System.Windows.Forms.Keys.Shift;
		this.toolStripMenuItem12.Size = new System.Drawing.Size(259, 22);
		this.toolStripMenuItem12.Text = "Go to previous bookmark";
		this.toolStripMenuItem12.Click += new System.EventHandler(menuGoToPrevBookmark_Click);
		this.AllowDrop = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ContextMenuStrip = this.contextMenuStrip1;
		base.Controls.Add(this.panel);
		base.Controls.Add(this.toolStrip);
		base.Name = "TextEditorExtended";
		base.Size = new System.Drawing.Size(364, 277);
		base.DragDrop += new System.Windows.Forms.DragEventHandler(TextEditorForm_DragDrop);
		base.DragEnter += new System.Windows.Forms.DragEventHandler(TextEditorForm_DragEnter);
		this.toolStrip.ResumeLayout(false);
		this.toolStrip.PerformLayout();
		this.contextMenuStrip1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
