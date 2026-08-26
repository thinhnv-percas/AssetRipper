using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

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
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public new AstType Clone()
	{
		return (AstType)base.Clone();
	}

	public bool IsVar()
	{
		if (this is SimpleType { Identifier: "var" } simpleType)
		{
			return simpleType.TypeArguments.Count == 0;
		}
		return false;
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

	public MemberReferenceExpression Member(string memberName, object memberAnnotation)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Member(memberName, memberAnnotation);
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

	public InvocationExpression Invoke(object annotation, string methodName, IEnumerable<Expression> arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke(annotation, methodName, arguments);
	}

	public InvocationExpression Invoke(string methodName, params Expression[] arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke(methodName, arguments);
	}

	public InvocationExpression Invoke2(object annotation, string methodName, params Expression[] arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke2(annotation, methodName, arguments);
	}

	public InvocationExpression Invoke(object annotation, string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke(annotation, methodName, typeArguments, arguments);
	}

	public static AstType Create(string dottedName, object tokenKind)
	{
		string[] array = dottedName.Split('.');
		AstType astType = new SimpleType(array[0]).WithAnnotation(tokenKind);
		for (int i = 1; i < array.Length; i++)
		{
			astType = new MemberType(astType, array[i]).WithAnnotation(tokenKind);
		}
		return astType;
	}
}
