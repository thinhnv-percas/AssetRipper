using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class SpecializedMethod : SpecializedParameterizedMember, IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private sealed class SpecializedTypeParameter : AbstractTypeParameter
		{
			private readonly ITypeParameter baseTp;

			internal TypeVisitor substitution;

			public override bool HasValueTypeConstraint => baseTp.HasValueTypeConstraint;

			public override bool HasReferenceTypeConstraint => baseTp.HasReferenceTypeConstraint;

			public override bool HasDefaultConstructorConstraint => baseTp.HasDefaultConstructorConstraint;

			public override IEnumerable<IType> DirectBaseTypes => from t in baseTp.DirectBaseTypes
				select t.AcceptVisitor(substitution);

			public SpecializedTypeParameter(ITypeParameter baseTp, IMethod specializedOwner)
				: base(specializedOwner, baseTp.Index, baseTp.Name, baseTp.Variance, baseTp.Attributes, baseTp.Region)
			{
				this.baseTp = baseTp;
			}

			public override int GetHashCode()
			{
				return baseTp.GetHashCode() ^ base.Owner.GetHashCode();
			}

			public override bool Equals(IType other)
			{
				SpecializedTypeParameter specializedTypeParameter = other as SpecializedTypeParameter;
				if (specializedTypeParameter != null && baseTp.Equals(specializedTypeParameter.baseTp))
				{
					return base.Owner.Equals(specializedTypeParameter.Owner);
				}
				return false;
			}
		}

		private readonly IMethod methodDefinition;

		private readonly ITypeParameter[] specializedTypeParameters;

		private readonly bool isParameterized;

		private readonly TypeParameterSubstitution substitutionWithoutSpecializedTypeParameters;

		private IMember accessorOwner;

		public IList<IType> TypeArguments => base.Substitution.MethodTypeArguments ?? EmptyList<IType>.Instance;

		public bool IsParameterized => isParameterized;

		public IList<IUnresolvedMethod> Parts => methodDefinition.Parts;

		public IList<IAttribute> ReturnTypeAttributes => methodDefinition.ReturnTypeAttributes;

		public IList<ITypeParameter> TypeParameters
		{
			get
			{
				IList<ITypeParameter> list = specializedTypeParameters;
				return list ?? methodDefinition.TypeParameters;
			}
		}

		public bool IsExtensionMethod => methodDefinition.IsExtensionMethod;

		public bool IsConstructor => methodDefinition.IsConstructor;

		public bool IsDestructor => methodDefinition.IsDestructor;

		public bool IsOperator => methodDefinition.IsOperator;

		public bool IsPartial => methodDefinition.IsPartial;

		public bool IsAsync => methodDefinition.IsAsync;

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

		public SpecializedMethod(IMethod methodDefinition, TypeParameterSubstitution substitution)
			: base(methodDefinition)
		{
			if (substitution == null)
			{
				throw new ArgumentNullException("substitution");
			}
			this.methodDefinition = methodDefinition;
			isParameterized = (substitution.MethodTypeArguments != null);
			if (methodDefinition.TypeParameters.Count > 0)
			{
				specializedTypeParameters = new ITypeParameter[methodDefinition.TypeParameters.Count];
				for (int i = 0; i < specializedTypeParameters.Length; i++)
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
			if (specializedTypeParameters != null)
			{
				foreach (SpecializedTypeParameter item in specializedTypeParameters.OfType<SpecializedTypeParameter>())
				{
					if (item.Owner == this)
					{
						item.substitution = base.Substitution;
					}
				}
			}
		}

		public override IMemberReference ToReference()
		{
			if (isParameterized)
			{
				return new SpecializingMemberReference(baseMember.ToReference(), SpecializedMember.ToTypeReference(base.Substitution.ClassTypeArguments), SpecializedMember.ToTypeReference(base.Substitution.MethodTypeArguments));
			}
			return base.ToReference();
		}

		public override IMemberReference ToMemberReference()
		{
			return ToReference();
		}

		public override bool Equals(object obj)
		{
			SpecializedMethod specializedMethod = obj as SpecializedMethod;
			if (specializedMethod == null)
			{
				return false;
			}
			if (baseMember.Equals(specializedMethod.baseMember))
			{
				return substitutionWithoutSpecializedTypeParameters.Equals(specializedMethod.substitutionWithoutSpecializedTypeParameters);
			}
			return false;
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
