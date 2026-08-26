using System;
using System.Threading;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class ILVariable
{
	[Flags]
	private enum Flags : byte
	{
		GeneratedByDecompiler = 1,
		Renamed = 2,
		Declared = 4
	}

	public string Name;

	private Flags flags;

	public TypeSig Type;

	public Local OriginalVariable;

	public Parameter OriginalParameter;

	public FieldDef HoistedField;

	private object sourceParamOrLocal;

	public bool GeneratedByDecompiler
	{
		get
		{
			return (flags & Flags.GeneratedByDecompiler) != 0;
		}
		set
		{
			if (value)
			{
				flags |= Flags.GeneratedByDecompiler;
			}
			else
			{
				flags &= ~Flags.GeneratedByDecompiler;
			}
		}
	}

	public bool Renamed
	{
		get
		{
			return (flags & Flags.Renamed) != 0;
		}
		set
		{
			if (value)
			{
				flags |= Flags.Renamed;
			}
			else
			{
				flags &= ~Flags.Renamed;
			}
		}
	}

	public bool Declared
	{
		get
		{
			return (flags & Flags.Declared) != 0;
		}
		set
		{
			if (value)
			{
				flags |= Flags.Declared;
			}
			else
			{
				flags &= ~Flags.Declared;
			}
		}
	}

	public bool IsPinned
	{
		get
		{
			if (OriginalVariable != null)
			{
				return OriginalVariable.Type is PinnedSig;
			}
			return false;
		}
	}

	public bool IsParameter => OriginalParameter != null;

	public ILVariable(string name)
	{
		Name = name;
	}

	public TypeSig GetVariableType()
	{
		return Type ?? OriginalVariable?.Type ?? OriginalParameter?.Type ?? new SentinelSig();
	}

	public SourceLocal GetSourceLocal()
	{
		if (sourceParamOrLocal == null)
		{
			Interlocked.CompareExchange(ref sourceParamOrLocal, (HoistedField != null) ? new SourceLocal(OriginalVariable, Name, HoistedField, GetSourceVariableFlags()) : new SourceLocal(OriginalVariable, Name, GetVariableType(), GetSourceVariableFlags()), null);
		}
		return (SourceLocal)sourceParamOrLocal;
	}

	private SourceVariableFlags GetSourceVariableFlags()
	{
		return SourceVariableFlags.None;
	}

	public SourceParameter GetSourceParameter()
	{
		if (sourceParamOrLocal == null)
		{
			Interlocked.CompareExchange(ref sourceParamOrLocal, (HoistedField != null) ? new SourceParameter(OriginalParameter, Name, HoistedField, GetSourceVariableFlags()) : new SourceParameter(OriginalParameter, Name, GetVariableType(), GetSourceVariableFlags()), null);
		}
		return (SourceParameter)sourceParamOrLocal;
	}

	public object GetTextReferenceObject()
	{
		if (OriginalParameter != null)
		{
			return OriginalParameter;
		}
		return GetSourceLocal();
	}

	public override string ToString()
	{
		return Name;
	}
}
