using System;
using System.Linq;
using dnlib.DotNet;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

internal sealed class TypePattern : Pattern
{
	private readonly UTF8String ns;

	private readonly UTF8String name;

	public TypePattern(Type type)
	{
		ns = type.Namespace;
		name = type.Name;
	}

	public override bool DoMatch(INode other, Match match)
	{
		AstType astType;
		if (other is ComposedType { HasNullableSpecifier: false, PointerRank: 0 } composedType && !composedType.ArraySpecifiers.Any())
		{
			astType = composedType.BaseType;
		}
		else
		{
			astType = other as AstType;
			if (astType == null)
			{
				return false;
			}
		}
		ITypeDefOrRef type = astType.Annotation<ITypeDefOrRef>();
		return type.Compare(ns, name);
	}

	public override string ToString()
	{
		return name;
	}
}
