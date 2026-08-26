using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public abstract class SpecializedParameterizedMember : SpecializedMember, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	private IList<IParameter> parameters;

	public IList<IParameter> Parameters
	{
		get
		{
			IList<IParameter> list = LazyInit.VolatileRead(ref parameters);
			if (list != null)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref parameters, CreateParameters(base.Substitution));
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

	protected IList<IParameter> CreateParameters(TypeVisitor substitution)
	{
		IList<IParameter> list = ((IParameterizedMember)baseMember).Parameters;
		if (list.Count == 0)
		{
			return EmptyList<IParameter>.Instance;
		}
		IParameter[] array = new IParameter[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			IParameter parameter = list[i];
			IType type = parameter.Type.AcceptVisitor(substitution);
			array[i] = new DefaultParameter(type, parameter.Name, this, parameter.Region, parameter.Attributes, parameter.IsRef, parameter.IsOut, parameter.IsParams, parameter.IsOptional, parameter.ConstantValue, parameter.IsIn);
		}
		return Array.AsReadOnly(array);
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
		for (int i = 0; i < Parameters.Count; i++)
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
