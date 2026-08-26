using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.Metadata;

public class CodeMappingInfo
{
	private Dictionary<MethodDefinitionHandle, List<MethodDefinitionHandle>> parts;

	private Dictionary<MethodDefinitionHandle, MethodDefinitionHandle> parents;

	public PEFile Module { get; }

	public TypeDefinitionHandle TypeDefinition { get; }

	public CodeMappingInfo(PEFile module, TypeDefinitionHandle type)
	{
		Module = module;
		TypeDefinition = type;
		parts = new Dictionary<MethodDefinitionHandle, List<MethodDefinitionHandle>>();
		parents = new Dictionary<MethodDefinitionHandle, MethodDefinitionHandle>();
	}

	public IEnumerable<MethodDefinitionHandle> GetMethodParts(MethodDefinitionHandle method)
	{
		if (parts.TryGetValue(method, out var value))
		{
			return value;
		}
		return new MethodDefinitionHandle[1] { method };
	}

	public MethodDefinitionHandle GetParentMethod(MethodDefinitionHandle method)
	{
		if (parents.TryGetValue(method, out var value))
		{
			return value;
		}
		return method;
	}

	public void AddMapping(MethodDefinitionHandle parent, MethodDefinitionHandle part)
	{
		if (!parents.ContainsKey(part))
		{
			parents.Add(part, parent);
			if (!parts.TryGetValue(parent, out var value))
			{
				value = new List<MethodDefinitionHandle>();
				parts.Add(parent, value);
			}
			value.Add(part);
		}
	}
}
