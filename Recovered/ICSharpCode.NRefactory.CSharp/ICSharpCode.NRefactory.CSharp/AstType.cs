using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
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
			SimpleType simpleType = this as SimpleType;
			if (simpleType != null && simpleType.Identifier == "var")
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

		public virtual AstType MakeRefType()
		{
			return new ComposedType
			{
				BaseType = this,
				HasRefSpecifier = true
			};
		}

		public MemberReferenceExpression Member(string memberName)
		{
			return new TypeReferenceExpression
			{
				Type = this
			}.Member(memberName);
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

		public InvocationExpression Invoke(string methodName, IEnumerable<Expression> arguments)
		{
			return new TypeReferenceExpression
			{
				Type = this
			}.Invoke(methodName, arguments);
		}

		public InvocationExpression Invoke(string methodName, params Expression[] arguments)
		{
			return new TypeReferenceExpression
			{
				Type = this
			}.Invoke(methodName, arguments);
		}

		public InvocationExpression Invoke(string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
		{
			return new TypeReferenceExpression
			{
				Type = this
			}.Invoke(methodName, typeArguments, arguments);
		}

		public static AstType Create(string dottedName)
		{
			string[] array = dottedName.Split('.');
			AstType astType = new SimpleType(array[0]);
			for (int i = 1; i < array.Length; i++)
			{
				astType = new MemberType(astType, array[i]);
			}
			return astType;
		}
	}
}
