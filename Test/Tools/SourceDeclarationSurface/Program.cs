// Rewrites C# sources to their declaration surface: every body becomes `throw null`, every non-constant
// initialiser is dropped, and nothing that reaches metadata as a declaration changes. A body is what a
// build's stripped engine assemblies cannot compile (a call to a member IL2CPP removed), and a body is not
// what build provenance compares: the question is whether each type, method and field the build declares
// exists in the source with the same signature. Compile the output, then fingerprint it with
// AssemblyFingerprint.
//
// Usage: SourceDeclarationSurface <source root> <output root> [DEFINE ...]
// The defines are the preprocessor symbols the build compiled with; a region they exclude is excluded here.
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

if (args.Length < 2)
{
	Console.Error.WriteLine("usage: SourceDeclarationSurface <source root> <output root> [DEFINE ...]");
	return 2;
}

string sourceRoot = Path.GetFullPath(args[0]);
string outputRoot = Path.GetFullPath(args[1]);
CSharpParseOptions options = new(LanguageVersion.Latest, preprocessorSymbols: args.Skip(2));
int files = 0;
foreach (string path in Directory.EnumerateFiles(sourceRoot, "*.cs", SearchOption.AllDirectories))
{
	SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText(path), options, path);
	SyntaxNode rewritten = new BodyStripper().Visit(tree.GetRoot());
	string target = Path.Combine(outputRoot, Path.GetRelativePath(sourceRoot, path));
	Directory.CreateDirectory(Path.GetDirectoryName(target)!);
	File.WriteAllText(target, rewritten.ToFullString());
	files++;
}
Console.WriteLine($"{files} files rewritten to their declaration surface");
return 0;

sealed class BodyStripper : CSharpSyntaxRewriter
{
	static readonly BlockSyntax ThrowBlock = SyntaxFactory.ParseStatement("{ throw null; }") is BlockSyntax block
		? block
		: throw new InvalidOperationException();

	static readonly ArrowExpressionClauseSyntax ThrowArrow = SyntaxFactory.ArrowExpressionClause(
		SyntaxFactory.ParseExpression(" throw null")).WithLeadingTrivia(SyntaxFactory.Space);

	// `async` is not part of a signature; without a body it only asks for a method builder the build's
	// corlib may have stripped.
	static SyntaxTokenList WithoutAsync(SyntaxTokenList modifiers)
		=> SyntaxFactory.TokenList(modifiers.Where(m => !m.IsKind(SyntaxKind.AsyncKeyword)));

	// Whatever is replaced keeps its trivia: a preprocessor directive or a region marker can sit in the
	// trailing trivia of a body, an initialiser or a semicolon, and dropping it unbalances the file.
	static T Stripped<T>(T node, SyntaxNode replaced) where T : SyntaxNode
		=> node.WithTrailingTrivia(replaced.GetTrailingTrivia());

	static BlockSyntax ThrowBlockFor(CSharpSyntaxNode node) => ThrowBlock.WithLeadingTrivia(SyntaxFactory.Space);

	public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
		=> node.Body is null && node.ExpressionBody is null
			? node
			: Stripped(node.WithModifiers(WithoutAsync(node.Modifiers)).WithBody(ThrowBlockFor(node)).WithExpressionBody(null)
				.WithSemicolonToken(default), node);

	public override SyntaxNode? VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
		=> node.Body is null && node.ExpressionBody is null
			? node
			: Stripped(node.WithBody(ThrowBlockFor(node)).WithExpressionBody(null).WithSemicolonToken(default), node);

	public override SyntaxNode? VisitDestructorDeclaration(DestructorDeclarationSyntax node)
		=> Stripped(node.WithBody(ThrowBlockFor(node)).WithExpressionBody(null).WithSemicolonToken(default), node);

	public override SyntaxNode? VisitOperatorDeclaration(OperatorDeclarationSyntax node)
		=> node.Body is null && node.ExpressionBody is null
			? node
			: Stripped(node.WithBody(ThrowBlockFor(node)).WithExpressionBody(null).WithSemicolonToken(default), node);

