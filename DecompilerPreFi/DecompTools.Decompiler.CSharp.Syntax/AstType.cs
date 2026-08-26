using System;
using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public abstract class AstType : AstNode
{
	private sealed class NullAstType : AstType
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}

		public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider)
		{
			return SpecialType.UnknownType;
		}
	}

	private sealed class PatternPlaceholder : AstType, INode
	{
		private readonly Pattern child;

		public override NodeType NodeType => NodeType.Pattern;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPatternPlaceholder(this, child);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPatternPlaceholder(this, child);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
		}

		public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider)
		{
			throw new NotSupportedException();
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return child.DoMatch(other, match);
		}

		bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
		{
			return child.DoMatchCollection(role, pos, match, backtrackingInfo);
		}
	}

	public new static readonly AstType Null = new NullAstType();

	public override NodeType NodeType => NodeType.TypeReference;

	public static implicit operator AstType(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}

	public new AstType Clone()
	{
		return (AstType)base.Clone();
	}

	public bool IsVar()
	{
		return this is SimpleType { Identifier: "var" } simpleType && simpleType.TypeArguments.Count == 0;
	}

	public ITypeReference ToTypeReference(InterningProvider interningProvider = null)
	{
		return ToTypeReference(GetNameLookupMode(), interningProvider);
	}

	public abstract ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null);

	public NameLookupMode GetNameLookupMode()
	{
		AstType astType = this;
		while (astType.Parent is AstType)
		{
			astType = (AstType)astType.Parent;
		}
		if (astType.Parent is UsingDeclaration || astType.Parent is UsingAliasDeclaration)
		{
			return NameLookupMode.TypeInUsingDeclaration;
		}
		if (astType.Role == Roles.BaseType && (astType.Parent is TypeDeclaration || (astType.Parent is Constraint && astType.Parent.Parent is TypeDeclaration)))
		{
			return NameLookupMode.BaseTypeReference;
		}
		return NameLookupMode.Type;
	}

	public virtual AstType MakePointerType()
	{
		return new ComposedType
		{
			BaseType = this
		}.MakePointerType();
	}

	public virtual AstType MakeArrayType(int rank = 1)
	{
		return new ComposedType
		{
			BaseType = this
		}.MakeArrayType(rank);
	}

	public AstType MakeNullableType()
	{
		return new ComposedType
		{
			BaseType = this,
			HasNullableSpecifier = true
		};
	}

	public virtual AstType MakeRefType()
	{
		return new ComposedType
		{
			BaseType = this,
			HasRefSpecifier = true
		};
	}

	public MemberType MemberType(string memberName, params AstType[] typeArguments)
	{
		MemberType memberType = new MemberType(this, memberName);
		memberType.TypeArguments.AddRange(typeArguments);
		return memberType;
	}

	public MemberType MemberType(string memberName, IEnumerable<AstType> typeArguments)
	{
		MemberType memberType = new MemberType(this, memberName);
		memberType.TypeArguments.AddRange(typeArguments);
		return memberType;
	}

	public static AstType Create(string dottedName)
	{
		string[] array = dottedName.Split(new char[1] { '.' });
		AstType astType = new SimpleType(array[0]);
		for (int i = 1; i < array.Length; i = checked(i + 1))
		{
			astType = new MemberType(astType, array[i]);
		}
		return astType;
	}
}
