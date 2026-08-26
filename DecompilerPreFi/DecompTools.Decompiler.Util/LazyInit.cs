using System.Threading;

namespace DecompTools.Decompiler.Util;

public static class LazyInit
{
	public static T VolatileRead<T>(ref T location) where T : class
	{
		return Volatile.Read(ref location);
	}

	public static T GetOrSet<T>(ref T target, T newValue) where T : class
	{
		T val = Interlocked.CompareExchange(ref target, newValue, null);
		return val ?? newValue;
	}
}
