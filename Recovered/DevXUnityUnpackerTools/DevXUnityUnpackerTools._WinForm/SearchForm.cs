using @as;
using DevXUnityUnpackerTools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DevXUnityUnpackerTools._WinForm
{
	public class SearchForm : Form
	{
		internal static SearchForm Instance = new SearchForm();

		private static bool SearchBreak = false;

		internal ImageResData Reference_to_ppt;

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

		private TextBox ed_text;

		private Label label2;

		private RadioButton rb_AsText;

		private RadioButton rb_AsHex;

		private ListView listView;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ToolStripSeparator toolStripSeparator3;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel lb_status;

		private ToolStripProgressBar progressBar;

		private Label label3;

		private TextBox ed_Name;

		private Label label4;

		private Label label5;

		private TextBox ed_ID;

		private Label label6;

		private ComboBox ed_Class;

		private CheckBox ch_SearchInScrips;

		private TextBox ed_Referece;

		private Label label7;

		internal static SearchForm ShowWin(ImageResData ppt_reference = null)
		{
			Instance.Reference_to_ppt = ppt_reference;
			Instance.ed_Referece.Text = (ppt_reference?.ToString() ?? string.Empty);
			Instance.Show();
			Instance.Activate();
			if (Instance.Reference_to_ppt != null)
			{
				Instance.toolStripButton_Find_Click(null, null);
			}
			return Instance;
		}

		public SearchForm()
		{
			InitializeComponent();
			progressBar.Visible = false;
			listView.SmallImageList = MainForm.instance._0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020;
			ed_Class.Items.Add("");
			List<string> list = new List<string>();
			foreach (object value in Enum.GetValues(typeof(ClassIDEnum)))
			{
				list.Add(value.ToString());
			}
			list.Sort();
			foreach (string item in list)
			{
				ed_Class.Items.Add(item.ToString());
			}
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			e.Cancel = true;
			Hide();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void toolStripButton_Clear_Click(object sender, EventArgs e)
		{
			listView.Items.Clear();
			ed_ID.Text = "";
			ed_Name.Text = "";
			ed_Class.Text = "";
			ed_text.Text = "";
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
			f_ClassName = ed_Class.Text;
			f_ID = FormatUtils._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(ed_ID.Text, 0L);
			f_ContentText_buff.Clear();
			f_ContentText = ed_text.Text;
			searchInScripts = ch_SearchInScrips.Checked;
			if (!string.IsNullOrWhiteSpace(ed_text.Text))
			{
				try
				{
					if (rb_AsText.Checked)
					{
						f_ContentText_buff.Add(Encoding.ASCII.GetBytes(ed_text.Text));
						f_ContentText_buff.Add(Encoding.Unicode.GetBytes(ed_text.Text));
						f_ContentText_buff.Add(Encoding.UTF8.GetBytes(ed_text.Text));
					}
					if (rb_AsHex.Checked)
					{
						f_ContentText_buff.Add(FormatUtils.formatToArr(ed_text.Text));
					}
				}
				catch (Exception ex)
				{
					ConsoleManager.WriteEx45(ex);
					MessageBox.Show(ex.Message);
					return;
				}
			}
			listView.Items.Clear();
			SearchBreak = false;
			toolStripButton_Find.Enabled = false;
			progressBar.Visible = true;
			lb_status.Text = TranslationManager.TryGetTranslated(127543718);
			ManyCodeCls._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020(delegate
			{
				SunSearchAll();
			});
		}

		private void AddItem(ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A item, int offset)
		{
			MainForm.instance.AddAction(delegate
			{
				try
				{
					string text = item._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020.ToString();
					if (item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A != null)
					{
						text = item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020?.ToString();
					}
					if (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A is FileInfo)
					{
						text = (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as FileInfo).FullName;
					}
					ListViewItem value = new ListViewItem(new string[4]
					{
						text,
						item._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020,
						item._0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020,
						(offset == -1) ? "" : (offset.ToString() + " (0x" + offset.ToString("X8") + ")")
					})
					{
						Tag = item,
						ImageKey = MaybeAlertManager._0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(item)
					};
					listView.Items.Add(value);
				}
				catch (Exception _0020)
				{
					ConsoleManager.WriteEx45(_0020);
				}
			});
		}

		private void SunSearchAll()
		{
			try
			{
				foreach (ManyCodeCls item in MainForm.instance._0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020)
				{
					if (item._0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020.Count != 0)
					{
						if (SearchBreak)
						{
							break;
						}
						try
						{
							SunSearch(item._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A);
						}
						catch (Exception ex)
						{
							ConsoleManager.LogExeption("Update tree: " + item._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 + "\n" + ex);
						}
					}
				}
			}
			finally
			{
				Thread.Sleep(700);
				MainForm.instance.AddAction(delegate
				{
					toolStripButton_Find.Enabled = true;
					progressBar.Visible = false;
					lb_status.Text = "Search end, find count: " + listView.Items.Count;
				});
			}
		}

		private void SunSearch(IEnumerable<ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A> items)
		{
			foreach (ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A item in items)
			{
				try
				{
					if (SearchBreak)
					{
						return;
					}
					long num;
					if (!ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A(item, null) && (f_ID == 0L || item._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020 == f_ID) && (string.IsNullOrWhiteSpace(f_Name) || (item._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 != null && item._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020.IndexOf(f_Name, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) || (item._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020 != null && item._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020.ToString().IndexOf(f_Name, 0, StringComparison.InvariantCultureIgnoreCase) > 0)) && (string.IsNullOrWhiteSpace(f_ClassName) || (item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A?._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020 != null && item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020.IndexOf(f_ClassName, 0, StringComparison.InvariantCultureIgnoreCase) >= 0) || (item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A != null && item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020.ToString() == f_ClassName)) && (!(Reference_to_ppt != null) || Reference_to_ppt._0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A || (item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A != null && item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A(Reference_to_ppt))))
					{
						num = -1L;
						if (searchInScripts && !string.IsNullOrEmpty(f_ContentText))
						{
							_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020 _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020 = item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020;
							if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020 != null)
							{
								string text = _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020._0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020();
								if (!string.IsNullOrEmpty(text))
								{
									num = text.IndexOf(f_ContentText, StringComparison.InvariantCultureIgnoreCase);
									if (num >= 0)
									{
										goto IL_0394;
									}
								}
							}
						}
						if (f_ContentText_buff == null || f_ContentText_buff.Count <= 0)
						{
							goto IL_0394;
						}
						bool flag = false;
						FileInfo fileInfo;
						if ((fileInfo = (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as FileInfo)) != null)
						{
							using (Stream stream = FileManager.MakeStream(fileInfo.FullName))
							{
								foreach (byte[] item2 in f_ContentText_buff)
								{
									stream.Position = 0L;
									num = FileManager._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020(item2, stream, 0L);
									stream.Close();
									if (num >= 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
						_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020;
						if ((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 = (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020)) != null)
						{
							try
							{
								using (Stream stream2 = FileManager.MakeStream(_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020._0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020))
								{
									foreach (byte[] item3 in f_ContentText_buff)
									{
										stream2.Position = 0L;
										num = FileManager._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020(item3, stream2, 0L);
										stream2.Close();
										if (num >= 0)
										{
											flag = true;
											break;
										}
									}
								}
							}
							catch
							{
							}
						}
						if (item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A != null)
						{
							foreach (byte[] item4 in f_ContentText_buff)
							{
								num = FileManager._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020(item4, item._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A()._0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, 0L);
								if (num >= 0)
								{
									flag = true;
									break;
								}
							}
						}
						IContentInfo contentInfo;
						if ((contentInfo = (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as IContentInfo)) != null)
						{
							string contentInfo2 = contentInfo.ContentInfo;
							if (!string.IsNullOrEmpty(contentInfo2))
							{
								num = contentInfo2.IndexOf(f_ContentText, StringComparison.InvariantCultureIgnoreCase);
								if (num >= 0)
								{
									goto IL_0394;
								}
							}
						}
						IContentTextForView contentTextForView;
						if ((contentTextForView = (item._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A as IContentTextForView)) != null)
						{
							string contentTextForView2 = contentTextForView.ContentTextForView;
							if (!string.IsNullOrEmpty(contentTextForView2))
							{
								num = contentTextForView2.IndexOf(f_ContentText, StringComparison.InvariantCultureIgnoreCase);
								if (num >= 0)
								{
									goto IL_0394;
								}
							}
						}
						if (flag)
						{
							goto IL_0394;
						}
					}
					goto end_IL_0013;
					IL_0394:
					AddItem(item, (int)num);
					end_IL_0013:;
				}
				catch (Exception _0020)
				{
					ConsoleManager.WriteEx45(_0020);
				}
			}
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			if (listView.SelectedItems.Count != 0)
			{
				ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A _0020 = listView.SelectedItems[0].Tag as ManyCodeCls._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A;
				MainForm.instance._0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A(_0020);
			}
		}

		private void ed_Name_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				toolStripButton_Find_Click(null, null);
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
			ed_Referece = new System.Windows.Forms.TextBox();
			label7 = new System.Windows.Forms.Label();
			ch_SearchInScrips = new System.Windows.Forms.CheckBox();
			ed_Class = new System.Windows.Forms.ComboBox();
			ed_ID = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			ed_Name = new System.Windows.Forms.TextBox();
			label4 = new System.Windows.Forms.Label();
			rb_AsHex = new System.Windows.Forms.RadioButton();
			rb_AsText = new System.Windows.Forms.RadioButton();
			ed_text = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			listView = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			progressBar = new System.Windows.Forms.ToolStripProgressBar();
			lb_status = new System.Windows.Forms.ToolStripStatusLabel();
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
			toolStrip5.Size = new System.Drawing.Size(786, 23);
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
			gr_Filter.Controls.Add(ed_Referece);
			gr_Filter.Controls.Add(label7);
			gr_Filter.Controls.Add(ch_SearchInScrips);
			gr_Filter.Controls.Add(ed_Class);
			gr_Filter.Controls.Add(ed_ID);
			gr_Filter.Controls.Add(label6);
			gr_Filter.Controls.Add(label5);
			gr_Filter.Controls.Add(ed_Name);
			gr_Filter.Controls.Add(label4);
			gr_Filter.Controls.Add(rb_AsHex);
			gr_Filter.Controls.Add(rb_AsText);
			gr_Filter.Controls.Add(ed_text);
			gr_Filter.Controls.Add(label2);
			gr_Filter.Dock = System.Windows.Forms.DockStyle.Top;
			gr_Filter.Location = new System.Drawing.Point(0, 25);
			gr_Filter.Name = "gr_Filter";
			gr_Filter.Size = new System.Drawing.Size(786, 229);
			gr_Filter.TabIndex = 15;
			gr_Filter.TabStop = false;
			gr_Filter.Text = TranslationManager.TryGetTranslated(1557881769);
			gr_Filter.Enter += new System.EventHandler(Filter_Enter);
			ed_Referece.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			ed_Referece.Location = new System.Drawing.Point(125, 17);
			ed_Referece.Name = "ed_Referece";
			ed_Referece.ReadOnly = true;
			ed_Referece.Size = new System.Drawing.Size(649, 20);
			ed_Referece.TabIndex = 111;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(10, 20);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(100, 13);
			label7.TabIndex = 13;
			label7.Text = TranslationManager.TryGetTranslated(-637833541);
			ch_SearchInScrips.AutoSize = true;
			ch_SearchInScrips.Checked = true;
			ch_SearchInScrips.CheckState = System.Windows.Forms.CheckState.Checked;
			ch_SearchInScrips.Location = new System.Drawing.Point(125, 201);
			ch_SearchInScrips.Name = "ch_SearchInScrips";
			ch_SearchInScrips.Size = new System.Drawing.Size(233, 17);
			ch_SearchInScrips.TabIndex = 7;
			ch_SearchInScrips.Text = TranslationManager.TryGetTranslated(38590372);
			ch_SearchInScrips.UseVisualStyleBackColor = true;
			ed_Class.FormattingEnabled = true;
			ed_Class.Location = new System.Drawing.Point(125, 94);
			ed_Class.Name = "ed_Class";
			ed_Class.Size = new System.Drawing.Size(228, 21);
			ed_Class.TabIndex = 4;
			ed_Class.KeyDown += new System.Windows.Forms.KeyEventHandler(ed_Name_KeyDown);
			ed_ID.Location = new System.Drawing.Point(125, 69);
			ed_ID.Name = "ed_ID";
			ed_ID.Size = new System.Drawing.Size(228, 20);
			ed_ID.TabIndex = 3;
			ed_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(ed_Name_KeyDown);
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(12, 72);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(18, 13);
			label6.TabIndex = 10;
			label6.Text = TranslationManager.TryGetTranslated(-838420505);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(12, 98);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(89, 13);
			label5.TabIndex = 8;
			label5.Text = TranslationManager.TryGetTranslated(-995800467);
			ed_Name.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			ed_Name.Location = new System.Drawing.Point(125, 43);
			ed_Name.Name = "ed_Name";
			ed_Name.Size = new System.Drawing.Size(649, 20);
			ed_Name.TabIndex = 1;
			ed_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(ed_Name_KeyDown);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(12, 46);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(35, 13);
			label4.TabIndex = 6;
			label4.Text = TranslationManager.TryGetTranslated(62725275);
			rb_AsHex.AutoSize = true;
			rb_AsHex.Location = new System.Drawing.Point(305, 178);
			rb_AsHex.Name = "rb_AsHex";
			rb_AsHex.Size = new System.Drawing.Size(98, 17);
			rb_AsHex.TabIndex = 6;
			rb_AsHex.TabStop = true;
			rb_AsHex.Text = TranslationManager.TryGetTranslated(-2056892258);
			rb_AsHex.UseVisualStyleBackColor = true;
			rb_AsText.AutoSize = true;
			rb_AsText.Checked = true;
			rb_AsText.Location = new System.Drawing.Point(125, 178);
			rb_AsText.Name = "rb_AsText";
			rb_AsText.Size = new System.Drawing.Size(93, 17);
			rb_AsText.TabIndex = 6;
			rb_AsText.TabStop = true;
			rb_AsText.Text = TranslationManager.TryGetTranslated(2091918058);
			rb_AsText.UseVisualStyleBackColor = true;
			ed_text.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			ed_text.Location = new System.Drawing.Point(125, 121);
			ed_text.Multiline = true;
			ed_text.Name = "ed_text";
			ed_text.Size = new System.Drawing.Size(649, 51);
			ed_text.TabIndex = 5;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(12, 124);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(74, 13);
			label2.TabIndex = 0;
			label2.Text = TranslationManager.TryGetTranslated(-67792176);
			label3.Dock = System.Windows.Forms.DockStyle.Top;
			label3.Location = new System.Drawing.Point(0, 254);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(786, 23);
			label3.TabIndex = 6;
			label3.Text = TranslationManager.TryGetTranslated(1736520267);
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			label1.Dock = System.Windows.Forms.DockStyle.Top;
			label1.Location = new System.Drawing.Point(0, 23);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(786, 2);
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
			listView.HideSelection = false;
			listView.LabelEdit = true;
			listView.Location = new System.Drawing.Point(0, 277);
			listView.Name = "listView";
			listView.Size = new System.Drawing.Size(786, 353);
			listView.TabIndex = 17;
			listView.UseCompatibleStateImageBehavior = false;
			listView.View = System.Windows.Forms.View.Details;
			listView.DoubleClick += new System.EventHandler(listView_DoubleClick);
			columnHeader1.Text = TranslationManager.TryGetTranslated(-838420505);
			columnHeader1.Width = 132;
			columnHeader2.Text = TranslationManager.TryGetTranslated(62725275);
			columnHeader2.Width = 279;
			columnHeader3.Text = TranslationManager.TryGetTranslated(-1051447098);
			columnHeader3.Width = 126;
			columnHeader4.Text = TranslationManager.TryGetTranslated(1758080696);
			columnHeader4.Width = 171;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				progressBar,
				lb_status
			});
			statusStrip1.Location = new System.Drawing.Point(0, 630);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(786, 22);
			statusStrip1.TabIndex = 18;
			statusStrip1.Text = TranslationManager.TryGetTranslated(-1054648736);
			progressBar.Name = "progressBar";
			progressBar.Size = new System.Drawing.Size(100, 16);
			progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			lb_status.Name = "lb_status";
			lb_status.Size = new System.Drawing.Size(39, 17);
			lb_status.Text = TranslationManager.TryGetTranslated(-1971147459);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(786, 652);
			base.Controls.Add(listView);
			base.Controls.Add(label3);
			base.Controls.Add(gr_Filter);
			base.Controls.Add(label1);
			base.Controls.Add(toolStrip5);
			base.Controls.Add(statusStrip1);
			base.Name = "SearchForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = TranslationManager.TryGetTranslated(-1312754532);
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
