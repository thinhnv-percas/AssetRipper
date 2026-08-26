using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class SpecializedMethod : SpecializedParameterizedMember, IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private sealed class SpecializedTypeParameter : AbstractTypeParameter
	{
		private readonly ITypeParameter baseTp;

		internal TypeVisitor substitution;

		public override bool HasValueTypeConstraint => baseTp.HasValueTypeConstraint;

		public override bool HasReferenceTypeConstraint => baseTp.HasReferenceTypeConstraint;

		public override bool HasDefaultConstructorConstraint => baseTp.HasDefaultConstructorConstraint;

		public override bool HasUnmanagedConstraint => baseTp.HasUnmanagedConstraint;

		public override Nullability NullabilityConstraint => baseTp.NullabilityConstraint;

		public override IEnumerable<IType> DirectBaseTypes => Enumerable.Select<IType, IType>(baseTp.DirectBaseTypes, (Func<IType, IType>)((IType t) => t.AcceptVisitor(substitution)));

		public SpecializedTypeParameter(ITypeParameter baseTp, IMethod specializedOwner)
			: base(specializedOwner, baseTp.Index, baseTp.Name, baseTp.Variance)
		{
			this.baseTp = baseTp;
		}

		public override IEnumerable<IAttribute> GetAttributes()
		{
			return baseTp.GetAttributes();
		}

		public override int GetHashCode()
		{
			return baseTp.GetHashCode() ^ base.Owner.GetHashCode();
		}

		public override bool Equals(IType other)
		{
			return other is SpecializedTypeParameter specializedTypeParameter && baseTp.Equals(specializedTypeParameter.baseTp) && base.Owner.Equals(specializedTypeParameter.Owner);
		}
	}

	private readonly IMethod methodDefinition;

	private readonly ITypeParameter[] specializedTypeParameters;

	private readonly bool isParameterized;

	private readonly TypeParameterSubstitution substitutionWithoutSpecializedTypeParameters;

	private IMember accessorOwner;

	public IReadOnlyList<IType> TypeArguments => base.Substitution.MethodTypeArguments ?? EmptyList<IType>.Instance;

	public IReadOnlyList<ITypeParameter> TypeParameters
	{
		get
		{
			IReadOnlyList<ITypeParameter> readOnlyList = specializedTypeParameters;
			return readOnlyList ?? methodDefinition.TypeParameters;
		}
	}

	public bool IsExtensionMethod => methodDefinition.IsExtensionMethod;

	public bool IsConstructor => methodDefinition.IsConstructor;

	public bool IsDestructor => methodDefinition.IsDestructor;

	public bool IsOperator => methodDefinition.IsOperator;

	public bool HasBody => methodDefinition.HasBody;

	public bool IsAccessor => methodDefinition.IsAccessor;

	public IMethod ReducedFrom => null;

	public IMember AccessorOwner
	{
		get
		{
			IMember member = LazyInit.VolatileRead(ref accessorOwner);
			if (member != null)
			{
				return member;
			}
			IMember member2 = methodDefinition.AccessorOwner;
			if (member2 == null)
			{
				return null;
			}
			member = member2.Specialize(base.Substitution);
			return LazyInit.GetOrSet(ref accessorOwner, member);
		}
		internal set
		{
			accessorOwner = value;
		}
	}

	internal static IMethod Create(IMethod methodDefinition, TypeParameterSubstitution substitution)
	{
		if (TypeParameterSubstitution.Identity.Equals(substitution))
		{
			return methodDefinition;
		}
		if (methodDefinition.DeclaringType is ArrayType)
		{
			return new SpecializedMethod(methodDefinition, substitution);
		}
		if (methodDefinition.TypeParameters.Count == 0)
		{
			if (methodDefinition.DeclaringType.TypeParameterCount == 0)
			{
				return methodDefinition;
			}
			if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
			{
				substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
			}
		}
		return new SpecializedMethod(methodDefinition, substitution);
	}

	public SpecializedMethod(IMethod methodDefinition, TypeParameterSubstitution substitution)
		: base(methodDefinition)
	{
		if (substitution == null)
		{
			throw new ArgumentNullException("substitution");
		}
		this.methodDefinition = methodDefinition;
		isParameterized = substitution.MethodTypeArguments != null;
		if (methodDefinition.TypeParameters.Count > 0)
		{
			specializedTypeParameters = new ITypeParameter[methodDefinition.TypeParameters.Count];
			for (int i = 0; i < specializedTypeParameters.Length; i = checked(i + 1))
			{
				specializedTypeParameters[i] = new SpecializedTypeParameter(methodDefinition.TypeParameters[i], this);
			}
			if (!isParameterized)
			{
				substitutionWithoutSpecializedTypeParameters = base.Substitution;
				AddSubstitution(new TypeParameterSubstitution(null, specializedTypeParameters));
			}
		}
		AddSubstitution(substitution);
		if (substitutionWithoutSpecializedTypeParameters != null)
		{
			substitutionWithoutSpecializedTypeParameters = TypeParameterSubstitution.Compose(substitution, substitutionWithoutSpecializedTypeParameters);
		}
		else
		{
			substitutionWithoutSpecializedTypeParameters = base.Substitution;
		}
		if (specializedTypeParameters == null)
		{
			return;
		}
		foreach (SpecializedTypeParameter item in Enumerable.OfType<SpecializedTypeParameter>((IEnumerable)specializedTypeParameters))
		{
			if (item.Owner == this)
			{
				item.substitution = base.Substitution;
			}
		}
	}

	public IEnumerable<IAttribute> GetReturnTypeAttributes()
	{
		return methodDefinition.GetReturnTypeAttributes();
	}

	public override bool Equals(IMember obj, TypeVisitor typeNormalization)
	{
		if (!(obj is SpecializedMethod specializedMethod))
		{
			return false;
		}
		return baseMember.Equals(specializedMethod.baseMember, typeNormalization) && substitutionWithoutSpecializedTypeParameters.Equals(specializedMethod.substitutionWithoutSpecializedTypeParameters, typeNormalization);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is SpecializedMethod specializedMethod))
		{
			return false;
		}
		return baseMember.Equals(specializedMethod.baseMember) && substitutionWithoutSpecializedTypeParameters.Equals(specializedMethod.substitutionWithoutSpecializedTypeParameters);
	}

	public override int GetHashCode()
	{
		return 1000000013 * baseMember.GetHashCode() + 1000000009 * substitutionWithoutSpecializedTypeParameters.GetHashCode();
	}

	public override IMember Specialize(TypeParameterSubstitution newSubstitution)
	{
		return methodDefinition.Specialize(TypeParameterSubstitution.Compose(newSubstitution, substitutionWithoutSpecializedTypeParameters));
	}

	IMethod IMethod.Specialize(TypeParameterSubstitution newSubstitution)
	{
		return methodDefinition.Specialize(TypeParameterSubstitution.Compose(newSubstitution, substitutionWithoutSpecializedTypeParameters));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(GetType().Name);
		stringBuilder.Append(' ');
		stringBuilder.Append(base.DeclaringType.ReflectionName);
		stringBuilder.Append('.');
		stringBuilder.Append(base.Name);
		checked
		{
			if (TypeArguments.Count > 0)
			{
				stringBuilder.Append('[');
				for (int i = 0; i < TypeArguments.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(TypeArguments[i].ReflectionName);
				}
				stringBuilder.Append(']');
			}
			else if (TypeParameters.Count > 0)
			{
				stringBuilder.Append("``");
				stringBuilder.Append(TypeParameters.Count);
			}
			stringBuilder.Append('(');
			for (int j = 0; j < base.Parameters.Count; j++)
			{
				if (j > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(base.Parameters[j].ToString());
			}
			stringBuilder.Append("):");
			stringBuilder.Append(base.ReturnType.ReflectionName);
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}
}
