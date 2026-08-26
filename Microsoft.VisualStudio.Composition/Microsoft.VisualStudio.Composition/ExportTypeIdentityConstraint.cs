using System;
using System.Collections.Immutable;
using System.IO;

namespace Microsoft.VisualStudio.Composition;

public class ExportTypeIdentityConstraint : IImportSatisfiabilityConstraint, IEquatable<IImportSatisfiabilityConstraint>, IDescriptiveToString
{
	public string TypeIdentityName { get; private set; }

	public ExportTypeIdentityConstraint(Type typeIdentity)
	{
		Requires.NotNull(typeIdentity, "typeIdentity");
		TypeIdentityName = ContractNameServices.GetTypeIdentity(typeIdentity);
	}

	public ExportTypeIdentityConstraint(string typeIdentityName)
	{
		Requires.NotNullOrEmpty(typeIdentityName, "typeIdentityName");
		TypeIdentityName = typeIdentityName;
	}

	public static ImmutableDictionary<string, object> GetExportMetadata(Type type)
	{
		Requires.NotNull(type, "type");
		return GetExportMetadata(ContractNameServices.GetTypeIdentity(type));
	}

	public static ImmutableDictionary<string, object> GetExportMetadata(string typeIdentity)
	{
		Requires.NotNullOrEmpty(typeIdentity, "typeIdentity");
		return ImmutableDictionary<string, object>.Empty.Add("ExportTypeIdentity", typeIdentity);
	}

	public bool IsSatisfiedBy(ExportDefinition exportDefinition)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		if (exportDefinition.Metadata.TryGetValue<string>("ExportTypeIdentity", out var value))
		{
			return TypeIdentityName == value;
		}
		return false;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter.Get(writer).WriteLine("TypeIdentityName: {0}", TypeIdentityName);
	}

	public bool Equals(IImportSatisfiabilityConstraint obj)
	{
		if (!(obj is ExportTypeIdentityConstraint exportTypeIdentityConstraint))
		{
			return false;
		}
		return TypeIdentityName == exportTypeIdentityConstraint.TypeIdentityName;
	}
}
