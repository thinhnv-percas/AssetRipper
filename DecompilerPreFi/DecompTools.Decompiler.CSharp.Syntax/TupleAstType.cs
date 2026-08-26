using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TupleAstType : AstType
{
	public static readonly Role<TupleTypeElement> ElementRole = new Role<TupleTypeElement>("Element", TupleTypeElement.Null);

	public AstNodeCollection<TupleTypeElement> Elements => GetChildrenByRole(ElementRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTupleType(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTupleType(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTupleType(this, data);
	}

	public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null)
	{
		return new TupleTypeReference(Enumerable.Select<TupleTypeElement, ITypeReference>((IEnumerable<TupleTypeElement>)Elements, (Func<TupleTypeElement, ITypeReference>)((TupleTypeElement e) => e.Type.ToTypeReference(lookupMode, interningProvider))).ToImmutableArray(), Enumerable.Select<TupleTypeElement, string>((IEnumerable<TupleTypeElement>)Elements, (Func<TupleTypeElement, string>)((TupleTypeElement e) => e.Name)).ToImmutableArray());
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TupleAstType tupleAstType && Elements.DoMatch(tupleAstType.Elements, match);
	}
}
