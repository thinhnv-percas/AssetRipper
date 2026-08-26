using System;
using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class AstType : AstNode
{
	private sealed class NullAstType : AstType
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	private sealed class PatternPlaceholder : AstType, INode
	{
		private readonly Pattern child;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
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

	public static implicit operator AstType(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public virtual AstType MakeArrayType(int rank = 1)
	{
		return new ComposedType
		{
			BaseType = this
		}.MakeArrayType(rank);
	}

	public static AstType FromName(string fullName, object data)
	{
		if (string.IsNullOrEmpty(fullName))
		{
			throw new ArgumentNullException("fullName");
		}
		fullName = fullName.Trim();
		if (!fullName.Contains("."))
		{
			return SimpleType.CreateWithColor(data, fullName);
		}
		string[] array = fullName.Split('.');
		AstType astType = SimpleType.CreateWithColor(BoxedTextColor.Namespace, array.First());
		for (int i = 1; i < array.Length; i++)
		{
			string name = array[i];
			object annotation = ((i + 1 == array.Length) ? data : BoxedTextColor.Namespace);
			astType = new QualifiedType(astType, Identifier.Create(annotation, name));
		}
		return astType;
	}

	public MemberAccessExpression Member(object annotation, string memberName)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Member(annotation, memberName);
	}

	public InvocationExpression Invoke(string methodName, IEnumerable<Expression> arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke2(null, methodName, arguments);
	}

	public InvocationExpression Invoke(string methodName, params Expression[] arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke2(null, methodName, arguments);
	}

	public InvocationExpression Invoke(string methodName, IEnumerable<AstType> typeArguments, IEnumerable<Expression> arguments)
	{
		return new TypeReferenceExpression
		{
			Type = this
		}.Invoke(null, methodName, typeArguments, arguments);
	}
}
