using System.Globalization;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ConstantResolveResult : ResolveResult
{
	private object constantValue;

	public override bool IsCompileTimeConstant => true;

	public override object ConstantValue => constantValue;

	public ConstantResolveResult(IType type, object constantValue)
		: base(type)
	{
		this.constantValue = constantValue;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1} = {2}]", GetType().Name, base.Type, constantValue);
	}
}
