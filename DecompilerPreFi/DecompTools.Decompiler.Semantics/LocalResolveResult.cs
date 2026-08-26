using System;
using System.Globalization;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class LocalResolveResult : ResolveResult
{
	private readonly IVariable variable;

	public IVariable Variable => variable;

	public bool IsParameter => variable is IParameter;

	public override bool IsCompileTimeConstant => variable.IsConst;

	public override object ConstantValue => IsParameter ? null : variable.GetConstantValue();

	public LocalResolveResult(IVariable variable)
		: base(UnpackTypeIfByRefParameter(variable))
	{
		this.variable = variable;
	}

	private static IType UnpackTypeIfByRefParameter(IVariable variable)
	{
		if (variable == null)
		{
			throw new ArgumentNullException("variable");
		}
		IType type = variable.Type;
		if (type.Kind == TypeKind.ByReference && variable is IParameter parameter && (parameter.IsRef || parameter.IsOut))
		{
			return ((ByReferenceType)type).ElementType;
		}
		return type;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[LocalResolveResult {0}]", variable);
	}
}
