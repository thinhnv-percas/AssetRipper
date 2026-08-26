using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.DebugInfo;

public interface IDebugInfoProvider
{
	string Description { get; }

	IList<SequencePoint> GetSequencePoints(MethodDefinitionHandle method);

	IList<Variable> GetVariables(MethodDefinitionHandle method);

	bool TryGetName(MethodDefinitionHandle method, int index, out string name);
}
