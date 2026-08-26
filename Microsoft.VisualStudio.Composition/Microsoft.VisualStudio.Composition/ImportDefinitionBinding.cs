using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class ImportDefinitionBinding : IEquatable<ImportDefinitionBinding>
{
	private bool? isLazy;

	private Type importingSiteTypeWithoutCollection;

	private Type importingSiteElementType;

	private TypeRef importingSiteTypeRef;

	public ImportDefinition ImportDefinition { get; private set; }

	public MemberInfo ImportingMember => ImportingMemberRef.MemberInfo;

	public MemberRef ImportingMemberRef { get; private set; }

	public ParameterInfo ImportingParameter => ImportingParameterRef.Resolve();

	public ParameterRef ImportingParameterRef { get; private set; }

	public Type ComposablePartType => ComposablePartTypeRef.Resolve();

	public TypeRef ComposablePartTypeRef { get; private set; }

	public Type ImportingSiteType => ImportingSiteTypeRef.Resolve();

	public TypeRef ImportingSiteTypeRef
	{
		get
		{
			if (importingSiteTypeRef == null)
			{
				if (!ImportingMemberRef.IsEmpty)
				{
					importingSiteTypeRef = TypeRef.Get(ReflectionHelpers.GetMemberType(ImportingMemberRef.MemberInfo), ImportingMemberRef.Resolver);
				}
				else
				{
					if (ImportingParameterRef.IsEmpty)
					{
						throw Assumes.NotReachable();
					}
					importingSiteTypeRef = TypeRef.Get(ImportingParameterRef.Resolve().ParameterType, ImportingParameterRef.Resolver);
				}
			}
			return importingSiteTypeRef;
		}
	}

	public Type ImportingSiteTypeWithoutCollection
	{
		get
		{
			if (importingSiteTypeWithoutCollection == null)
			{
				importingSiteTypeWithoutCollection = ((ImportDefinition.Cardinality == ImportCardinality.ZeroOrMore) ? PartDiscovery.GetElementTypeFromMany(ImportingSiteType) : ImportingSiteType);
			}
			return importingSiteTypeWithoutCollection;
		}
	}

	public Type ImportingSiteElementType
	{
		get
		{
			if (importingSiteElementType == null)
			{
				importingSiteElementType = PartDiscovery.GetTypeIdentityFromImportingType(ImportingSiteType, ImportDefinition.Cardinality == ImportCardinality.ZeroOrMore);
			}
			return importingSiteElementType;
		}
	}

	public bool IsLazy
	{
		get
		{
			if (!isLazy.HasValue)
			{
				isLazy = ImportingSiteTypeWithoutCollection.IsAnyLazyType();
			}
			return isLazy.Value;
		}
	}

	public Type MetadataType
	{
		get
		{
			if (IsLazy || IsExportFactory)
			{
				Type[] genericTypeArguments = ImportingSiteTypeWithoutCollection.GetTypeInfo().GenericTypeArguments;
				if (genericTypeArguments.Length == 2)
				{
					return genericTypeArguments[1];
				}
			}
			return null;
		}
	}

	public bool IsExportFactory => ImportingSiteTypeWithoutCollection.IsExportFactoryType();

	public Type ExportFactoryType
	{
		get
		{
			if (!IsExportFactory)
			{
				return null;
			}
			return ImportingSiteTypeWithoutCollection;
		}
	}

	public ImportDefinitionBinding(ImportDefinition importDefinition, TypeRef composablePartType, MemberRef importingMember)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		Requires.NotNull(composablePartType, "composablePartType");
		ImportDefinition = importDefinition;
		ComposablePartTypeRef = composablePartType;
		ImportingMemberRef = importingMember;
	}

	public ImportDefinitionBinding(ImportDefinition importDefinition, TypeRef composablePartType, ParameterRef importingConstructorParameter)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		Requires.NotNull(composablePartType, "composablePartType");
		ImportDefinition = importDefinition;
		ComposablePartTypeRef = composablePartType;
		ImportingParameterRef = importingConstructorParameter;
	}

	public override int GetHashCode()
	{
		return ImportDefinition.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ImportDefinitionBinding);
	}

	public bool Equals(ImportDefinitionBinding other)
	{
		if (other == null)
		{
			return false;
		}
		if (ImportDefinition.Equals(other.ImportDefinition) && EqualityComparer<TypeRef>.Default.Equals(ComposablePartTypeRef, other.ComposablePartTypeRef) && EqualityComparer<MemberRef>.Default.Equals(ImportingMemberRef, other.ImportingMemberRef))
		{
			return EqualityComparer<ParameterRef>.Default.Equals(ImportingParameterRef, other.ImportingParameterRef);
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		indentingTextWriter.WriteLine("ImportDefinition:");
		using (indentingTextWriter.Indent())
		{
			ImportDefinition.ToString(writer);
		}
		indentingTextWriter.WriteLine("ComposablePartType: {0}", ComposablePartType.FullName);
		indentingTextWriter.WriteLine("ImportingMember: {0}", ImportingMember);
		indentingTextWriter.WriteLine("ParameterInfo: {0}", ImportingParameter);
		indentingTextWriter.WriteLine("ImportingSiteType: {0}", ImportingSiteType);
	}

	internal void GetInputAssemblies(ISet<AssemblyName> assemblies)
	{
		Requires.NotNull(assemblies, "assemblies");
		ImportDefinition.GetInputAssemblies(assemblies);
		ComposablePartTypeRef.GetInputAssemblies(assemblies);
		ImportingMemberRef.GetInputAssemblies(assemblies);
		ImportingParameterRef.GetInputAssemblies(assemblies);
		ImportingSiteTypeRef.GetInputAssemblies(assemblies);
		ComposablePartTypeRef.GetInputAssemblies(assemblies);
	}
}
