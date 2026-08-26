using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Microsoft.VisualStudio.Composition;

internal static class LazyServices
{
	private static readonly MethodInfo CreateStronglyTypedLazyOfTMValue = typeof(LazyServices).GetTypeInfo().GetMethod("CreateStronglyTypedLazyOfTM", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo CreateStronglyTypedLazyOfTValue = typeof(LazyServices).GetTypeInfo().GetMethod("CreateStronglyTypedLazyOfT", BindingFlags.Static | BindingFlags.NonPublic);

	internal static readonly Type DefaultMetadataViewType = typeof(IDictionary<string, object>);

	internal static readonly Type DefaultExportedValueType = typeof(object);

	internal static bool IsAnyLazyType(this Type type)
	{
		if (type.GetTypeInfo().IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition == typeof(Lazy<>) || genericTypeDefinition == typeof(Lazy<, >))
			{
				return true;
			}
		}
		return false;
	}

	internal static Lazy<T> FromValue<T>(T value) where T : class
	{
		return new Lazy<T>(DelegateServices.FromValue(value), LazyThreadSafetyMode.PublicationOnly);
	}

	internal static Func<Func<object>, object, object> CreateStronglyTypedLazyFactory(Type exportType, Type metadataViewType)
	{
		MethodInfo methodInfo = ((!(metadataViewType != null)) ? CreateStronglyTypedLazyOfTValue.MakeGenericMethod(exportType ?? DefaultExportedValueType) : CreateStronglyTypedLazyOfTMValue.MakeGenericMethod(exportType ?? DefaultExportedValueType, metadataViewType));
		return (Func<Func<object>, object, object>)methodInfo.CreateDelegate(typeof(Func<Func<object>, object, object>));
	}

	internal static Func<T> AsFunc<T>(this Lazy<T> lazy)
	{
		Requires.NotNull(lazy, "lazy");
		return () => lazy.Value;
	}

	private static T GetLazyValue<T>(this Lazy<T> lazy)
	{
		return lazy.Value;
	}

	private static Lazy<T> CreateStronglyTypedLazyOfT<T>(Func<object> funcOfObject, object metadata)
	{
		Requires.NotNull(funcOfObject, "funcOfObject");
		return new Lazy<T>(funcOfObject.As<T>());
	}

	private static Lazy<T, TMetadata> CreateStronglyTypedLazyOfTM<T, TMetadata>(Func<object> funcOfObject, object metadata)
	{
		Requires.NotNull(funcOfObject, "funcOfObject");
		Requires.NotNullAllowStructs(metadata, "metadata");
		return new Lazy<T, TMetadata>(funcOfObject.As<T>(), (TMetadata)metadata);
	}
}
