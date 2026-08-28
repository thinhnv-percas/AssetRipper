using @as;
using BrotliSharpLib;
using DevXForms.TreeList;
using DMP4;
using DSMCaps;
using DSMCaps.XCore;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Media.Media3D;
using Unity.CecilTools;
using Unreal;
using Wasm.Interpret;
using XnaGeometry;

namespace DevXForms
{
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020 : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
		{
			if (destType == typeof(InstanceDescriptor) || destType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(context, destType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo info, object value, Type destType)
		{
			if (destType == typeof(string))
			{
				TreeListColumn treeListColumn = (TreeListColumn)value;
				return $"{treeListColumn.Caption}, {treeListColumn.Fieldname}";
			}
			if (destType == typeof(InstanceDescriptor) && value is TreeListColumn)
			{
				TreeListColumn treeListColumn2 = (TreeListColumn)value;
				return new InstanceDescriptor(typeof(TreeListColumn).GetConstructor(new Type[2]
				{
					typeof(string),
					typeof(string)
				}), new object[2]
				{
					treeListColumn2.Fieldname,
					treeListColumn2.Caption
				}, isComplete: false);
			}
			return base.ConvertTo(context, info, value, destType);
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(TreeViewColumnCollection))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return "(Columns Collection)";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 : ControlDesigner
	{
		internal IComponentChangeService _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020;

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			try
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020 = (IComponentChangeService)GetService(typeof(IComponentChangeService));
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020 != null)
				{
					_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020.ComponentChanged += _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;
				}
				(Control as MultiSelectTreeView2)._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020 += _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020;
			}
			catch
			{
			}
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020(object _0020, MouseEventArgs _0020_000A)
		{
			RaiseComponentChanged(null, null, null);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		internal void _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A(object _0020, ComponentChangedEventArgs _0020_000A)
		{
			Control?.Invalidate();
		}

		protected override bool GetHitTest(System.Drawing.Point point)
		{
			try
			{
				MultiSelectTreeView2 multiSelectTreeView = Control as MultiSelectTreeView2;
				point = multiSelectTreeView.PointToClient(point);
				if (multiSelectTreeView.CalcHitNode(point) != null)
				{
					return true;
				}
				if ((multiSelectTreeView.CalcColumnHit(point).HitType & HitInfo.eHitType.kColumnHeader) > (HitInfo.eHitType)0)
				{
					return true;
				}
				if (multiSelectTreeView.HitTestScrollbar(point))
				{
					return true;
				}
				return base.GetHitTest(point);
			}
			catch
			{
				return false;
			}
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
		}
	}
	internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A
	{
		internal static Pen _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A = SystemPens.Control;

		public static Pen GridLinePen => _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A;
	}
	internal class _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A
	{
		public static System.Drawing.Rectangle Rect(RectangleF rf)
		{
			System.Drawing.Rectangle result = default(System.Drawing.Rectangle);
			result.X = (int)rf.X;
			result.Y = (int)rf.Y;
			result.Width = (int)rf.Width;
			result.Height = (int)rf.Height;
			return result;
		}

		public static RectangleF Rect(System.Drawing.Rectangle r)
		{
			RectangleF result = default(RectangleF);
			result.X = r.X;
			result.Y = r.Y;
			result.Width = r.Width;
			result.Height = r.Height;
			return result;
		}

		public static System.Drawing.Point Point(PointF pf)
		{
			return new System.Drawing.Point((int)pf.X, (int)pf.Y);
		}

		public static PointF Center(RectangleF r)
		{
			PointF location = r.Location;
			location.X += r.Width / 2f;
			location.Y += r.Height / 2f;
			return location;
		}

		public static void DrawFrame(Graphics dc, RectangleF r, float cornerRadius, Color color)
		{
			Pen pen = new Pen(color);
			if (cornerRadius <= 0f)
			{
				dc.DrawRectangle(pen, Rect(r));
				return;
			}
			cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Width) - 2.0);
			cornerRadius = (float)Math.Min(cornerRadius, Math.Floor(r.Height) - 2.0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(r.X, r.Y, cornerRadius, cornerRadius, 180f, 90f);
			graphicsPath.AddArc(r.Right - cornerRadius, r.Y, cornerRadius, cornerRadius, 270f, 90f);
			graphicsPath.AddArc(r.Right - cornerRadius, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 0f, 90f);
			graphicsPath.AddArc(r.X, r.Bottom - cornerRadius, cornerRadius, cornerRadius, 90f, 90f);
			graphicsPath.CloseAllFigures();
			dc.DrawPath(pen, graphicsPath);
		}

		public static void Draw2ColorBar(Graphics dc, RectangleF r, Orientation orientation, Color c1, Color c2)
		{
			RectangleF rect = r;
			float angle = 0f;
			if (orientation == Orientation.Vertical)
			{
				angle = 270f;
			}
			if (orientation == Orientation.Horizontal)
			{
				angle = 0f;
			}
			if (rect.Height > 0f && rect.Width > 0f)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, c1, c2, angle, isAngleScaleable: false);
				dc.FillRectangle(linearGradientBrush, rect);
				linearGradientBrush.Dispose();
			}
		}

		public static void Draw3ColorBar(Graphics dc, RectangleF r, Orientation orientation, Color c1, Color c2, Color c3)
		{
			RectangleF rect = r;
			RectangleF rect2 = r;
			float angle = 0f;
			if (orientation == Orientation.Vertical)
			{
				angle = 270f;
				rect.Height /= 2f;
				rect2.Height = r.Height - rect.Height;
				rect2.Y += rect.Height;
			}
			if (orientation == Orientation.Horizontal)
			{
				angle = 0f;
				rect.Width /= 2f;
				rect2.Width = r.Width - rect.Width;
				rect.X = rect2.Right;
			}
			if (rect.Height > 0f && rect.Width > 0f)
			{
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect2, c1, c2, angle, isAngleScaleable: false);
				LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(rect, c2, c3, angle, isAngleScaleable: false);
				dc.FillRectangle(linearGradientBrush2, rect);
				dc.FillRectangle(linearGradientBrush, rect2);
				linearGradientBrush2.Dispose();
				linearGradientBrush.Dispose();
			}
			if (orientation == Orientation.Vertical)
			{
				Pen pen = new Pen(c2, 1f);
				Pen pen2 = new Pen(c3, 1f);
				dc.DrawLine(pen2, rect.Left, rect.Top, rect.Right - 1f, rect.Top);
				dc.DrawLine(pen, rect2.Left, rect2.Top, rect2.Right - 1f, rect2.Top);
				pen.Dispose();
				pen2.Dispose();
			}
			if (orientation == Orientation.Horizontal)
			{
				Pen pen3 = new Pen(c1, 1f);
				Pen pen4 = new Pen(c2, 1f);
				Pen pen5 = new Pen(c3, 1f);
				dc.DrawLine(pen3, rect2.Left, rect2.Top, rect2.Left, rect2.Bottom - 1f);
				dc.DrawLine(pen4, rect2.Right, rect2.Top, rect2.Right, rect2.Bottom - 1f);
				dc.DrawLine(pen5, rect.Right, rect.Top, rect.Right, rect.Bottom - 1f);
				pen3.Dispose();
				pen4.Dispose();
				pen5.Dispose();
			}
		}

		public static System.Drawing.Rectangle AdjustRectangle(System.Drawing.Rectangle r, Padding padding)
		{
			r.X += padding.Left;
			r.Width -= padding.Left + padding.Right;
			r.Y += padding.Top;
			r.Height -= padding.Top + padding.Bottom;
			return r;
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020
	{
		public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

		[StructLayout(LayoutKind.Sequential)]
		public class POINT
		{
			public int x;

			public int y;
		}

		[StructLayout(LayoutKind.Sequential)]
		public class MouseHookStruct
		{
			public POINT pt;

			public int hwnd;

			public int wHitTestCode;

			public int dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		public class KeyboardHookStruct
		{
			public int vkCode;

			public int scanCode;

			public int flags;

			public int time;

			public int dwExtraInfo;
		}

		public const int HWND_TOP = 0;

		public const int HWND_BOTTOM = 1;

		public const int HWND_TOPMOST = -1;

		public const int HWND_NOTOPMOST = -2;

		public const int WM_KEYDOWN = 256;

		public const int WM_KEYUP = 257;

		public const int WM_CHAR = 258;

		public const int SWP_NOSIZE = 1;

		public const int SWP_NOMOVE = 2;

		public const int SWP_NOZORDER = 4;

		public const int SWP_NOREDRAW = 8;

		public const int SWP_NOACTIVATE = 16;

		public const int SWP_FRAMECHANGED = 32;

		public const int SWP_SHOWWINDOW = 64;

		public const int SWP_HIDEWINDOW = 128;

		public const int SWP_NOCOPYBITS = 256;

		public const int SWP_NOOWNERZORDER = 512;

		public const int SWP_NOSENDCHANGING = 1024;

		public const uint WS_OVERLAPPED = 12582912u;

		public const uint WS_CLIPSIBLINGS = 67108864u;

		public const uint WS_CLIPCHILDREN = 33554432u;

		public const uint WS_CAPTION = 12582912u;

		public const uint WS_BORDER = 8388608u;

		public const uint WS_DLGFRAME = 4194304u;

		public const uint WS_VSCROLL = 2097152u;

		public const uint WS_HSCROLL = 1048576u;

		public const uint WS_SYSMENU = 524288u;

		public const uint WS_THICKFRAME = 262144u;

		public const uint WS_MAXIMIZEBOX = 131072u;

		public const uint WS_MINIMIZEBOX = 65536u;

		public const uint WS_SIZEBOX = 262144u;

		public const uint WS_POPUP = 2147483648u;

		public const uint WS_CHILD = 1073741824u;

		public const uint WS_VISIBLE = 268435456u;

		public const uint WS_DISABLED = 134217728u;

		public const uint WS_EX_DLGMODALFRAME = 1u;

		public const uint WS_EX_NOPARENTNOTIFY = 4u;

		public const uint WS_EX_TOPMOST = 8u;

		public const uint WS_EX_ACCEPTFILES = 16u;

		public const uint WS_EX_TRANSPARENT = 32u;

		public const uint WS_EX_MDICHILD = 64u;

		public const uint WS_EX_TOOLWINDOW = 128u;

		public const uint WS_EX_WINDOWEDGE = 256u;

		public const uint WS_EX_CLIENTEDGE = 512u;

		public const uint WS_EX_CONTEXTHELP = 1024u;

		public const uint WS_EX_RIGHT = 4096u;

		public const uint WS_EX_LEFT = 0u;

		public const uint WS_EX_RTLREADING = 8192u;

		public const uint WS_EX_LTRREADING = 0u;

		public const uint WS_EX_LEFTSCROLLBAR = 16384u;

		public const uint WS_EX_RIGHTSCROLLBAR = 0u;

		public const uint WS_EX_CONTROLPARENT = 65536u;

		public const uint WS_EX_STATICEDGE = 131072u;

		public const uint WS_EX_APPWINDOW = 262144u;

		public const uint WS_EX_OVERLAPPEDWINDOW = 768u;

		public const int GWL_STYLE = -16;

		public const int GWL_EXSTYLE = -20;

		public const int WH_KEYBOARD = 2;

		public const int WH_MOUSE = 7;

		public const int WH_KEYBOARD_LL = 13;

		public const int WH_MOUSE_LL = 14;

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
		public static extern IntPtr GetWindowLong32(IntPtr _0020, int _0020_000A);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
		public static extern IntPtr SetWindowLongPtr32(IntPtr _0020, int _0020_000A, int _0020_0020);

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool SetWindowPos(IntPtr _0020, IntPtr _0020_000A, int _0020_0020, int _0020_000A_000A, int _0020_000A_0020, int _0020_0020_000A, int _0020_0020_0020);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern int SetWindowsHookEx(int _0020, HookProc _0020_000A, IntPtr _0020_0020, int _0020_000A_000A);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern bool UnhookWindowsHookEx(int _0020);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern int CallNextHookEx(int _0020, int _0020_000A, IntPtr _0020_0020, IntPtr _0020_000A_000A);
	}
	internal class _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020
	{
		public delegate System.Windows.Forms.TreeNode NodeCallback(System.Windows.Forms.TreeNode node, ref bool doContinue);

		internal TreeView m_tree;

		internal NodeCallback m_callback;

		public _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020(TreeView tree, NodeCallback cb)
		{
			m_tree = tree;
			m_callback = cb;
		}

		public System.Windows.Forms.TreeNode Execute()
		{
			bool doContinue = false;
			foreach (System.Windows.Forms.TreeNode node in m_tree.Nodes)
			{
				System.Windows.Forms.TreeNode result = ExecuteNode(node, ref doContinue);
				if (!doContinue)
				{
					return result;
				}
			}
			return null;
		}

		internal System.Windows.Forms.TreeNode ExecuteNode(System.Windows.Forms.TreeNode node, ref bool doContinue)
		{
			doContinue = true;
			System.Windows.Forms.TreeNode result = m_callback(node, ref doContinue);
			if (!doContinue)
			{
				return result;
			}
			foreach (System.Windows.Forms.TreeNode node2 in node.Nodes)
			{
				result = ExecuteNode(node2, ref doContinue);
				if (!doContinue)
				{
					return result;
				}
			}
			return null;
		}
	}
	internal class _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A : _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020
	{
		internal object _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020;

		public _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A(TreeView tree, object tag)
			: base(tree, null)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020 = tag;
			m_callback = this._0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;
		}

		internal System.Windows.Forms.TreeNode _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020(System.Windows.Forms.TreeNode _0020, ref bool _0020_000A)
		{
			if (_0020.Tag != null && _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020 != null && _0020.Tag.Equals(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020))
			{
				_0020_000A = false;
				return _0020;
			}
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020(double _0020)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020(Point3D _0020)
		{
			((_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020((string)null);
			CecilUtils.ElementTypeOfCollection(null);
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A)null)._0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020();
			((_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020)null)._0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A();
			return 1687241807;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020(object _0020)
		{
			return 376838775;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak escaped as unbound generic syntax, e.g. `!0`/`!!0`); see FINDINGS.md §5.
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A
	{
		// Dead decoy method removed (referenced an unresolved IL generic-parameter leak escaped as unbound generic syntax, e.g. `!0`/`!!0`); see FINDINGS.md §5.
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020(Il2CppTokenAdjustorThunkPair _0020, _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020 _0020_000A, string _0020_0020, bool _0020_000A_000A)
		{
			return "1482609421";
		}
	}
}
