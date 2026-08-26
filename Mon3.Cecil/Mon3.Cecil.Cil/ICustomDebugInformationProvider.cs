using Mon3.Collections.Generic;

namespace Mon3.Cecil.Cil;

public interface ICustomDebugInformationProvider : IMetadataTokenProvider
{
	bool HasCustomDebugInformations { get; }

	Collection<CustomDebugInformation> CustomDebugInformations { get; }
}
