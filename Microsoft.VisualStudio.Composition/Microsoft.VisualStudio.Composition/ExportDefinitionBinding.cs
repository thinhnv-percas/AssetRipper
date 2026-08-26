using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class ExportDefinitionBinding : IEquatable<ExportDefinitionBinding>
{
	public ExportDefinition ExportDefinition { get; private set; }

	public ComposablePartDefinition PartDefinition { get; private set; }

	public MemberInfo ExportingMember => ExportingMemberRef.MemberInfo;

	public MemberRef ExportingMemberRef { get; private set; }

	public bool IsStaticExport => ExportingMember.IsStatic();

	public TypeRef ExportedValueTypeRef => TypeRef.Get(ExportedValueType, PartDefinition.TypeRef.Resolver);

	public Type ExportedValueType => ReflectionHelpers.GetExportedValueType(PartDefinition.Type, ExportingMember);

	public ExportDefinitionBinding(ExportDefinition exportDefinition, ComposablePartDefinition partDefinition, MemberRef exportingMemberRef)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		Requires.NotNull(partDefinition, "partDefinition");
		ExportDefinition = exportDefinition;
		PartDefinition = partDefinition;
		ExportingMemberRef = exportingMemberRef;
	}

	internal ExportDefinitionBinding CloseGenericExport(Type[] genericTypeArguments)
	{
		Requires.NotNull(genericTypeArguments, "genericTypeArguments");
		string value = string.Format(CultureInfo.InvariantCulture, (string)ExportDefinition.Metadata["ExportTypeIdentity"], genericTypeArguments.Select(ContractNameServices.GetTypeIdentity).ToArray());
		ImmutableDictionary<string, object> metadata = ImmutableDictionary.CreateRange(ExportDefinition.Metadata).SetItem("ExportTypeIdentity", value);
		return new ExportDefinitionBinding(new ExportDefinition(ExportDefinition.ContractName, metadata), PartDefinition, ExportingMemberRef);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as ExportDefinitionBinding);
	}

	public override int GetHashCode()
	{
		int num = PartDefinition.TypeRef.GetHashCode();
		if (!ExportingMemberRef.IsEmpty)
		{
			num += ExportingMemberRef.GetHashCode();
		}
		return num;
	}

	public bool Equals(ExportDefinitionBinding other)
	{
		if (PartDefinition.TypeRef.Equals(other.PartDefinition.TypeRef) && ExportDefinition.Equals(other.ExportDefinition))
		{
			return ExportingMemberRef.Equals(other.ExportingMemberRef);
		}
		return false;
	}
}
