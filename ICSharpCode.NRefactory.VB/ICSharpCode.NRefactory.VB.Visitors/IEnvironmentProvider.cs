using System;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.VB.Ast;

namespace ICSharpCode.NRefactory.VB.Visitors;

public interface IEnvironmentProvider
{
	string RootNamespace { get; }

	string GetTypeNameForAttribute(ICSharpCode.NRefactory.CSharp.Attribute attribute);

	TypeKind GetTypeKindForAstType(ICSharpCode.NRefactory.CSharp.AstType type);

	TypeCode ResolveExpression(ICSharpCode.NRefactory.CSharp.Expression expression);

	bool? IsReferenceType(ICSharpCode.NRefactory.CSharp.Expression expression);

	IType ResolveType(ICSharpCode.NRefactory.VB.Ast.AstType type, ICSharpCode.NRefactory.VB.Ast.TypeDeclaration entity = null);

	bool IsMethodGroup(ICSharpCode.NRefactory.CSharp.Expression expression);

	bool HasEvent(ICSharpCode.NRefactory.VB.Ast.Expression expression);

	ICSharpCode.NRefactory.CSharp.ParameterDeclaration[] GetParametersForProperty(ICSharpCode.NRefactory.CSharp.PropertyDeclaration property);
}
