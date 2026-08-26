using System;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class ExportFactory
{
	internal static bool IsExportFactoryType(this Type type)
	{
		if (!type.IsExportFactoryTypeV1())
		{
			return type.IsExportFactoryTypeV2();
		}
		return true;
	}

	internal static bool IsExportFactoryTypeV1(this Type type)
	{
		if (type != null && type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition().FullName.StartsWith("System.ComponentModel.Composition.ExportFactory"))
		{
			return true;
		}
		return false;
	}

	internal static bool IsExportFactoryTypeV2(this Type type)
	{
		if (type != null && type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition().FullName.StartsWith("System.Composition.ExportFactory"))
		{
			return true;
		}
		return false;
	}
}
