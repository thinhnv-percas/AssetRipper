using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace Microsoft.VisualStudio.Composition;

public class PartCreationPolicyConstraint : IImportSatisfiabilityConstraint, IEquatable<IImportSatisfiabilityConstraint>, IDescriptiveToString
{
	public static readonly PartCreationPolicyConstraint SharedPartRequired = new PartCreationPolicyConstraint(CreationPolicy.Shared);

	public static readonly PartCreationPolicyConstraint NonSharedPartRequired = new PartCreationPolicyConstraint(CreationPolicy.NonShared);

	public CreationPolicy RequiredCreationPolicy { get; private set; }

	private PartCreationPolicyConstraint(CreationPolicy creationPolicy)
	{
		RequiredCreationPolicy = creationPolicy;
	}

	public static ImmutableDictionary<string, object> GetExportMetadata(CreationPolicy partCreationPolicy)
	{
		ImmutableDictionary<string, object> immutableDictionary = ImmutableDictionary.Create<string, object>();
		if (partCreationPolicy != CreationPolicy.Any)
		{
			immutableDictionary = immutableDictionary.Add("System.ComponentModel.Composition.CreationPolicy", partCreationPolicy);
		}
		return immutableDictionary;
	}

	public static PartCreationPolicyConstraint GetRequiredCreationPolicyConstraint(CreationPolicy requiredCreationPolicy)
	{
		return requiredCreationPolicy switch
		{
			CreationPolicy.Shared => SharedPartRequired, 
			CreationPolicy.NonShared => NonSharedPartRequired, 
			_ => null, 
		};
	}

	public static ImmutableHashSet<IImportSatisfiabilityConstraint> GetRequiredCreationPolicyConstraints(CreationPolicy requiredCreationPolicy)
	{
		ImmutableHashSet<IImportSatisfiabilityConstraint> immutableHashSet = ImmutableHashSet.Create<IImportSatisfiabilityConstraint>();
		PartCreationPolicyConstraint requiredCreationPolicyConstraint = GetRequiredCreationPolicyConstraint(requiredCreationPolicy);
		if (requiredCreationPolicyConstraint != null)
		{
			immutableHashSet = immutableHashSet.Add(requiredCreationPolicyConstraint);
		}
		return immutableHashSet;
	}

	public static bool IsNonSharedInstanceRequired(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		return importDefinition.ExportConstraints.Contains(NonSharedPartRequired);
	}

	public bool IsSatisfiedBy(ExportDefinition exportDefinition)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		if (exportDefinition.Metadata.TryGetValue("System.ComponentModel.Composition.CreationPolicy", out var value))
		{
			CreationPolicy creationPolicy = (CreationPolicy)value;
			if (creationPolicy != CreationPolicy.Any)
			{
				return creationPolicy == RequiredCreationPolicy;
			}
			return true;
		}
		return true;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter.Get(writer).WriteLine("RequiredCreationPolicy: {0}", RequiredCreationPolicy);
	}

	public bool Equals(IImportSatisfiabilityConstraint obj)
	{
		if (!(obj is PartCreationPolicyConstraint partCreationPolicyConstraint))
		{
			return false;
		}
		return RequiredCreationPolicy == partCreationPolicyConstraint.RequiredCreationPolicy;
	}
}
