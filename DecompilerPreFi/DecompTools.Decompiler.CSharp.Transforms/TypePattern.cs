using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.Semantics;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal sealed class TypePattern : Pattern
{
	private readonly string ns;

	private readonly string name;

	public TypePattern(Type type)
	{
		ns = type.Namespace;
		name = type.Name;
	}

	public override bool DoMatch(INode other, Match match)
	{
		AstType astType;
		if (other is ComposedType { HasRefSpecifier: false, HasNullableSpecifier: false, PointerRank: 0 } composedType && !Enumerable.Any<ArraySpecifier>((IEnumerable<ArraySpecifier>)composedType.ArraySpecifiers))
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
		return astType.GetResolveResult() is TypeResolveResult typeResolveResult && typeResolveResult.Type.Namespace == ns && typeResolveResult.Type.Name == name;
	}

	public override string ToString()
	{
		return name;
	}
}
