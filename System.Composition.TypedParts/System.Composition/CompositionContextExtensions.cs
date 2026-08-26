using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Composition.Properties;
using System.Composition.TypedParts;
using System.Composition.TypedParts.ActivationFeatures;
using System.Composition.TypedParts.Util;
using System.Linq;
using System.Reflection;

namespace System.Composition;

public static class CompositionContextExtensions
{
	private static readonly DirectAttributeContext s_directAttributeContext = new DirectAttributeContext();

	public static void SatisfyImports(this CompositionContext compositionContext, object objectWithLooseImports)
	{
		compositionContext.SatisfyImportsInternal(objectWithLooseImports, s_directAttributeContext);
	}

	public static void SatisfyImports(this CompositionContext compositionContext, object objectWithLooseImports, AttributedModelProvider conventions)
	{
		compositionContext.SatisfyImportsInternal(objectWithLooseImports, conventions);
	}

	private static void SatisfyImportsInternal(this CompositionContext exportProvider, object objectWithLooseImports, AttributedModelProvider conventions)
	{
		if (exportProvider == null)
		{
			throw new ArgumentNullException("exportProvider");
		}
		if (objectWithLooseImports == null)
		{
			throw new ArgumentNullException("objectWithLooseImports");
		}
		if (conventions == null)
		{
			throw new ArgumentNullException("conventions");
		}
		Type type = objectWithLooseImports.GetType();
		foreach (PropertyInfo runtimeProperty in type.GetRuntimeProperties())
		{
			PropertyImportSite site = new PropertyImportSite(runtimeProperty);
			if (ContractHelpers.TryGetExplicitImportInfo(runtimeProperty.PropertyType, conventions.GetDeclaredAttributes(runtimeProperty.DeclaringType, runtimeProperty), site, out var importInfo))
			{
				if (exportProvider.TryGetExport(importInfo.Contract, out var export))
				{
					runtimeProperty.SetValue(objectWithLooseImports, export);
				}
				else if (!importInfo.AllowDefault)
				{
					throw new CompositionFailedException(string.Format(System.Composition.Properties.Resources.CompositionContextExtensions_MissingDependency, new object[2] { runtimeProperty.Name, objectWithLooseImports }));
				}
			}
		}
		IEnumerable<MethodInfo> enumerable = from m in objectWithLooseImports.GetType().GetRuntimeMethods()
			where m.CustomAttributes.Any((CustomAttributeData ca) => (object)ca.AttributeType == typeof(OnImportsSatisfiedAttribute))
			select m;
		foreach (MethodInfo item in enumerable)
		{
			item.Invoke(objectWithLooseImports, null);
		}
	}
}
