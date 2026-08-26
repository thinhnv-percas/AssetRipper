using System;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class DelegateServices
{
	private static readonly MethodInfo CastAsFuncMethodInfo = new Func<Func<object>, Delegate>(As<object>).GetMethodInfo().GetGenericMethodDefinition();

	internal static Func<T> FromValue<T>(T value) where T : class
	{
		return value.AsFunc();
	}

	internal static Func<T> As<T>(this Func<object> valueFactory)
	{
		return () => (T)valueFactory();
	}

	internal static Func<object> As(this Func<object> func, Type typeArg)
	{
		using Rental<object[]> rental = ArrayRental<object>.Get(1);
		rental.Value[0] = func;
		return (Func<object>)CastAsFuncMethodInfo.MakeGenericMethod(typeArg).Invoke(null, rental.Value);
	}

	private static Func<T> AsFunc<T>(this T value) where T : class
	{
		return () => value;
	}

	private static T Return<T>(this T value)
	{
		return value;
	}

	private static T AsHelper<T>(this Func<object> value)
	{
		return (T)value();
	}
}
