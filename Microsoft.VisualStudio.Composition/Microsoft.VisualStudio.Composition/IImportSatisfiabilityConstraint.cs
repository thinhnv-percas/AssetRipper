using System;

namespace Microsoft.VisualStudio.Composition;

public interface IImportSatisfiabilityConstraint : IEquatable<IImportSatisfiabilityConstraint>
{
	bool IsSatisfiedBy(ExportDefinition exportDefinition);
}
