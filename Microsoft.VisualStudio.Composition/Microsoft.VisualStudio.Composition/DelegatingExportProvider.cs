using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public abstract class DelegatingExportProvider : ExportProvider
{
	private readonly ExportProvider inner;

	protected DelegatingExportProvider(ExportProvider inner)
		: base(inner.Resolver)
	{
		Requires.NotNull(inner, "inner");
		this.inner = inner;
	}

	public override IEnumerable<Export> GetExports(ImportDefinition importDefinition)
	{
		return inner.GetExports(importDefinition);
	}

	internal override IMetadataViewProvider GetMetadataViewProvider(Type metadataView)
	{
		return inner.GetMetadataViewProvider(metadataView);
	}

	protected sealed override IEnumerable<ExportInfo> GetExportsCore(ImportDefinition importDefinition)
	{
		throw new NotImplementedException();
	}

	protected internal override PartLifecycleTracker CreatePartLifecycleTracker(TypeRef partType, IReadOnlyDictionary<string, object> importMetadata)
	{
		return inner.CreatePartLifecycleTracker(partType, importMetadata);
	}
}
