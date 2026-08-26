using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class FieldToVariableMap
{
	public int Version;

	private readonly Dictionary<FieldDef, ILVariable> paramDict;

	private readonly DefaultDictionary<FieldDef, ILVariable> localDict;

	public FieldToVariableMap()
	{
		paramDict = new Dictionary<FieldDef, ILVariable>();
		localDict = new DefaultDictionary<FieldDef, ILVariable>((FieldDef f) => new ILVariable(string.IsNullOrEmpty(f.Name) ? ("_f_" + f.Rid.ToString("X")) : f.Name.String)
		{
			Type = f.FieldType,
			HoistedField = f
		});
	}

	public Dictionary<FieldDef, ILVariable> GetParameters()
	{
		return paramDict;
	}

	public bool TryGetParameter(FieldDef field, out ILVariable parameter)
	{
		return paramDict.TryGetValue(field, out parameter);
	}

	public void SetParameter(FieldDef field, ILVariable parameter)
	{
		paramDict[field] = parameter;
	}

	public bool TryGetLocal(FieldDef field, out ILVariable local)
	{
		return localDict.TryGetValue(field, out local);
	}

	public ILVariable GetOrCreateLocal(FieldDef field)
	{
		return localDict[field];
	}
}
