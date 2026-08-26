using @as;
using DevXUnityUnpackerTools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DevXUnityUnpackerTools._WinForm
{
	public class PPtSelectForm : Form
	{
		internal ImageResData PPtSelected;

		internal ClassIDEnum? PPtType;

		private static bool SearchBreak;

		private string f_Name;

		private string f_ClassName;

		private long f_ID;

		private List<byte[]> f_ContentText_buff = new List<byte[]>();

		private string f_ContentText;

		private bool searchInScripts;

		private IContainer components;

		private ToolStrip toolStrip5;

		private ToolStripButton toolStripButton_Find;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripButton toolStripButton_Clear;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton toolStripButton_Break;

		private GroupBox gr_Filter;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolStripButton1;

		private Label label1;

		private ListView listView;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ToolStripSeparator toolStripSeparator3;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel lb_status;

		private ToolStripProgressBar progressBar;

		private Label label3;

		private TextBox ed_Name;

		private Label label4;

		private TextBox ed_ID;

		private Label label6;

		private ComboBox ed_Class;

		private Label label5;

		private ColumnHeader columnHeader4;

		public PPtSelectForm()
		{
			InitializeComponent();
			progressBar.Visible = false;
			ed_Class.Items.Add("");
			foreach (object value in Enum.GetValues(typeof(ClassIDEnum)))
			{
				ed_Class.Items.Add(value.ToString());
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (PPtType.HasValue)
			{
				ed_Class.Text = PPtType.Value.ToString();
			}
			toolStripButton_Find_Click(null, null);
		}

		private void toolStripButton_Clear_Click(object sender, EventArgs e)
		{
			listView.Items.Clear();
			ed_ID.Text = "";
			ed_Name.Text = "";
		}

		private void toolStripButton_Break_Click(object sender, EventArgs e)
		{
			SearchBreak = true;
		}

		private void Filter_Enter(object sender, EventArgs e)
		{
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			gr_Filter.Visible = !gr_Filter.Visible;
		}

		private void toolStripButton_Find_Click(object sender, EventArgs e)
		{
			lb_status.Text = "";
			f_ContentText_buff.Clear();
			f_Name = ed_Name.Text;
			f_ID = FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(ed_ID.Text, 0L);
			f_ClassName = ed_Class.Text;
			listView.Items.Clear();
			SearchBreak = false;
			toolStripButton_Find.Enabled = false;
			progressBar.Visible = true;
			lb_status.Text = TranslationManager.TryGetTranslated(127543718);
			listView.BeginUpdate();
			try
			{
				SunSearchAll();
			}
			finally
			{
				listView.EndUpdate();
			}
		}

		private void SunSearchAll()
		{
			try
			{
				SunSearch(MainForm.instance._0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020);
			}
			catch (Exception _0020)
			{
				ConsoleManager.WriteEx45(_0020);
			}
			finally
			{
				toolStripButton_Find.Enabled = true;
				progressBar.Visible = false;
				lb_status.Text = "Search end, find count: " + listView.Items.Count;
			}
		}

		private void SunSearch(IEnumerable<ImageResData> items)
		{
			foreach (ImageResData item in items)
			{
				try
				{
					if (SearchBreak)
					{
						return;
					}
					if (item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020 != null && (f_ID == 0L || item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A == f_ID) && (string.IsNullOrEmpty(f_ClassName) || !(item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020.objectType.ToString().ToString() != f_ClassName)))
					{
						if (string.IsNullOrEmpty(f_Name))
						{
							goto IL_00b1;
						}
						string _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 = item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020;
						if (_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020 == null || _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020.IndexOf(f_Name, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
						{
							goto IL_00b1;
						}
					}
					goto end_IL_0013;
					IL_00b1:
					AddItem(item);
					end_IL_0013:;
				}
				catch (Exception _0020)
				{
					ConsoleManager.WriteEx45(_0020);
				}
			}
		}

		private void AddItem(ImageResData item)
		{
			try
			{
				string text = item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A.ToString();
				ListViewItem listViewItem = new ListViewItem(new string[4]
				{
					text,
					item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020?._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020,
					item.ToString(),
					item._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020
				});
				listViewItem.Tag = item;
				listView.Items.Add(listViewItem);
			}
			catch (Exception _0020)
			{
				ConsoleManager.WriteEx45(_0020);
			}
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count != 0)
			{
				ImageResData imageResData = listView.SelectedItems[0].Tag as ImageResData;
				if (imageResData != null)
				{
					PPtSelected = imageResData;
					base.DialogResult = DialogResult.OK;
					Close();
				}
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
			toolStrip5 = new System.Windows.Forms.ToolStrip();
			toolStripButton_Find = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			toolStripButton_Clear = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			toolStripButton_Break = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			gr_Filter = new System.Windows.Forms.GroupBox();
			ed_ID = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			ed_Name = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			listView = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			progressBar = new System.Windows.Forms.ToolStripProgressBar();
			lb_status = new System.Windows.Forms.ToolStripStatusLabel();
			ed_Class = new System.Windows.Forms.ComboBox();
			label5 = new System.Windows.Forms.Label();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			toolStrip5.SuspendLayout();
			gr_Filter.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[8]
			{
				toolStripButton_Find,
				toolStripSeparator18,
				toolStripButton_Clear,
				toolStripSeparator2,
				toolStripButton_Break,
				toolStripSeparator1,
				toolStripButton1,
				toolStripSeparator3
			});
			toolStrip5.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			toolStrip5.Location = new System.Drawing.Point(0, 0);
			toolStrip5.Name = "toolStrip5";
			toolStrip5.Size = new System.Drawing.Size(688, 23);
			toolStrip5.TabIndex = 14;
			toolStrip5.Text = TranslationManager.TryGetTranslated(-409470413);
			toolStripButton_Find.Image = DevXUnityUnpackerTools.Properties.Resources.Find16;
			toolStripButton_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton_Find.Name = "toolStripButton_Find";
			toolStripButton_Find.Size = new System.Drawing.Size(50, 20);
			toolStripButton_Find.Text = TranslationManager.TryGetTranslated(835817774);
			toolStripButton_Find.Click += new System.EventHandler(toolStripButton_Find_Click);
			toolStripSeparator18.Name = "toolStripSeparator18";
			toolStripSeparator18.Size = new System.Drawing.Size(6, 23);
			toolStripButton_Clear.Image = DevXUnityUnpackerTools.Properties.Resources.New16;
			toolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton_Clear.Name = "toolStripButton_Clear";
			toolStripButton_Clear.Size = new System.Drawing.Size(54, 20);
			toolStripButton_Clear.Text = TranslationManager.TryGetTranslated(556466);
			toolStripButton_Clear.Click += new System.EventHandler(toolStripButton_Clear_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
			toolStripButton_Break.Image = DevXUnityUnpackerTools.Properties.Resources.Wrong16;
			toolStripButton_Break.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton_Break.Name = "toolStripButton_Break";
			toolStripButton_Break.Size = new System.Drawing.Size(56, 20);
			toolStripButton_Break.Text = TranslationManager.TryGetTranslated(22183322);
			toolStripButton_Break.Click += new System.EventHandler(toolStripButton_Break_Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			toolStripButton1.Image = DevXUnityUnpackerTools.Properties.Resources.Filter16;
			toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new System.Drawing.Size(120, 20);
			toolStripButton1.Text = TranslationManager.TryGetTranslated(-427515991);
			toolStripButton1.Click += new System.EventHandler(toolStripButton1_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
			gr_Filter.Controls.Add(ed_Class);
			gr_Filter.Controls.Add(label5);
			gr_Filter.Controls.Add(ed_ID);
			gr_Filter.Controls.Add(label6);
			gr_Filter.Controls.Add(ed_Name);
			gr_Filter.Controls.Add(label4);
			gr_Filter.Dock = System.Windows.Forms.DockStyle.Top;
			gr_Filter.Location = new System.Drawing.Point(0, 25);
			gr_Filter.Name = "gr_Filter";
			gr_Filter.Size = new System.Drawing.Size(688, 110);
			gr_Filter.TabIndex = 15;
			gr_Filter.TabStop = false;
			gr_Filter.Text = TranslationManager.TryGetTranslated(1557881769);
			gr_Filter.Enter += new System.EventHandler(Filter_Enter);
			ed_ID.Location = new System.Drawing.Point(125, 42);
			ed_ID.Name = "ed_ID";
			ed_ID.Size = new System.Drawing.Size(228, 20);
			ed_ID.TabIndex = 9;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(12, 45);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(18, 13);
			label6.TabIndex = 10;
			label6.Text = TranslationManager.TryGetTranslated(-838420505);
			ed_Name.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			ed_Name.Location = new System.Drawing.Point(125, 16);
			ed_Name.Name = "ed_Name";
			ed_Name.Size = new System.Drawing.Size(551, 20);
			ed_Name.TabIndex = 0;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(12, 19);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(35, 13);
			label4.TabIndex = 6;
			label4.Text = TranslationManager.TryGetTranslated(62725275);
			label3.Dock = System.Windows.Forms.DockStyle.Top;
			label3.Location = new System.Drawing.Point(0, 135);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(688, 23);
			label3.TabIndex = 6;
			label3.Text = TranslationManager.TryGetTranslated(-1156032391);
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label1.Dock = System.Windows.Forms.DockStyle.Top;
			label1.Location = new System.Drawing.Point(0, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(688, 2);
			label1.TabIndex = 16;
			label1.Text = TranslationManager.TryGetTranslated(-370664186);
			listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[4]
			{
				columnHeader1,
				columnHeader2,
				columnHeader3,
				columnHeader4
			});
			listView.Dock = System.Windows.Forms.DockStyle.Fill;
			listView.FullRowSelect = true;
			listView.GridLines = true;
			listView.LabelEdit = true;
			listView.Location = new System.Drawing.Point(0, 158);
			listView.Name = "listView";
			listView.Size = new System.Drawing.Size(688, 430);
			listView.TabIndex = 17;
			listView.UseCompatibleStateImageBehavior = false;
			listView.View = System.Windows.Forms.View.Details;
			listView.DoubleClick += new System.EventHandler(listView_DoubleClick);
			columnHeader1.Text = TranslationManager.TryGetTranslated(-838420505);
			columnHeader1.Width = 78;
			columnHeader2.Text = TranslationManager.TryGetTranslated(62725275);
			columnHeader2.Width = 176;
			columnHeader3.Text = TranslationManager.TryGetTranslated(-1051447098);
			columnHeader3.Width = 126;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				progressBar,
				lb_status
			});
			statusStrip1.Location = new System.Drawing.Point(0, 588);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(688, 22);
			statusStrip1.TabIndex = 18;
			statusStrip1.Text = TranslationManager.TryGetTranslated(-1054648736);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(100, 16);
			progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			lb_status.Name = "lb_status";
			lb_status.Size = new System.Drawing.Size(39, 17);
			lb_status.Text = TranslationManager.TryGetTranslated(-1971147459);
			ed_Class.FormattingEnabled = true;
			ed_Class.Location = new System.Drawing.Point(125, 68);
			ed_Class.Name = "ed_Class";
			ed_Class.Size = new System.Drawing.Size(228, 21);
			ed_Class.TabIndex = 13;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(12, 72);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(89, 13);
			label5.TabIndex = 12;
			label5.Text = TranslationManager.TryGetTranslated(-995800467);
			columnHeader4.Text = TranslationManager.TryGetTranslated(-1838833995);
			columnHeader4.Width = 201;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(688, 610);
			base.Controls.Add(listView);
			base.Controls.Add(label3);
			base.Controls.Add(gr_Filter);
			base.Controls.Add(label1);
			base.Controls.Add(toolStrip5);
			base.Controls.Add(statusStrip1);
			base.Name = "PPtSelectForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = TranslationManager.TryGetTranslated(-1006067386);
			toolStrip5.ResumeLayout(false);
			toolStrip5.PerformLayout();
			gr_Filter.ResumeLayout(false);
			gr_Filter.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
