using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IMethod : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		IList<IUnresolvedMethod> Parts
		{
			get;
		}

		IList<IAttribute> ReturnTypeAttributes
		{
			get;
		}

		IList<ITypeParameter> TypeParameters
		{
			get;
		}

		bool IsParameterized
		{
			get;
		}

		IList<IType> TypeArguments
		{
			get;
		}

		bool IsExtensionMethod
		{
			get;
		}

		bool IsConstructor
		{
			get;
		}

		bool IsDestructor
		{
			get;
		}

		bool IsOperator
		{
			get;
		}

		bool IsPartial
		{
			get;
		}

		bool IsAsync
		{
			get;
		}

		bool HasBody
		{
			get;
		}

		bool IsAccessor
		{
			get;
		}

		IMember AccessorOwner
		{
			get;
		}

		IMethod ReducedFrom
		{
			get;
		}

		new IMethod Specialize(TypeParameterSubstitution substitution);
	}
}
