using System;

namespace HelixToolkit.Wpf;

[Serializable]
public class HelixToolkitException : Exception
{
	public HelixToolkitException(string formatString, params object[] args)
		: base(string.Format(formatString, args))
	{
	}
}
