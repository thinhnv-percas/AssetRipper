using System;
using System.Collections.Generic;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class SignatureComparer : IEqualityComparer<IMember>
{
	private StringComparer nameComparer;

	public static readonly SignatureComparer Ordinal = new SignatureComparer(StringComparer.Ordinal);

	public SignatureComparer(StringComparer nameComparer)
	{
		if (nameComparer == null)
		{
			throw new ArgumentNullException("nameComparer");
		}
		this.nameComparer = nameComparer;
	}

	public bool Equals(IMember x, IMember y)
	{
		if (x == y)
		{
			return true;
		}
		if (x == null || y == null || x.SymbolKind != y.SymbolKind || !nameComparer.Equals(x.Name, y.Name))
		{
			return false;
		}
		IParameterizedMember parameterizedMember = x as IParameterizedMember;
		IParameterizedMember parameterizedMember2 = y as IParameterizedMember;
		if (parameterizedMember != null && parameterizedMember2 != null)
		{
			IMethod method = x as IMethod;
			IMethod method2 = y as IMethod;
			if (method != null && method2 != null && method.TypeParameters.Count != method2.TypeParameters.Count)
			{
				return false;
			}
			return ParameterListComparer.Instance.Equals(parameterizedMember.Parameters, parameterizedMember2.Parameters);
		}
		return true;
	}

	public int GetHashCode(IMember obj)
	{
		int num = (int)obj.SymbolKind * 33 + nameComparer.GetHashCode(obj.Name);
		if (obj is IParameterizedMember parameterizedMember)
		{
			num *= 27;
			num += ParameterListComparer.Instance.GetHashCode(parameterizedMember.Parameters);
			if (parameterizedMember is IMethod method)
			{
				num += method.TypeParameters.Count;
			}
		}
		return num;
	}
}
