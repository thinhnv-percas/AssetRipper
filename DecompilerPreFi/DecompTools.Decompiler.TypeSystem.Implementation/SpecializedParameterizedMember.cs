using System;
using System.Collections.Generic;
using System.Text;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public abstract class SpecializedParameterizedMember : SpecializedMember, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private IReadOnlyList<IParameter> parameters;

	public IReadOnlyList<IParameter> Parameters
	{
		get
		{
			IReadOnlyList<IParameter> readOnlyList = LazyInit.VolatileRead(ref parameters);
			if (readOnlyList != null)
			{
				return readOnlyList;
			}
			return LazyInit.GetOrSet(ref parameters, CreateParameters((IType t) => t.AcceptVisitor(base.Substitution)));
		}
		protected set
		{
			parameters = value;
		}
	}

	protected SpecializedParameterizedMember(IParameterizedMember memberDefinition)
		: base(memberDefinition)
	{
	}

	protected IParameter[] CreateParameters(Func<IType, IType> substitution)
	{
		IReadOnlyList<IParameter> readOnlyList = ((IParameterizedMember)baseMember).Parameters;
		if (readOnlyList.Count == 0)
		{
			return Empty<IParameter>.Array;
		}
		IParameter[] array = new IParameter[readOnlyList.Count];
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			IParameter parameter = readOnlyList[i];
			IType newType = substitution(parameter.Type);
			array[i] = new SpecializedParameter(parameter, newType, this);
		}
		return array;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(GetType().Name);
		stringBuilder.Append(' ');
		stringBuilder.Append(base.DeclaringType.ReflectionName);
		stringBuilder.Append('.');
		stringBuilder.Append(base.Name);
		stringBuilder.Append('(');
		for (int i = 0; i < Parameters.Count; i = checked(i + 1))
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(Parameters[i].ToString());
		}
		stringBuilder.Append("):");
		stringBuilder.Append(base.ReturnType.ReflectionName);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}
}
