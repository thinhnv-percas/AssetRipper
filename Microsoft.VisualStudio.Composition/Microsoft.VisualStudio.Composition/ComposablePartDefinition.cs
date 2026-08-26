using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

[DebuggerDisplay("{Type.Name}")]
public class ComposablePartDefinition : IEquatable<ComposablePartDefinition>
{
	public Type Type => TypeRef.Resolve();

	public TypeRef TypeRef { get; private set; }

	public string Id => Type.FullName.Replace('`', '_').Replace('.', '_').Replace('+', '_');

	public string SharingBoundary { get; private set; }

	public bool IsSharingBoundaryInferred { get; private set; }

	public CreationPolicy CreationPolicy { get; private set; }

	public bool IsShared => SharingBoundary != null;

	public IReadOnlyDictionary<string, object> Metadata { get; private set; }

	public MethodInfo OnImportsSatisfied => OnImportsSatisfiedRef.MethodBase as MethodInfo;

	public MethodRef OnImportsSatisfiedRef { get; private set; }

	public IReadOnlyCollection<ExportDefinition> ExportedTypes { get; private set; }

	public IReadOnlyDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>> ExportingMembers { get; private set; }

	public IEnumerable<KeyValuePair<MemberRef, ExportDefinition>> ExportDefinitions
	{
		get
		{
			foreach (ExportDefinition exportedType in ExportedTypes)
			{
				yield return new KeyValuePair<MemberRef, ExportDefinition>(default(MemberRef), exportedType);
			}
			foreach (KeyValuePair<MemberRef, IReadOnlyCollection<ExportDefinition>> member in ExportingMembers)
			{
				foreach (ExportDefinition item in member.Value)
				{
					yield return new KeyValuePair<MemberRef, ExportDefinition>(member.Key, item);
				}
			}
		}
	}

	public IEnumerable<AssemblyName> ExtraInputAssemblies { get; }

	public ImmutableHashSet<ImportDefinitionBinding> ImportingMembers { get; private set; }

	public IReadOnlyList<ImportDefinitionBinding> ImportingConstructorImports { get; private set; }

	public bool IsInstantiable => ImportingConstructorImports != null;

	public ConstructorRef ImportingConstructorRef { get; private set; }

	public ConstructorInfo ImportingConstructorInfo => ImportingConstructorRef.ConstructorInfo;

	public IEnumerable<ImportDefinitionBinding> Imports
	{
		get
		{
			IEnumerable<ImportDefinitionBinding> enumerable = ImportingMembers;
			if (ImportingConstructorImports != null)
			{
				enumerable = enumerable.Concat(ImportingConstructorImports);
			}
			return enumerable;
		}
	}

	public ComposablePartDefinition(TypeRef partType, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<ExportDefinition> exportedTypes, IReadOnlyDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMembers, IEnumerable<ImportDefinitionBinding> importingMembers, string sharingBoundary, MethodRef onImportsSatisfied, ConstructorRef importingConstructorRef, IReadOnlyList<ImportDefinitionBinding> importingConstructorImports, CreationPolicy partCreationPolicy, bool isSharingBoundaryInferred = false)
	{
		Requires.NotNull(partType, "partType");
		Requires.NotNull(metadata, "metadata");
		Requires.NotNull(exportedTypes, "exportedTypes");
		Requires.NotNull(exportingMembers, "exportingMembers");
		Requires.NotNull(importingMembers, "importingMembers");
		TypeRef = partType;
		Metadata = metadata;
		ExportedTypes = exportedTypes;
		ExportingMembers = exportingMembers;
		ImportingMembers = ImmutableHashSet.CreateRange(importingMembers);
		SharingBoundary = sharingBoundary;
		OnImportsSatisfiedRef = onImportsSatisfied;
		ImportingConstructorRef = importingConstructorRef;
		ImportingConstructorImports = importingConstructorImports;
		CreationPolicy = partCreationPolicy;
		IsSharingBoundaryInferred = isSharingBoundaryInferred;
		ExtraInputAssemblies = Enumerable.Empty<AssemblyName>();
	}

	public ComposablePartDefinition(TypeRef partType, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<ExportDefinition> exportedTypes, IReadOnlyDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMembers, IEnumerable<ImportDefinitionBinding> importingMembers, string sharingBoundary, MethodRef onImportsSatisfied, ConstructorRef importingConstructorRef, IReadOnlyList<ImportDefinitionBinding> importingConstructorImports, CreationPolicy partCreationPolicy, IEnumerable<AssemblyName> extraInputAssemblies, bool isSharingBoundaryInferred = false)
		: this(partType, metadata, exportedTypes, exportingMembers, importingMembers, sharingBoundary, onImportsSatisfied, importingConstructorRef, importingConstructorImports, partCreationPolicy, isSharingBoundaryInferred)
	{
		Requires.NotNull(extraInputAssemblies, "extraInputAssemblies");
		ExtraInputAssemblies = extraInputAssemblies;
	}

