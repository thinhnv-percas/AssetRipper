using System;
using System.Text.RegularExpressions;

namespace Humanizer;

internal static class RegexOptionsUtil
{
	private static readonly RegexOptions _compiled;

	public static RegexOptions Compiled
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return _compiled;
		}
	}

	static RegexOptionsUtil()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		_compiled = (RegexOptions)(Enum.TryParse<RegexOptions>("Compiled", out RegexOptions result) ? ((int)result) : 0);
	}
}
