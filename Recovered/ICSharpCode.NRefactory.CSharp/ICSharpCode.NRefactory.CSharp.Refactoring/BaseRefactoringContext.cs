using ICSharpCode.NRefactory.Analysis;
using ICSharpCode.NRefactory.CSharp.Analysis;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public abstract class BaseRefactoringContext : IServiceProvider
	{
		private readonly CSharpAstResolver resolver;

		private readonly CancellationToken cancellationToken;

		private LocalReferenceFinder referenceFinder;

		private IServiceContainer services = new ServiceContainer();

		public abstract string DefaultNamespace
		{
			get;
		}

		public virtual bool UseExplicitTypes
		{
			get;
			set;
		}

		public CancellationToken CancellationToken => cancellationToken;

		public virtual AstNode RootNode => resolver.RootNode;

		public CSharpAstResolver Resolver => resolver;

		public virtual CSharpUnresolvedFile UnresolvedFile => resolver.UnresolvedFile;

		public ICompilation Compilation => resolver.Compilation;

		public virtual TypeGraph TypeGraph => new TypeGraph(Compilation.Assemblies);

		public virtual TextEditorOptions TextEditorOptions => TextEditorOptions.Default;

		public virtual bool IsSomethingSelected => SelectionStart != TextLocation.Empty;

		public virtual string SelectedText => string.Empty;

		public virtual TextLocation SelectionStart => TextLocation.Empty;

		public virtual TextLocation SelectionEnd => TextLocation.Empty;

		public IServiceContainer Services
		{
			get
			{
				return services;
			}
			protected set
			{
				services = value;
			}
		}

		public virtual bool Supports(Version version)
		{
			return true;
		}

		public BaseRefactoringContext(CSharpAstResolver resolver, CancellationToken cancellationToken)
		{
			this.resolver = resolver;
			this.cancellationToken = cancellationToken;
			referenceFinder = new LocalReferenceFinder(resolver);
		}

		public ResolveResult Resolve(AstNode node)
		{
			return resolver.Resolve(node, cancellationToken);
		}

		public CSharpResolver GetResolverStateBefore(AstNode node)
		{
			return resolver.GetResolverStateBefore(node, cancellationToken);
		}

		public CSharpResolver GetResolverStateAfter(AstNode node)
		{
			return resolver.GetResolverStateAfter(node, cancellationToken);
		}

		public IType ResolveType(AstType type)
		{
			return resolver.Resolve(type, cancellationToken).Type;
		}

		public IType GetExpectedType(Expression expression)
		{
			return resolver.GetExpectedType(expression, cancellationToken);
		}

		public Conversion GetConversion(Expression expression)
		{
			return resolver.GetConversion(expression, cancellationToken);
		}

		public TypeSystemAstBuilder CreateTypeSystemAstBuilder(AstNode node)
		{
			return new TypeSystemAstBuilder(resolver.GetResolverStateBefore(node));
		}

		public DefiniteAssignmentAnalysis CreateDefiniteAssignmentAnalysis(Statement root)
		{
			return new DefiniteAssignmentAnalysis(root, resolver, CancellationToken);
		}

		public ReachabilityAnalysis CreateReachabilityAnalysis(Statement statement, ReachabilityAnalysis.RecursiveDetectorVisitor recursiveDetectorVisitor = null)
		{
			return ReachabilityAnalysis.Create(statement, resolver, recursiveDetectorVisitor, CancellationToken);
		}

		public virtual FormatStringParseResult ParseFormatString(string source)
		{
			return new CompositeFormatStringParser().Parse(source);
		}

		public IList<ReferenceResult> FindReferences(AstNode rootNode, IVariable variable)
		{
			return referenceFinder.FindReferences(rootNode, variable);
		}

		public virtual string GetNameProposal(string name, TextLocation loc, bool camelCase = true)
		{
			string text = (camelCase ? char.ToLower(name[0]) : char.ToUpper(name[0])).ToString() + name.Substring(1);
			TypeDeclaration nodeAt = RootNode.GetNodeAt<TypeDeclaration>(loc);
			if (nodeAt == null)
			{
				return text;
			}
			int num = -1;
			string proposedName;
			do
			{
				proposedName = AppendNumberToName(text, num++);
			}
			while ((from m in nodeAt.Members
				select m.GetChildByRole(Roles.Identifier)).Any((Identifier n) => n.Name == proposedName));
			return proposedName;
		}

		public virtual string GetLocalNameProposal(string name, TextLocation loc, bool camelCase = true)
		{
			string text = (camelCase ? char.ToLower(name[0]) : char.ToUpper(name[0])).ToString() + name.Substring(1);
			AstNode nodeAt = RootNode.GetNodeAt(loc);
			if (nodeAt == null)
			{
				return text;
			}
			CSharpResolver resolverStateBefore = GetResolverStateBefore(nodeAt);
			int num = -1;
			string text2;
			do
			{
				text2 = AppendNumberToName(text, num++);
			}
			while (!(resolverStateBefore.ResolveSimpleName(text2, EmptyList<IType>.Instance) is UnknownIdentifierResolveResult));
			return text2;
		}

		private static string AppendNumberToName(string baseName, int number)
		{
			return baseName + ((number > 0) ? (number + 1).ToString() : "");
		}

		public abstract int GetOffset(TextLocation location);

		public abstract IDocumentLine GetLineByOffset(int offset);

		public int GetOffset(int line, int col)
		{
			return GetOffset(new TextLocation(line, col));
		}

		public abstract TextLocation GetLocation(int offset);

		public abstract string GetText(int offset, int length);

		public abstract string GetText(ISegment segment);

		public virtual string TranslateString(string str)
		{
			return str;
		}

		public object GetService(Type serviceType)
		{
			return services.GetService(serviceType);
		}
	}
}
