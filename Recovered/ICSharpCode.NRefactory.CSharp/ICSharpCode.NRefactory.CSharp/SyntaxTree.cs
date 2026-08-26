using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp
{
	public class SyntaxTree : AstNode
	{
		public static readonly Role<AstNode> MemberRole = new Role<AstNode>("Member", AstNode.Null);

		private string fileName;

		private IList<string> conditionalSymbols;

		private List<Error> errors = new List<Error>();

		public override NodeType NodeType => NodeType.Unknown;

		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				ThrowIfFrozen();
				fileName = value;
			}
		}

		public AstNodeCollection<AstNode> Members => GetChildrenByRole(MemberRole);

		public List<Error> Errors => errors;

		public IList<string> ConditionalSymbols
		{
			get
			{
				return conditionalSymbols ?? EmptyList<string>.Instance;
			}
			internal set
			{
				conditionalSymbols = value;
			}
		}

		public AstNode TopExpression
		{
			get;
			internal set;
		}

		public IEnumerable<EntityDeclaration> GetTypes(bool includeInnerTypes = false)
		{
			Stack<AstNode> nodeStack = new Stack<AstNode>();
			nodeStack.Push(this);
			while (nodeStack.Count > 0)
			{
				AstNode curNode = nodeStack.Pop();
				if (curNode is TypeDeclaration || curNode is DelegateDeclaration)
				{
					yield return (EntityDeclaration)curNode;
				}
				foreach (AstNode child in curNode.Children)
				{
					if (!(child is Statement) && !(child is Expression) && (child.Role != Roles.TypeMemberRole || ((child is TypeDeclaration || child is DelegateDeclaration) & includeInnerTypes)))
					{
						nodeStack.Push(child);
					}
				}
			}
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			SyntaxTree syntaxTree = other as SyntaxTree;
			if (syntaxTree != null)
			{
				return Members.DoMatch(syntaxTree.Members, match);
			}
			return false;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitSyntaxTree(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitSyntaxTree(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitSyntaxTree(this, data);
		}

		public CSharpUnresolvedFile ToTypeSystem()
		{
			if (string.IsNullOrEmpty(FileName))
			{
				throw new InvalidOperationException("Cannot use ToTypeSystem() on a syntax tree without file name.");
			}
			TypeSystemConvertVisitor typeSystemConvertVisitor = new TypeSystemConvertVisitor(FileName);
			typeSystemConvertVisitor.VisitSyntaxTree(this);
			return typeSystemConvertVisitor.UnresolvedFile;
		}

		public static SyntaxTree Parse(string program, string fileName = "", CompilerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new CSharpParser(settings).Parse(program, fileName);
		}

		public static SyntaxTree Parse(TextReader reader, string fileName = "", CompilerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new CSharpParser(settings).Parse(reader, fileName);
		}

		public static SyntaxTree Parse(Stream stream, string fileName = "", CompilerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new CSharpParser(settings).Parse(stream, fileName);
		}

		public static SyntaxTree Parse(ITextSource textSource, string fileName = "", CompilerSettings settings = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new CSharpParser(settings).Parse(textSource, fileName);
		}
	}
}
