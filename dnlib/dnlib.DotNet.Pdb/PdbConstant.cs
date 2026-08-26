using System.Collections.Generic;

namespace dnlib.DotNet.Pdb;

public sealed class PdbConstant : IHasCustomDebugInformation
{
	private string name;

	private TypeSig type;

	private object value;

	private readonly IList<PdbCustomDebugInfo> customDebugInfos = new List<PdbCustomDebugInfo>();

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public TypeSig Type
	{
		get
		{
			return type;
		}
		set
		{
			type = value;
		}
	}

	public object Value
	{
		get
		{
			return value;
		}
		set
		{
			this.value = value;
		}
	}

	public int HasCustomDebugInformationTag => 25;

	public bool HasCustomDebugInfos => CustomDebugInfos.Count > 0;

	public IList<PdbCustomDebugInfo> CustomDebugInfos => customDebugInfos;

	public PdbConstant()
	{
	}

	public PdbConstant(string name, TypeSig type, object value)
	{
		this.name = name;
		this.type = type;
		this.value = value;
	}

	public override string ToString()
	{
		TypeSig typeSig = Type;
		return ((typeSig == null) ? "" : typeSig.ToString()) + " " + Name + " = " + ((Value == null) ? "null" : (Value.ToString() + " (" + Value.GetType().FullName + ")"));
	}
}
