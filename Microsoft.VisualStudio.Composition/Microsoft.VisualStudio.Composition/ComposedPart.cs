using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

[DebuggerDisplay("{Definition.Type.Name}")]
public class ComposedPart
{
	public ComposablePartDefinition Definition { get; private set; }

	public IReadOnlyDictionary<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> SatisfyingExports { get; private set; }

	public IImmutableSet<string> RequiredSharingBoundaries { get; private set; }

	internal Resolver Resolver => Definition.TypeRef.Resolver;

	public ComposedPart(ComposablePartDefinition definition, IReadOnlyDictionary<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> satisfyingExports, IImmutableSet<string> requiredSharingBoundaries)
	{
		Requires.NotNull(definition, "definition");
		Requires.NotNull(satisfyingExports, "satisfyingExports");
		Requires.NotNull(requiredSharingBoundaries, "requiredSharingBoundaries");
		Definition = definition;
		SatisfyingExports = satisfyingExports;
		RequiredSharingBoundaries = requiredSharingBoundaries;
	}

	public IEnumerable<KeyValuePair<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>>> GetImportingConstructorImports()
	{
		if (Definition.ImportingConstructorRef.IsEmpty)
		{
			yield break;
		}
		foreach (ImportDefinitionBinding import in Definition.ImportingConstructorImports)
		{
			ImportDefinitionBinding key = SatisfyingExports.Keys.Single((ImportDefinitionBinding k) => k.ImportDefinition == import.ImportDefinition);
			yield return new KeyValuePair<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>>(key, SatisfyingExports[key]);
		}
	}

	public IEnumerable<ComposedPartDiagnostic> Validate(IReadOnlyDictionary<Type, ExportDefinitionBinding> metadataViews)
	{
		Requires.NotNull(metadataViews, "metadataViews");
		if (Definition.ExportDefinitions.Any((KeyValuePair<MemberRef, ExportDefinition> ed) => CompositionConfiguration.ExportDefinitionPracticallyEqual.Default.Equals(ExportProvider.ExportProviderExportDefinition, ed.Value)) && !Definition.Equals(ExportProvider.ExportProviderPartDefinition))
		{
			yield return new ComposedPartDiagnostic(this, Strings.ExportOfExportProviderNotAllowed, Definition.Type.FullName);
		}
		List<ImportDefinitionBinding> list = Definition.Imports.Where((ImportDefinitionBinding import) => import.ImportingSiteElementType.GetTypeInfo().ContainsGenericParameters).ToList();
		foreach (ImportDefinitionBinding item in list)
		{
			yield return new ComposedPartDiagnostic(this, Strings.ImportsThatUseGenericTypeParametersNotSupported, GetDiagnosticLocation(item));
		}
		foreach (KeyValuePair<ImportDefinitionBinding, IReadOnlyList<ExportDefinitionBinding>> pair in SatisfyingExports)
		{
			switch (pair.Key.ImportDefinition.Cardinality)
			{
			case ImportCardinality.ExactlyOne:
				if (pair.Value.Count != 1)
				{
					yield return new ComposedPartDiagnostic(this, Strings.ExpectedExactlyOneExportButFound, GetDiagnosticLocation(pair.Key), pair.Key.ImportingSiteElementType, pair.Value.Count, GetExportsList(pair.Value));
				}
				break;
			case ImportCardinality.OneOrZero:
				if (pair.Value.Count > 1)
				{
					yield return new ComposedPartDiagnostic(this, Strings.ExpectedOneOrZeroExportsButFound, GetDiagnosticLocation(pair.Key), pair.Key.ImportingSiteElementType, pair.Value.Count, GetExportsList(pair.Value));
				}
				break;
			}
			foreach (ExportDefinitionBinding export in pair.Value)
			{
				if (ReflectionHelpers.IsAssignableTo(pair.Key, export) == ReflectionHelpers.Assignability.DefinitelyNot)
				{
					yield return new ComposedPartDiagnostic(this, Strings.IsNotAssignableFromExportedMEFValue, GetDiagnosticLocation(pair.Key), GetDiagnosticLocation(export));
				}
				if (!pair.Key.IsLazy && !export.IsStaticExport && !export.PartDefinition.IsInstantiable && export.ExportDefinition != ExportProvider.ExportProviderExportDefinition)
				{
					yield return new ComposedPartDiagnostic(this, Strings.CannotImportBecauseExportingPartCannotBeInstantiated, GetDiagnosticLocation(pair.Key), GetDiagnosticLocation(export));
				}
			}
			if (pair.Key.ImportDefinition.Cardinality == ImportCardinality.ZeroOrMore && !pair.Key.ImportingParameterRef.IsEmpty && !IsAllowedImportManyParameterType(pair.Key.ImportingParameterRef.Resolve().ParameterType))
			{
				yield return new ComposedPartDiagnostic(this, Strings.ImportingCtorHasUnsupportedParameterTypeForImportMany);
			}
			Type metadataType = pair.Key.MetadataType;
			if (metadataType != null && !metadataViews.ContainsKey(metadataType))
			{
				yield return new ComposedPartDiagnostic(this, Strings.MetadataTypeNotSupported, GetDiagnosticLocation(pair.Key), metadataType.FullName);
			}
		}
	}

	private static string GetDiagnosticLocation(ImportDefinitionBinding import)
	{
		Requires.NotNull(import, "import");
		return string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[2]
		{
			import.ComposablePartType.FullName,
			import.ImportingMemberRef.IsEmpty ? ("ctor(" + import.ImportingParameter.Name + ")") : import.ImportingMember.Name
		});
	}

	private static string GetDiagnosticLocation(ExportDefinitionBinding export)
	{
		Requires.NotNull(export, "export");
		if (!export.ExportingMemberRef.IsEmpty)
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[2]
			{
				export.PartDefinition.Type.FullName,
				export.ExportingMember.Name
			});
		}
		return export.PartDefinition.Type.FullName;
	}

	private static string GetExportsList(IEnumerable<ExportDefinitionBinding> exports)
	{
		Requires.NotNull(exports, "exports");
		if (!exports.Any())
		{
			return string.Empty;
		}
		return Environment.NewLine + string.Join(Environment.NewLine, exports.Select((ExportDefinitionBinding export) => "    " + GetDiagnosticLocation(export)));
	}

	private static bool IsAllowedImportManyParameterType(Type importSiteType)
	{
		Requires.NotNull(importSiteType, "importSiteType");
		if (importSiteType.IsArray)
		{
			return true;
		}
		if (importSiteType.GetTypeInfo().IsGenericType && importSiteType.GetTypeInfo().GetGenericTypeDefinition().IsEquivalentTo(typeof(IEnumerable<>)))
		{
			return true;
		}
		return false;
	}
}
