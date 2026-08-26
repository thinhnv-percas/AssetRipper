using System;
using System.Collections;
using System.Windows.Forms;

public class ControlUpdate : IDisposable
{
	internal static Hashtable _0020_000A_000A_000A_000A_0020_0020_0020 = new Hashtable();

	internal static bool _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A = false;

	internal Control _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020;

	public static void Reset()
	{
		_0020_000A_000A_000A_000A_0020_0020_0020.Clear();
		Win32.LockWindowUpdate(null);
	}

	public static ControlUpdate Lock(Control control)
	{
		return new ControlUpdate(control);
	}

	internal ControlUpdate()
	{
	}

	internal ControlUpdate(Control control)
	{
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020 = control;
		if (control != null)
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A = true;
			if (_0020_000A_000A_000A_000A_0020_0020_0020.Contains(control))
			{
				_0020_000A_000A_000A_000A_0020_0020_0020[control] = (int)_0020_000A_000A_000A_000A_0020_0020_0020[control] + 1;
			}
			else
			{
				_0020_000A_000A_000A_000A_0020_0020_0020.Add(control, 1);
			}
			Win32.LockWindowUpdate(control);
		}
	}

	~ControlUpdate()
	{
		Dispose();
	}

	public void Dispose()
	{
		if (_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020 != null)
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A = false;
			if (_0020_000A_000A_000A_000A_0020_0020_0020.Contains(_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020))
			{
				int num = (int)_0020_000A_000A_000A_000A_0020_0020_0020[_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020] - 1;
				_0020_000A_000A_000A_000A_0020_0020_0020[_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020] = num;
				_0020_000A_000A_000A_000A_0020_0020_0020.Remove(_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020);
			}
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020 = null;
			Win32.LockWindowUpdate(null);
			GC.SuppressFinalize(this);
		}
	}
}
