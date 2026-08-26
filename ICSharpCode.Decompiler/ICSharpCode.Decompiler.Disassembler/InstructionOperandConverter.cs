using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.Disassembler;

internal sealed class InstructionOperandConverter
{
	private readonly Dictionary<object, object> dict;

	private readonly List<SourceLocal> sourceLocals;

	public InstructionOperandConverter()
	{
		dict = new Dictionary<object, object>();
		sourceLocals = new List<SourceLocal>();
	}

	public object Convert(object obj)
	{
		if (obj != null && dict.TryGetValue(obj, out var value))
		{
			return value;
		}
		return obj;
	}

	public void Clear()
	{
		dict.Clear();
		sourceLocals.Clear();
	}

	public SourceLocal[] GetSourceLocals()
	{
		return sourceLocals.ToArray();
	}

	public void Add(MethodDef method)
	{
		CilBody body = method.Body;
		if (body == null)
		{
			return;
		}
		foreach (Local variable in body.Variables)
		{
			SourceLocal sourceLocal = new SourceLocal(variable, CreateLocalName(variable), variable.Type, SourceVariableFlags.None);
			sourceLocals.Add(sourceLocal);
			dict.Add(variable, sourceLocal);
		}
	}

	private static string CreateLocalName(Local local)
	{
		string name = local.Name;
		if (!string.IsNullOrEmpty(name))
		{
			return name;
		}
		return "V_" + local.Index;
	}
}
