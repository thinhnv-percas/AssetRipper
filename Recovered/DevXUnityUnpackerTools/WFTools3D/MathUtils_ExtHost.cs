using System;
using System.Windows;

namespace WFTools3D
{
	public static class MathUtils_ExtHost
	{
	public static bool IsValid(this Point pt)
	{
		return MathUtils.IsValid(pt);
	}
	}
}
