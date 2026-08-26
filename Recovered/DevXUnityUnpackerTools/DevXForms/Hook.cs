using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DevXForms
{
	public class Hook
	{
		public delegate void KeyboardDelegate(KeyEventArgs e);

		public KeyboardDelegate OnKeyDown;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A;

		internal _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.HookProc _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020;

		public void SetHook(bool enable)
		{
			if (enable && _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A == 0)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A;
				Module m = Assembly.GetExecutingAssembly().GetModules()[0];
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.SetWindowsHookEx(13, _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020, Marshal.GetHINSTANCE(m), 0);
				if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A == 0)
				{
					MessageBox.Show("SetHook Failed. Please make sure the 'Visual Studio Host Process' on the debug setting page is disabled");
				}
			}
			else if (!enable && _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A != 0)
			{
				_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.UnhookWindowsHookEx(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A = 0;
			}
		}

		internal int _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A(int _0020, IntPtr _0020_000A, IntPtr _0020_0020)
		{
			if (_0020 < 0)
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.CallNextHookEx(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A, _0020, _0020_000A, _0020_0020);
			}
			_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.KeyboardHookStruct keyboardHookStruct = (_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.KeyboardHookStruct)Marshal.PtrToStructure(_0020_0020, typeof(_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.KeyboardHookStruct));
			if (OnKeyDown != null && _0020_000A.ToInt32() == 256)
			{
				Keys keys = (Keys)keyboardHookStruct.vkCode;
				if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					keys |= Keys.Shift;
				}
				if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
				{
					keys |= Keys.Control;
				}
				KeyEventArgs keyEventArgs = new KeyEventArgs(keys);
				keyEventArgs.Handled = false;
				OnKeyDown(keyEventArgs);
				if (keyEventArgs.Handled)
				{
					return 1;
				}
			}
			int result = 0;
			if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A != 0)
			{
				result = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020.CallNextHookEx(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A, _0020, _0020_000A, _0020_0020);
			}
			return result;
		}
	}
}
