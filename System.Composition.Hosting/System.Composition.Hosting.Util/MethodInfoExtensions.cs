using System.Reflection;

namespace System.Composition.Hosting.Util;

internal static class MethodInfoExtensions
{
	public static T CreateStaticDelegate<T>(this MethodInfo methodInfo)
	{
		return (T)(object)methodInfo.CreateDelegate(typeof(T));
	}
}
