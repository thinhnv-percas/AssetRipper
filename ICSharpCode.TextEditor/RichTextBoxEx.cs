using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[ToolboxBitmap(typeof(RichTextBox))]
public class RichTextBoxEx : RichTextBox
{
	internal class EditWriter : StringWriter
	{
		private delegate void WriteHandle(string str);

		private delegate void VoidDelegate();

		internal string LogFileName;

		internal RichTextBoxEx RichBox;

		private WriteHandle WriteString;

		internal EditWriter()
		{
			WriteString = OnWriteString;
		}

		public override void WriteLine(string value)
		{
			WriteString(value + "\r\n");
		}

		public override void Write(string value)
		{
			WriteString(value);
		}

		private void OnWriteString(string str_text)
		{
			if (RichBox.Created && RichBox.InvokeRequired)
			{
				RichBox.Invoke((VoidDelegate)delegate
				{
					OnWriteStringSynk(str_text);
				});
			}
			else
			{
				OnWriteStringSynk(str_text);
			}
		}

		private void OnWriteStringSynk(string str_text)
		{
			try
			{
				if (string.IsNullOrEmpty(str_text))
				{
					return;
				}
				if (RichBox != null)
				{
					RichBox.SelectionStart = RichBox.TextLength;
					RichBox.SelectionLength = 0;
					RichBox.SetSelectionBoldOff();
					RichBox.SetSelectionItalicOff();
					if (RichBox.SelectionColor != Color.Black)
					{
						RichBox.SelectionColor = Color.Black;
					}
					string[] array = str_text.Split('<');
					if (array == null)
					{
						return;
					}
					for (int i = 0; i < array.Length; i++)
					{
						string text = array[i];
						if (!string.IsNullOrEmpty(text))
						{
							if (text.StartsWith("b>"))
							{
								RichBox.SetSelectionBoldOn();
								text = text.Substring(2);
							}
							else if (text.StartsWith("/b>"))
							{
								RichBox.SetSelectionBoldOff();
								text = text.Substring(3);
							}
							else if (text.StartsWith("i>"))
							{
								RichBox.SetSelectionItalicOn();
								text = text.Substring(2);
							}
							else if (text.StartsWith("/i>"))
							{
								RichBox.SetSelectionItalicOff();
								text = text.Substring(3);
							}
							else if (text.StartsWith("red>"))
							{
								RichBox.SelectionColor = Color.Red;
								text = text.Substring(4);
							}
							else if (text.StartsWith("/red>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(5);
							}
							else if (text.StartsWith("green>"))
							{
								RichBox.SelectionColor = Color.Green;
								text = text.Substring(6);
							}
							else if (text.StartsWith("/green>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(7);
							}
							else if (text.StartsWith("blue>"))
							{
								RichBox.SelectionColor = Color.Blue;
								text = text.Substring(5);
							}
							else if (text.StartsWith("/blue>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(6);
							}
							else if (text.StartsWith("gray>"))
							{
								RichBox.SelectionColor = Color.Gray;
								text = text.Substring(5);
							}
							else if (text.StartsWith("/gray>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(6);
							}
							else if (text.StartsWith("black>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(6);
							}
							else if (text.StartsWith("activate>"))
							{
								RichBox.SelectionColor = Color.Black;
								text = text.Substring(9);
							}
							else if (text.StartsWith("clear>"))
							{
								RichBox.Clear();
								text = text.Substring(6);
							}
							else if (text.StartsWith("/>"))
							{
								RichBox.SelectionColor = Color.Black;
								RichBox.SetSelectionBoldOff();
								RichBox.SetSelectionItalicOff();
								text = text.Substring(2);
							}
							else if (i > 0)
							{
								text = "<" + text;
							}
							RichBox.AppendText(text);
							text = null;
							array[i] = null;
						}
					}
				}
				if (string.IsNullOrEmpty(LogFileName))
				{
					return;
				}
				str_text = str_text.Replace("</>", "");
				str_text = str_text.Replace("<b>", "");
				str_text = str_text.Replace("</b>", "");
				str_text = str_text.Replace("<i>", "");
				str_text = str_text.Replace("</i>", "");
				str_text = str_text.Replace("<red>", "");
				str_text = str_text.Replace("<green>", "");
				str_text = str_text.Replace("<gray>", "");
				str_text = str_text.Replace("<blue>", "");
				str_text = str_text.Replace("<black>", "");
				str_text = str_text.Replace("<activate>", "");
				str_text = str_text.Replace("<clear>", "");
				try
				{
					StreamWriter streamWriter = new StreamWriter(LogFileName, append: true);
					streamWriter.Write(str_text);
					streamWriter.Close();
				}
				catch
				{
				}
			}
			catch
			{
			}
		}
	}

	private struct CHARFORMAT
	{
		internal int cbSize;

		internal uint dwMask;

		internal uint dwEffects;

		internal int yHeight;

		internal int yOffset;

		internal int crTextColor;

		internal byte bCharSet;

		internal byte bPitchAndFamily;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		internal char[] szFaceName;

		internal short wWeight;

		internal short sSpacing;

		internal int crBackColor;

		internal int LCID;

		internal uint dwReserved;

		internal short sStyle;

		internal short wKerning;

		internal byte bUnderlineType;

		internal byte bAnimation;

		internal byte bRevAuthor;
	}

	private EditWriter _Writer;

	private const int EM_SETCHARFORMAT = 1092;

	private const int CFM_BOLD = 1;

	private const int CFM_ITALIC = 2;

	private const int CFM_UNDERLINE = 4;

	private const int SCF_SELECTION = 1;

	internal EditWriter Writer
	{
		get
		{
			if (_Writer == null)
			{
				_Writer = new EditWriter();
				_Writer.RichBox = this;
			}
			return _Writer;
		}
	}

	[DllImport("User32.dll", CharSet = CharSet.Auto)]
	private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref CHARFORMAT lp);

	private void SetCharFormatMessage(ref CHARFORMAT fmt)
	{
		SendMessage(new HandleRef(this, base.Handle), 1092, 1, ref fmt);
	}

	internal void SetSelectionBoldOn()
	{
		ApplyStyle(1u, on: true);
	}

	internal void SetSelectionBoldOff()
	{
		ApplyStyle(1u, on: false);
	}

	internal void SetSelectionItalicOn()
	{
		ApplyStyle(2u, on: true);
	}

	internal void SetSelectionItalicOff()
	{
		ApplyStyle(2u, on: false);
	}

	internal void SetSelectionUnderlineOn()
	{
		ApplyStyle(4u, on: true);
	}

	internal void SetSelectionUnderlineOff()
	{
		ApplyStyle(4u, on: false);
	}

	internal void ApplyStyle(uint style, bool on)
	{
		CHARFORMAT fmt = default(CHARFORMAT);
		fmt.cbSize = Marshal.SizeOf((object)fmt);
		fmt.dwMask = style;
		if (on)
		{
			fmt.dwEffects = style;
		}
		SetCharFormatMessage(ref fmt);
	}
}
