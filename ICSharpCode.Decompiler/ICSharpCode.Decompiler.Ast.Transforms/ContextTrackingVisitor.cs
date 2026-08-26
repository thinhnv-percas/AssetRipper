using System;
using dnlib.DotNet;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public abstract class ContextTrackingVisitor<TResult> : DepthFirstAstVisitor<object, TResult>, IAstTransform
{
	protected DecompilerContext context;

	protected ContextTrackingVisitor(DecompilerContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		this.context = context;
	}

	public override TResult VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
	{
		TypeDef currentType = context.CurrentType;
		try
		{
			context.CurrentType = typeDeclaration.Annotation<TypeDef>();
			return base.VisitTypeDeclaration(typeDeclaration, data);
		}
		finally
		{
			context.CurrentType = currentType;
		}
	}

	public override TResult VisitMethodDeclaration(MethodDeclaration methodDeclaration, object data)
	{
		FieldToVariableMap variableMap = context.variableMap;
		try
		{
			context.CurrentMethod = methodDeclaration.Annotation<MethodDef>();
			context.variableMap = methodDeclaration.Annotation<FieldToVariableMap>();
			return base.VisitMethodDeclaration(methodDeclaration, data);
		}
		finally
		{
			context.CurrentMethod = null;
			context.variableMap = variableMap;
		}
	}

	public override TResult VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
	{
		FieldToVariableMap variableMap = context.variableMap;
		try
		{
			context.CurrentMethod = constructorDeclaration.Annotation<MethodDef>();
			context.variableMap = constructorDeclaration.Annotation<FieldToVariableMap>();
			return base.VisitConstructorDeclaration(constructorDeclaration, data);
		}
		finally
		{
			context.CurrentMethod = null;
			context.variableMap = variableMap;
		}
	}

	public override TResult VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration, object data)
	{
		FieldToVariableMap variableMap = context.variableMap;
		try
		{
			context.CurrentMethod = destructorDeclaration.Annotation<MethodDef>();
			context.variableMap = destructorDeclaration.Annotation<FieldToVariableMap>();
			return base.VisitDestructorDeclaration(destructorDeclaration, data);
		}
		finally
		{
			context.CurrentMethod = null;
			context.variableMap = variableMap;
		}
	}

	public override TResult VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration, object data)
	{
		FieldToVariableMap variableMap = context.variableMap;
		try
		{
			context.CurrentMethod = operatorDeclaration.Annotation<MethodDef>();
			context.variableMap = operatorDeclaration.Annotation<FieldToVariableMap>();
			return base.VisitOperatorDeclaration(operatorDeclaration, data);
		}
		finally
		{
			context.CurrentMethod = null;
			context.variableMap = variableMap;
		}
	}

	public override TResult VisitAccessor(Accessor accessor, object data)
	{
		FieldToVariableMap variableMap = context.variableMap;
		try
		{
			context.CurrentMethod = accessor.Annotation<MethodDef>();
			context.variableMap = accessor.Annotation<FieldToVariableMap>();
			return base.VisitAccessor(accessor, data);
		}
		finally
		{
			context.CurrentMethod = null;
			context.variableMap = variableMap;
		}
	}

	void IAstTransform.Run(AstNode node)
	{
		node.AcceptVisitor(this, null);
	}
}
