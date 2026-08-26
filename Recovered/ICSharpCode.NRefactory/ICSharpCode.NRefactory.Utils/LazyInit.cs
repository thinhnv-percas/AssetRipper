using System.Threading;

namespace ICSharpCode.NRefactory.Utils
{
	public static class LazyInit
	{
		public static T VolatileRead<T>(ref T location) where T : class
		{
			T result = location;
			Thread.MemoryBarrier();
			return result;
		}

		public static T GetOrSet<T>(ref T target, T newValue) where T : class
		{
			return Interlocked.CompareExchange(ref target, newValue, null) ?? newValue;
		}
	}
}
