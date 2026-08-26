using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultResolvedField : AbstractResolvedMember, IField, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility, IVariable
	{
		private volatile ResolveResult constantValue;

		public bool IsReadOnly => ((IUnresolvedField)unresolved).IsReadOnly;

		public bool IsVolatile => ((IUnresolvedField)unresolved).IsVolatile;

		IType IVariable.Type => base.ReturnType;

		public bool IsConst => ((IUnresolvedField)unresolved).IsConst;

		public bool IsFixed => ((IUnresolvedField)unresolved).IsFixed;

		public object ConstantValue
		{
			get
			{
				ResolveResult resolveResult = this.constantValue;
				if (resolveResult == null)
				{
					using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
					{
						if (!busyLock.Success)
						{
							return null;
						}
						IConstantValue constantValue = ((IUnresolvedField)unresolved).ConstantValue;
						resolveResult = (this.constantValue = ((constantValue == null) ? ErrorResolveResult.UnknownError : constantValue.Resolve(context)));
					}
				}
				return resolveResult.ConstantValue;
			}
		}

		public DefaultResolvedField(IUnresolvedField unresolved, ITypeResolveContext parentContext)
			: base(unresolved, parentContext)
		{
		}

		public override IMember Specialize(TypeParameterSubstitution substitution)
		{
			if (TypeParameterSubstitution.Identity.Equals(substitution) || base.DeclaringTypeDefinition == null || base.DeclaringTypeDefinition.TypeParameterCount == 0)
			{
				return this;
			}
			if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
			{
				substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
			}
			return new SpecializedField(this, substitution);
		}

		IMemberReference IField.ToReference()
		{
			return (IMemberReference)ToReference();
		}
	}
}
