#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class IntroduceUsingDeclarations : IAstTransform
{
	private sealed class FindRequiredImports : DepthFirstAstVisitor
	{
		private string currentNamespace;

		public readonly HashSet<string> DeclaredNamespaces;

		public readonly HashSet<string> ImportedNamespaces;

		public FindRequiredImports(TransformContext context)
		{
			HashSet<string> obj = new HashSet<string>();
			obj.Add(string.Empty);
			DeclaredNamespaces = obj;
			ImportedNamespaces = new HashSet<string>();
			currentNamespace = context.CurrentTypeDefinition?.Namespace ?? string.Empty;
		}

		private bool IsParentOfCurrentNamespace(string ns)
		{
			if (ns.Length == 0)
			{
				return true;
			}
			if (currentNamespace.StartsWith(ns, StringComparison.Ordinal))
			{
				if (currentNamespace.Length == ns.Length)
				{
					return true;
				}
				if (currentNamespace[ns.Length] == '.')
				{
					return true;
				}
			}
			return false;
		}

		public override void VisitSimpleType(SimpleType simpleType)
		{
			TypeResolveResult typeResolveResult = simpleType.Annotation<TypeResolveResult>();
			if (typeResolveResult != null && !IsParentOfCurrentNamespace(typeResolveResult.Type.Namespace))
			{
				ImportedNamespaces.Add(typeResolveResult.Type.Namespace);
			}
			base.VisitSimpleType(simpleType);
		}

		public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			string text = currentNamespace;
			foreach (string identifier in namespaceDeclaration.Identifiers)
			{
				currentNamespace = NamespaceDeclaration.BuildQualifiedName(currentNamespace, identifier);
				DeclaredNamespaces.Add(currentNamespace);
			}
			base.VisitNamespaceDeclaration(namespaceDeclaration);
			currentNamespace = text;
		}
	}

	private sealed class FullyQualifyAmbiguousTypeNamesVisitor : DepthFirstAstVisitor
	{
		private Stack<CSharpTypeResolveContext> context;

		private TypeSystemAstBuilder astBuilder;

		private bool ignoreUsingScope;

		public FullyQualifyAmbiguousTypeNamesVisitor(TransformContext context, UsingScope usingScope)
		{
			ignoreUsingScope = !context.Settings.UsingDeclarations;
			CSharpTypeResolveContext cSharpTypeResolveContext;
			if (ignoreUsingScope)
			{
				cSharpTypeResolveContext = new CSharpTypeResolveContext(context.TypeSystem.MainModule);
			}
			else
			{
				this.context = new Stack<CSharpTypeResolveContext>();
				if (!string.IsNullOrEmpty(context.CurrentTypeDefinition?.Namespace))
				{
					string[] array = context.CurrentTypeDefinition.Namespace.Split(new char[1] { '.' });
					foreach (string shortName in array)
					{
						usingScope = new UsingScope(usingScope, shortName);
					}
				}
				cSharpTypeResolveContext = new CSharpTypeResolveContext(context.TypeSystem.MainModule, usingScope.Resolve(context.TypeSystem), context.CurrentTypeDefinition);
				this.context.Push(cSharpTypeResolveContext);
			}
			astBuilder = CreateAstBuilder(cSharpTypeResolveContext);
		}

		private static TypeSystemAstBuilder CreateAstBuilder(CSharpTypeResolveContext context)
		{
			return new TypeSystemAstBuilder(new CSharpResolver(context))
			{
				AddResolveResultAnnotations = true,
				UseAliases = true
			};
		}

		public override void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
		{
			if (ignoreUsingScope)
			{
				base.VisitNamespaceDeclaration(namespaceDeclaration);
				return;
			}
			CSharpTypeResolveContext cSharpTypeResolveContext = context.Peek();
			UsingScope usingScope = cSharpTypeResolveContext.CurrentUsingScope.UnresolvedUsingScope;
			foreach (string identifier in namespaceDeclaration.Identifiers)
			{
				usingScope = new UsingScope(usingScope, identifier);
			}
			CSharpTypeResolveContext cSharpTypeResolveContext2 = new CSharpTypeResolveContext(cSharpTypeResolveContext.CurrentModule, usingScope.Resolve(cSharpTypeResolveContext.Compilation));
			context.Push(cSharpTypeResolveContext2);
			try
			{
				astBuilder = CreateAstBuilder(cSharpTypeResolveContext2);
				base.VisitNamespaceDeclaration(namespaceDeclaration);
			}
			finally
			{
				astBuilder = CreateAstBuilder(cSharpTypeResolveContext);
				context.Pop();
			}
		}

		public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
		{
			if (ignoreUsingScope)
			{
				base.VisitTypeDeclaration(typeDeclaration);
				return;
			}
			CSharpTypeResolveContext cSharpTypeResolveContext = context.Peek();
			CSharpTypeResolveContext cSharpTypeResolveContext2 = cSharpTypeResolveContext.WithCurrentTypeDefinition(typeDeclaration.GetSymbol() as ITypeDefinition);
			context.Push(cSharpTypeResolveContext2);
			try
			{
				astBuilder = CreateAstBuilder(cSharpTypeResolveContext2);
				base.VisitTypeDeclaration(typeDeclaration);
			}
			finally
			{
				astBuilder = CreateAstBuilder(cSharpTypeResolveContext);
				context.Pop();
			}
		}

		public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			if (ignoreUsingScope)
			{
				base.VisitMethodDeclaration(methodDeclaration);
				return;
			}
			if (methodDeclaration.GetSymbol() is IMethod method && CSharpDecompiler.IsWindowsFormsInitializeComponentMethod(method))
			{
				CSharpTypeResolveContext cSharpTypeResolveContext = context.Peek();
				CSharpTypeResolveContext cSharpTypeResolveContext2 = new CSharpTypeResolveContext(cSharpTypeResolveContext.CurrentModule);
				context.Push(cSharpTypeResolveContext2);
				try
				{
					astBuilder = CreateAstBuilder(cSharpTypeResolveContext2);
					base.VisitMethodDeclaration(methodDeclaration);
					return;
				}
				finally
				{
					astBuilder = CreateAstBuilder(cSharpTypeResolveContext);
					context.Pop();
				}
			}
			base.VisitMethodDeclaration(methodDeclaration);
		}

		public override void VisitSimpleType(SimpleType simpleType)
		{
			TypeResolveResult typeResolveResult;
			if ((typeResolveResult = simpleType.Annotation<TypeResolveResult>()) == null)
			{
				base.VisitSimpleType(simpleType);
				return;
			}
			astBuilder.NameLookupMode = simpleType.GetNameLookupMode();
			if (astBuilder.NameLookupMode == NameLookupMode.Type)
			{
				AstType astType = simpleType;
				while (astType.Parent is AstType)
				{
					astType = (AstType)astType.Parent;
				}
				if (astType.Parent is TypeReferenceExpression)
				{
					astBuilder.NameLookupMode = NameLookupMode.Expression;
				}
			}
			if (simpleType.Parent is DecompTools.Decompiler.CSharp.Syntax.Attribute)
			{
				simpleType.ReplaceWith(astBuilder.ConvertAttributeType(typeResolveResult.Type));
			}
			else
			{
				simpleType.ReplaceWith(astBuilder.ConvertType(typeResolveResult.Type));
			}
		}
	}

	public void Run(AstNode rootNode, TransformContext context)
	{
		FindRequiredImports findRequiredImports = new FindRequiredImports(context);
		rootNode.AcceptVisitor(findRequiredImports);
		UsingScope usingScope = new UsingScope();
		rootNode.AddAnnotation(usingScope);
		if (context.Settings.UsingDeclarations)
		{
			AstNode prevSibling = Enumerable.LastOrDefault<AstNode>(rootNode.Children, (Func<AstNode, bool>)((AstNode n) => n is PreProcessorDirective preProcessorDirective && preProcessorDirective.Type == PreProcessorDirectiveType.Define));
			foreach (string item2 in (IEnumerable<string>)Enumerable.OrderByDescending<string, string>((IEnumerable<string>)findRequiredImports.ImportedNamespaces, (Func<string, string>)((string n) => n)))
			{
				Debug.Assert(context.RequiredNamespacesSuperset.Contains(item2), "Should not insert using declaration for namespace that is missing from the superset: " + item2);
				string[] array = item2.Split(new char[1] { '.' });
				AstType astType = new SimpleType(array[0]);
				for (int num = 1; num < array.Length; num = checked(num + 1))
				{
					astType = new MemberType
					{
						Target = astType,
						MemberName = array[num]
					};
				}
				if (astType.ToTypeReference(NameLookupMode.TypeInUsingDeclaration) is TypeOrNamespaceReference item)
				{
					usingScope.Usings.Add(item);
				}
				rootNode.InsertChildAfter(prevSibling, new UsingDeclaration
				{
					Import = astType
				}, SyntaxTree.MemberRole);
			}
		}
		rootNode.AcceptVisitor(new FullyQualifyAmbiguousTypeNamesVisitor(context, usingScope));
	}
}
