using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WFTools3D
{
	public static class WFUtils
	{
		private delegate bool _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MonitorInfoEx
		{
			public int Size;

			public RectStruct Monitor;

			public RectStruct WorkArea;

			public uint Flags;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string DeviceName;

			public void Init()
			{
				Size = 104;
				DeviceName = string.Empty;
			}
		}

		public struct RectStruct
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		[CompilerGenerated]
		private sealed class _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020
		{
			public List<Screen> _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A;

			internal bool _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A(IntPtr _0020, IntPtr _0020_000A, ref Rect _0020_0020, IntPtr _0020_000A_000A)
			{
				MonitorInfoEx monitorInfoEx = default(MonitorInfoEx);
				monitorInfoEx.Size = Marshal.SizeOf((object)monitorInfoEx);
				if (GetMonitorInfo(_0020, ref monitorInfoEx))
				{
					Screen item = new Screen
					{
						ScreenArea = new Rect(monitorInfoEx.Monitor.Left, monitorInfoEx.Monitor.Top, monitorInfoEx.Monitor.Right - monitorInfoEx.Monitor.Left, monitorInfoEx.Monitor.Bottom - monitorInfoEx.Monitor.Top),
						WorkArea = new Rect(monitorInfoEx.WorkArea.Left, monitorInfoEx.WorkArea.Top, monitorInfoEx.WorkArea.Right - monitorInfoEx.WorkArea.Left, monitorInfoEx.WorkArea.Bottom - monitorInfoEx.WorkArea.Top),
						IsPrimary = ((monitorInfoEx.Flags & 1) == 1),
						Name = monitorInfoEx.DeviceName
					};
					_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A.Add(item);
				}
				return true;
			}
		}

		private const int _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 = 32;

		public static bool IsShiftDown()
		{
			if (!Keyboard.IsKeyDown(Key.LeftShift))
			{
				return Keyboard.IsKeyDown(Key.RightShift);
			}
			return true;
		}

		public static bool IsCtrlDown()
		{
			if (!Keyboard.IsKeyDown(Key.LeftCtrl))
			{
				return Keyboard.IsKeyDown(Key.RightCtrl);
			}
			return true;
		}

		public static bool IsAltDown()
		{
			if (!Keyboard.IsKeyDown(Key.LeftAlt) && !Keyboard.IsKeyDown(Key.RightAlt))
			{
				return Keyboard.IsKeyDown(Key.System);
			}
			return true;
		}

		public static Point GetResolution(Visual visual)
		{
			Point result = new Point(120.0, 120.0);
			PresentationSource presentationSource = PresentationSource.FromVisual(visual);
			if (presentationSource == null)
			{
				return result;
			}
			MatrixTransform matrixTransform = new MatrixTransform(presentationSource.CompositionTarget.TransformToDevice);
			Point point = new Point(0.0, 0.0);
			point = matrixTransform.Transform(point);
			Point point2 = new Point(96.0, 96.0);
			point2 = matrixTransform.Transform(point2);
			result.X = point2.X - point.X;
			result.Y = point2.Y - point.Y;
			return result;
		}

		[DllImport("user32.dll")]
		private static extern bool EnumDisplayMonitors(IntPtr _0020, IntPtr _0020_000A, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020 _0020_0020, IntPtr _0020_000A_000A);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern bool GetMonitorInfo(IntPtr _0020, ref MonitorInfoEx _0020_000A);

		public static List<Screen> GetAllScreens()
		{
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 = new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020();
			_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020._0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A = new List<Screen>();
			EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A, IntPtr.Zero);
			return _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020._0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A;
		}

		public static Screen GetScreenByName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return null;
			}
			foreach (Screen allScreen in GetAllScreens())
			{
				if (allScreen.Name == name)
				{
					return allScreen;
				}
			}
			return null;
		}

		public static Screen GetScreenByPixel(Point pt)
		{
			foreach (Screen allScreen in GetAllScreens())
			{
				if (allScreen.WorkArea.Contains(pt))
				{
					return allScreen;
				}
			}
			return null;
		}

		public static Screen GetScreenByPixel(double x, double y)
		{
			return GetScreenByPixel(new Point(x, y));
		}

		public static Screen GetPrimaryScreen()
		{
			foreach (Screen allScreen in GetAllScreens())
			{
				if (allScreen.IsPrimary)
				{
					return allScreen;
				}
			}
			return null;
		}
	}
}
