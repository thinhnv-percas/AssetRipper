#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public abstract class ContextTrackingVisitor<TResult> : DepthFirstAstVisitor<TResult>
{
	protected ITypeDefinition currentTypeDefinition;

	protected IMethod currentMethod;

	protected void Initialize(TransformContext context)
	{
		currentTypeDefinition = context.CurrentTypeDefinition;
		currentMethod = context.CurrentMember as IMethod;
	}

	protected void Uninitialize()
	{
		currentTypeDefinition = null;
		currentMethod = null;
	}

	public override TResult VisitTypeDeclaration(TypeDeclaration typeDeclaration)
	{
		ITypeDefinition typeDefinition = currentTypeDefinition;
		try
		{
			currentTypeDefinition = typeDeclaration.GetSymbol() as ITypeDefinition;
			return base.VisitTypeDeclaration(typeDeclaration);
		}
		finally
		{
			currentTypeDefinition = typeDefinition;
		}
	}

	public override TResult VisitMethodDeclaration(MethodDeclaration methodDeclaration)
	{
		Debug.Assert(currentMethod == null);
		try
		{
			currentMethod = methodDeclaration.GetSymbol() as IMethod;
			return base.VisitMethodDeclaration(methodDeclaration);
		}
		finally
		{
			currentMethod = null;
		}
	}

	public override TResult VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
	{
		Debug.Assert(currentMethod == null);
		try
		{
			currentMethod = constructorDeclaration.GetSymbol() as IMethod;
			return base.VisitConstructorDeclaration(constructorDeclaration);
		}
		finally
		{
			currentMethod = null;
		}
	}

	public override TResult VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
	{
		Debug.Assert(currentMethod == null);
		try
		{
			currentMethod = destructorDeclaration.GetSymbol() as IMethod;
			return base.VisitDestructorDeclaration(destructorDeclaration);
		}
		finally
		{
			currentMethod = null;
		}
	}

	public override TResult VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
	{
		Debug.Assert(currentMethod == null);
		try
		{
			currentMethod = operatorDeclaration.GetSymbol() as IMethod;
			return base.VisitOperatorDeclaration(operatorDeclaration);
		}
		finally
		{
			currentMethod = null;
		}
	}

	public override TResult VisitAccessor(Accessor accessor)
	{
		Debug.Assert(currentMethod == null);
		try
		{
			currentMethod = accessor.GetSymbol() as IMethod;
			return base.VisitAccessor(accessor);
		}
		finally
		{
			currentMethod = null;
		}
	}
}