	public override SyntaxNode? VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
		=> node.Body is null && node.ExpressionBody is null
			? node
			: Stripped(node.WithBody(ThrowBlockFor(node)).WithExpressionBody(null).WithSemicolonToken(default), node);

	public override SyntaxNode? VisitAccessorDeclaration(AccessorDeclarationSyntax node)
		=> node.Body is null && node.ExpressionBody is null
			? node
			: Stripped(node.WithModifiers(WithoutAsync(node.Modifiers)).WithBody(ThrowBlockFor(node)).WithExpressionBody(null)
				.WithSemicolonToken(default), node);

	public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
	{
		PropertyDeclarationSyntax visited = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node)!;
		if (visited.ExpressionBody is not null)
		{
			visited = visited.WithExpressionBody(ThrowArrow);
		}
		if (visited.Initializer is not null)
		{
			visited = Stripped(visited.WithInitializer(null).WithSemicolonToken(default), visited);
		}
		return visited;
	}

	public override SyntaxNode? VisitIndexerDeclaration(IndexerDeclarationSyntax node)
	{
		IndexerDeclarationSyntax visited = (IndexerDeclarationSyntax)base.VisitIndexerDeclaration(node)!;
		return visited.ExpressionBody is null ? visited : visited.WithExpressionBody(ThrowArrow);
	}

	// A static initialiser is compiled into a type initialiser, which is a declaration the build carries:
	// dropping the initialiser must not drop the `.cctor` with it.
	public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
		=> KeepTypeInitializer(node, (TypeDeclarationSyntax)base.VisitClassDeclaration(node)!);

	public override SyntaxNode? VisitStructDeclaration(StructDeclarationSyntax node)
		=> KeepTypeInitializer(node, (TypeDeclarationSyntax)base.VisitStructDeclaration(node)!);

	static TypeDeclarationSyntax KeepTypeInitializer(TypeDeclarationSyntax original, TypeDeclarationSyntax visited)
	{
		bool hasStaticConstructor = original.Members.OfType<ConstructorDeclarationSyntax>()
			.Any(c => c.Modifiers.Any(SyntaxKind.StaticKeyword));
		bool initialisesStatics = original.Members.Any(member => member switch
		{
			FieldDeclarationSyntax field => field.Modifiers.Any(SyntaxKind.StaticKeyword)
				&& !field.Modifiers.Any(SyntaxKind.ConstKeyword)
				&& field.Declaration.Variables.Any(v => v.Initializer is not null),
			EventFieldDeclarationSyntax field => field.Modifiers.Any(SyntaxKind.StaticKeyword)
				&& field.Declaration.Variables.Any(v => v.Initializer is not null),
			PropertyDeclarationSyntax property => property.Modifiers.Any(SyntaxKind.StaticKeyword)
				&& property.Initializer is not null,
			_ => false,
		});
		if (hasStaticConstructor || !initialisesStatics)
		{
			return visited;
		}
		MemberDeclarationSyntax typeInitializer = SyntaxFactory.ParseMemberDeclaration(
			$"static {original.Identifier.Text}() {{ throw null; }}")!;
		return visited.AddMembers(typeInitializer);
	}

	public override SyntaxNode? VisitFieldDeclaration(FieldDeclarationSyntax node)
	{
		if (node.Modifiers.Any(SyntaxKind.ConstKeyword))
		{
			return node;
		}
		return node.WithDeclaration(node.Declaration.WithVariables(SyntaxFactory.SeparatedList(
			node.Declaration.Variables.Select(v => Stripped(v.WithInitializer(null), v)))));
	}

	public override SyntaxNode? VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
		=> node.WithDeclaration(node.Declaration.WithVariables(SyntaxFactory.SeparatedList(
			node.Declaration.Variables.Select(v => Stripped(v.WithInitializer(null), v)))));
}