	public override int GetHashCode()
	{
		return TypeRef.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ComposablePartDefinition);
	}

	public bool Equals(ComposablePartDefinition other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (TypeRef.Equals(other.TypeRef) && ByValueEquality.Metadata.Equals(Metadata, other.Metadata) && SharingBoundary == other.SharingBoundary && IsSharingBoundaryInferred == other.IsSharingBoundaryInferred && CreationPolicy == other.CreationPolicy && OnImportsSatisfiedRef.Equals(other.OnImportsSatisfiedRef) && ByValueEquality.EquivalentIgnoreOrder<ExportDefinition>().Equals(ExportedTypes, other.ExportedTypes) && ByValueEquality.Dictionary<MemberRef, IReadOnlyCollection<ExportDefinition>>(ByValueEquality.EquivalentIgnoreOrder<ExportDefinition>()).Equals(ExportingMembers, other.ExportingMembers) && ImportingConstructorRef.Equals(other.ImportingConstructorRef) && ImportingMembers.SetEquals(other.ImportingMembers))
		{
			if (ImportingConstructorImports != null || other.ImportingConstructorImports != null)
			{
				if (ImportingConstructorImports != null && other.ImportingConstructorImports != null)
				{
					return ImportingConstructorImports.SequenceEqual(other.ImportingConstructorImports);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		indentingTextWriter.WriteLine("Type: {0}", Type.FullName);
		if (Metadata.Count > 0)
		{
			indentingTextWriter.WriteLine("Part metadata:");
			using (indentingTextWriter.Indent())
			{
				foreach (KeyValuePair<string, object> item in Metadata)
				{
					indentingTextWriter.WriteLine("{0} = {1}", item.Key, item.Value);
				}
			}
		}
		indentingTextWriter.WriteLine("SharingBoundary: {0}", SharingBoundary.SpecifyIfNull());
		indentingTextWriter.WriteLine("IsSharingBoundaryInferred: {0}", IsSharingBoundaryInferred);
		indentingTextWriter.WriteLine("CreationPolicy: {0}", CreationPolicy);
		indentingTextWriter.WriteLine("OnImportsSatisfied: {0}", OnImportsSatisfied.SpecifyIfNull());
		indentingTextWriter.WriteLine("ExportedTypes:");
		using (indentingTextWriter.Indent())
		{
			foreach (ExportDefinition item2 in ExportedTypes.OrderBy((ExportDefinition et) => et.ContractName))
			{
				indentingTextWriter.WriteLine("ExportDefinition");
				using (indentingTextWriter.Indent())
				{
					item2.ToString(indentingTextWriter);
				}
			}
		}
		indentingTextWriter.WriteLine("ExportingMembers:");
		using (indentingTextWriter.Indent())
		{
			foreach (KeyValuePair<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMember in ExportingMembers)
			{
				indentingTextWriter.WriteLine(exportingMember.Key.MemberInfo.Name);
				using (indentingTextWriter.Indent())
				{
					foreach (ExportDefinition item3 in exportingMember.Value)
					{
						item3.ToString(indentingTextWriter);
					}
				}
			}
		}
		indentingTextWriter.WriteLine("ImportingMembers:");
		using (indentingTextWriter.Indent())
		{
			foreach (ImportDefinitionBinding importingMember in ImportingMembers)
			{
				importingMember.ToString(indentingTextWriter);
			}
		}
		if (ImportingConstructorImports == null)
		{
			indentingTextWriter.WriteLine("ImportingConstructor: <null>");
			return;
		}
		indentingTextWriter.WriteLine("ImportingConstructor:");
		using (indentingTextWriter.Indent())
		{
			foreach (ImportDefinitionBinding importingConstructorImport in ImportingConstructorImports)
			{
				importingConstructorImport.ToString(indentingTextWriter);
			}
		}
	}

	internal void GetInputAssemblies(ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		foreach (AssemblyName extraInputAssembly in ExtraInputAssemblies)
		{
			assemblies.Add(extraInputAssembly);
		}
		TypeRef.GetInputAssemblies(assemblies);
		ReflectionHelpers.GetInputAssembliesFromMetadata(assemblies, Metadata);
		foreach (ExportDefinition exportedType in ExportedTypes)
		{
			exportedType.GetInputAssemblies(assemblies);
		}
		foreach (KeyValuePair<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMember in ExportingMembers)
		{
			exportingMember.Key.GetInputAssemblies(assemblies);
			foreach (ExportDefinition item in exportingMember.Value)
			{
				item.GetInputAssemblies(assemblies);
			}
		}
		foreach (ImportDefinitionBinding import in Imports)
		{
			import.GetInputAssemblies(assemblies);
		}
		OnImportsSatisfiedRef.GetInputAssemblies(assemblies);
		ImportingConstructorRef.GetInputAssemblies(assemblies);
	}
}
