using Mon2.Collections.Generic;

namespace Mon2.Cecil.Cil;

public interface IVariableDefinitionProvider
{
	bool HasVariables { get; }

	Collection<VariableDefinition> Variables { get; }
}
