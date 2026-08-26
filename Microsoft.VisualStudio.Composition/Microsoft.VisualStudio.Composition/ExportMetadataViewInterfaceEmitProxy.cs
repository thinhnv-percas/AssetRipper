using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class ExportMetadataViewInterfaceEmitProxy
{
	[PartNotDiscoverable]
	[PartMetadata("VsMEFDgmlCategories", new string[] { "VsMEFBuiltIn" })]
	[Export(typeof(IMetadataViewProvider))]
	[ExportMetadata("OrderPrecedence", 50)]
	private class MetadataViewProxyProvider : IMetadataViewProvider
	{
		public bool IsMetadataViewSupported(Type metadataType)
		{
			if (metadataType.GetTypeInfo().IsInterface)
			{
				return metadataType.GetTypeInfo().GetMembers().All(IsPropertyRelated);
			}
			return false;
		}

		public object CreateProxy(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultValues, Type metadataViewType)
		{
			return MetadataViewGenerator.GetMetadataViewFactory(metadataViewType)(metadata, defaultValues);
		}

		private static bool IsPropertyRelated(MemberInfo member)
		{
			PropertyInfo propertyInfo = member as PropertyInfo;
			if (propertyInfo != null)
			{
				if (propertyInfo.GetMethod != null)
				{
					return propertyInfo.SetMethod == null;
				}
				return false;
			}
			MethodInfo methodInfo = member as MethodInfo;
			if (methodInfo != null)
			{
				if (methodInfo.IsSpecialName)
				{
					return methodInfo.Name.StartsWith("get_");
				}
				return false;
			}
			return false;
		}
	}

	internal static readonly ComposablePartDefinition PartDefinition = Utilities.GetMetadataViewProviderPartDefinition(typeof(MetadataViewProxyProvider), 50, Resolver.DefaultInstance);
}
