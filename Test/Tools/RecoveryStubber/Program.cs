using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// RecoveryStubber <errors.txt> <manifest.json> [--helper <dir>]
//
// <errors.txt> holds one compiler diagnostic per line, "path(line,col): error CSxxxx: message". Every member whose body
// carries an error has that body replaced with a stub that reports itself once (RecoveryStub.Missing) and returns the
// default; the member's declaration is untouched, so callers and serialized data still bind to it. An error outside
// any body (a signature, a field initialiser, a type declaration) cannot be stubbed and is listed as such.
//
// <manifest.json> is appended to: one entry per stubbed member with the errors that caused it, the worklist for
// repairing the bodies by hand. Run it again after recompiling until the compiler reports nothing.
//
// A stub keeps the member's kind intact: an iterator stays an iterator (yield break), an async method loses `async`
// and returns a completed task, an out parameter is assigned, a struct constructor assigns `this`.
//
// Before anything is stubbed, an error with a mechanical repair is repaired instead (see Repair): an ambiguous
// `Debug` gets a using alias, a leftover `base._002Ector()` is dropped, a framework-internal empty enumerable is
// `Enumerable.Empty<T>()`. A member is stubbed only if one of its errors has no such repair.
//
// --helper <dir> writes the RecoveryStub helper there; --helper auto writes one into every assembly a stub landed
// in (Assets/Scripts/<assembly>/AssetRipperInjected), because the helper is internal to the assembly that calls it.

var errorLine = new Regex(@"^(?<path>.+?)\((?<line>\d+),(?<col>\d+)\): error (?<code>CS\d+): (?<message>.*)$");
string errorsPath = args[0], manifestPath = args[1];
string? helperDir = args.SkipWhile(a => a != "--helper").Skip(1).FirstOrDefault();

var byFile = new Dictionary<string, List<(int line, int col, string code, string message)>>();
foreach (var text in File.ReadLines(errorsPath))
{
    var m = errorLine.Match(text);
    if (!m.Success) continue;
    var path = m.Groups["path"].Value;
    if (!byFile.TryGetValue(path, out var list)) byFile[path] = list = new();
    list.Add((int.Parse(m.Groups["line"].Value), int.Parse(m.Groups["col"].Value), m.Groups["code"].Value, m.Groups["message"].Value));
}

var manifest = File.Exists(manifestPath)
    ? JsonSerializer.Deserialize<List<StubRecord>>(File.ReadAllText(manifestPath)) ?? new()
    : new List<StubRecord>();
var unhandled = new List<string>();
int stubbedNow = 0, repairedNow = 0;
var helperDirs = new SortedSet<string>(StringComparer.Ordinal);

foreach (var (path, errors) in byFile.OrderBy(p => p.Key))
{
    if (!File.Exists(path)) { unhandled.Add($"{path}: file not found"); continue; }
    // Only the exported scripts are ours to rewrite; a package's source is the package's.
    if (AssemblyRoot(path) is null) { unhandled.Add($"{path}: not an exported script (outside Assets/Scripts), left alone"); continue; }
    var source = File.ReadAllText(path);
    var tree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.CSharp9), path);
    var root = tree.GetRoot();
    var text = tree.GetText();

    var targets = new Dictionary<SyntaxNode, List<string>>();
    var repairs = new Dictionary<SyntaxNode, (SyntaxNode? member, Func<SyntaxNode, SyntaxNode?> rewrite)>();
    var aliases = new SortedSet<string>(StringComparer.Ordinal);
    foreach (var (line, col, code, message) in errors)
    {
        if (line - 1 >= text.Lines.Count) { unhandled.Add($"{path}({line},{col}) {code}: past the end of the file"); continue; }
        var position = Math.Min(text.Lines[line - 1].Start + Math.Max(col - 1, 0), text.Length - 1);
        var token = root.FindToken(position);
        var member = Stubbable(token.Parent);
        if (Repair(code, message, token, aliases) is { } repair)
        {
            repairs[repair.node] = (member, repair.rewrite);
            continue;
        }
        if (member is null)
        {
            unhandled.Add($"{path}({line},{col}) {code}: {message}");
            continue;
        }
        if (!targets.TryGetValue(member, out var why)) targets[member] = why = new();
        why.Add($"{code}: {message}");
    }
    // A repair inside a member that is stubbed anyway is moot, and would rewrite a node the stub replaces.
    var kept = repairs.Where(r => r.Value.member is null || !targets.ContainsKey(r.Value.member)).ToDictionary(r => r.Key, r => r.Value.rewrite);
    if (targets.Count == 0 && kept.Count == 0 && aliases.Count == 0) continue;

    var rewritten = root.ReplaceNodes(targets.Keys.Concat(kept.Keys), (original, current) =>
        targets.ContainsKey(original) ? Indent(Stub(original, Describe(original, path)), original) : kept[original](current)!);
    if (aliases.Count > 0 && rewritten is CompilationUnitSyntax unit)
    {
        var existing = unit.Usings.Where(u => u.Alias is not null).Select(u => u.Alias!.Name.Identifier.Text).ToHashSet();
        var add = aliases.Select(a => a.Split('=', 2)).Where(a => !existing.Contains(a[0])).Select(a =>
            SyntaxFactory.UsingDirective(SyntaxFactory.NameEquals(a[0]), SyntaxFactory.ParseName(a[1])).NormalizeWhitespace().WithTrailingTrivia(SyntaxFactory.EndOfLine("\n")));
        rewritten = unit.WithUsings(unit.Usings.AddRange(add));
    }
    // A removed statement leaves nothing behind; RemoveNode needs a second pass because ReplaceNodes cannot drop one.
    rewritten = rewritten.RemoveNodes(rewritten.DescendantNodes().OfType<ExpressionStatementSyntax>().Where(IsRemovalMarker), SyntaxRemoveOptions.KeepNoTrivia)!;
    File.WriteAllText(path, rewritten.ToFullString());
    repairedNow += kept.Count + aliases.Count;
    foreach (var (member, why) in targets)
    {
        manifest.Add(new StubRecord(path, Describe(member, path), why.Distinct().ToList()));
        stubbedNow++;
        if (helperDir == "auto" && AssemblyRoot(path) is { } assemblyRoot) helperDirs.Add(Path.Combine(assemblyRoot, "AssetRipperInjected"));
    }
}

File.WriteAllText(manifestPath, JsonSerializer.Serialize(manifest, new JsonSerializerOptions { WriteIndented = true }));
if (helperDir is not null && helperDir != "auto") helperDirs.Add(helperDir);
foreach (var dir in helperDirs)
{
    Directory.CreateDirectory(dir);
    File.WriteAllText(Path.Combine(dir, "RecoveryStub.cs"), HelperSource);
}
Console.WriteLine($"repaired {repairedNow} errors mechanically; stubbed {stubbedNow} members in this pass ({manifest.Count} in total); {unhandled.Count} errors outside any body");
foreach (var u in unhandled.Take(200)) Console.WriteLine("  UNHANDLED " + u);
return unhandled.Count > 0 ? 2 : 0;

// The member whose body a position lies in, or null when the position is not inside a body.
static SyntaxNode? Stubbable(SyntaxNode? node)
{
    for (; node is not null; node = node.Parent)
    {
        switch (node)
        {
            // An error in an attribute, a parameter list or a type is in the declaration, which a stub keeps.
            case AttributeListSyntax:
            case ParameterListSyntax:
            case TypeParameterConstraintClauseSyntax:
                return null;
            case AccessorDeclarationSyntax accessor when accessor.Body is not null || accessor.ExpressionBody is not null:
                return accessor;
            case BaseMethodDeclarationSyntax method when method.Body is not null || method.ExpressionBody is not null:
                return method;
            case PropertyDeclarationSyntax { ExpressionBody: not null } property:
                return property;
            case IndexerDeclarationSyntax { ExpressionBody: not null } indexer:
                return indexer;
            case BaseTypeDeclarationSyntax:
            case FieldDeclarationSyntax:
                return null;
        }
    }
    return null;
}

static string Describe(SyntaxNode member, string path)
{
    var type = member.Ancestors().OfType<BaseTypeDeclarationSyntax>().Select(t => t.Identifier.Text).Reverse();
    string name = member switch
    {
        MethodDeclarationSyntax m => m.Identifier.Text,
        ConstructorDeclarationSyntax c => c.Modifiers.Any(SyntaxKind.StaticKeyword) ? ".cctor" : ".ctor",
        DestructorDeclarationSyntax => "Finalize",
        OperatorDeclarationSyntax o => "operator " + o.OperatorToken.Text,
        ConversionOperatorDeclarationSyntax c => "operator " + c.Type,
        AccessorDeclarationSyntax a => a.Keyword.Text + "_" + (a.Parent?.Parent switch
        {
            PropertyDeclarationSyntax p => p.Identifier.Text,
            EventDeclarationSyntax e => e.Identifier.Text,
            IndexerDeclarationSyntax => "Item",
            _ => "?",
        }),
        PropertyDeclarationSyntax p => "get_" + p.Identifier.Text,
        IndexerDeclarationSyntax => "get_Item",
        _ => member.Kind().ToString(),
    };
    return string.Join(".", type) + "::" + name;
}

static SyntaxNode Stub(SyntaxNode member, string id)
{
    var report = $"global::AssetRipperInjected.RecoveryStub.Missing(\"{id}\");";
    switch (member)
    {
        case AccessorDeclarationSyntax accessor:
        {
            TypeSyntax? valueType = accessor.Kind() is SyntaxKind.GetAccessorDeclaration
                ? accessor.Parent?.Parent switch { BasePropertyDeclarationSyntax p => p.Type, _ => null }
                : null;
            var body = Block(report, valueType is null ? null : ReturnFor(valueType, accessor.Parent?.Parent is PropertyDeclarationSyntax { Type: RefTypeSyntax }));
            return accessor.WithExpressionBody(null).WithSemicolonToken(default).WithBody(body);
        }
        case PropertyDeclarationSyntax property:
        {
            var getter = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, Block(report, ReturnFor(property.Type, property.Type is RefTypeSyntax)));
            return property.WithExpressionBody(null).WithSemicolonToken(default)
                .WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.SingletonList(getter)));
        }
        case IndexerDeclarationSyntax indexer:
        {
            var getter = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration, Block(report, ReturnFor(indexer.Type, indexer.Type is RefTypeSyntax)));
            return indexer.WithExpressionBody(null).WithSemicolonToken(default)
                .WithAccessorList(SyntaxFactory.AccessorList(SyntaxFactory.SingletonList(getter)));
        }
        case ConstructorDeclarationSyntax ctor:
        {
            var statements = new List<string> { report };
            bool inStruct = ctor.Parent is StructDeclarationSyntax || ctor.Parent is RecordDeclarationSyntax r && r.ClassOrStructKeyword.IsKind(SyntaxKind.StructKeyword);
            if (inStruct && !ctor.Modifiers.Any(SyntaxKind.StaticKeyword)) statements.Add("this = default;");
            statements.AddRange(OutAssignments(ctor.ParameterList));
            return ctor.WithExpressionBody(null).WithSemicolonToken(default).WithBody(Block(statements));
        }
        case MethodDeclarationSyntax method:
        {
            var statements = new List<string> { report };
            statements.AddRange(OutAssignments(method.ParameterList));
            bool isAsync = method.Modifiers.Any(SyntaxKind.AsyncKeyword);
            bool isIterator = method.Body?.DescendantNodes().OfType<YieldStatementSyntax>().Any(y => y.Ancestors().FirstOrDefault(a => a is LocalFunctionStatementSyntax or AnonymousFunctionExpressionSyntax or MethodDeclarationSyntax) == method) == true;
            var returnType = method.ReturnType.ToString();
            if (isIterator)
                statements.Add("yield break;");
            else if (isAsync)
            {
                method = method.WithModifiers(SyntaxFactory.TokenList(method.Modifiers.Where(m => !m.IsKind(SyntaxKind.AsyncKeyword))));
                if (returnType is "Task" or "System.Threading.Tasks.Task")
                    statements.Add("return global::System.Threading.Tasks.Task.CompletedTask;");
                else if (Regex.Match(returnType, @"^(System\.Threading\.Tasks\.)?Task<(?<t>.+)>$") is { Success: true } task)
                    statements.Add($"return global::System.Threading.Tasks.Task.FromResult<{task.Groups["t"].Value}>(default);");
                else if (returnType != "void")
                    statements.Add("return default;");
            }
            else if (ReturnFor(method.ReturnType, method.ReturnType is RefTypeSyntax) is { } ret)
                statements.Add(ret);
            return method.WithExpressionBody(null).WithSemicolonToken(default).WithBody(Block(statements));
        }
        case BaseMethodDeclarationSyntax other:
        {
            var statements = new List<string> { report };
            statements.AddRange(OutAssignments(other.ParameterList));
            if (other is OperatorDeclarationSyntax op) statements.Add(ReturnFor(op.ReturnType, false)!);
            if (other is ConversionOperatorDeclarationSyntax conv) statements.Add(ReturnFor(conv.Type, false)!);
            return other.WithExpressionBody(null).WithSemicolonToken(default).WithBody(Block(statements));
        }
    }
    return member;
}

static string? ReturnFor(TypeSyntax type, bool byRef)
{
    if (type is PredefinedTypeSyntax p && p.Keyword.IsKind(SyntaxKind.VoidKeyword)) return null;
    return byRef ? "throw new global::System.NotImplementedException();" : "return default;";
}

static IEnumerable<string> OutAssignments(ParameterListSyntax parameters)
    => parameters.Parameters.Where(p => p.Modifiers.Any(SyntaxKind.OutKeyword)).Select(p => $"{p.Identifier.Text} = default;");

static BlockSyntax Block(params object?[] statements)
{
    var lines = statements.SelectMany(s => s switch { null => [], string one => [one], IEnumerable<string> many => many, _ => [] });
    return SyntaxFactory.Block(lines.Select(l => SyntaxFactory.ParseStatement(l)));
}

// Gives a stubbed member's new body the layout of the code around it: braces on their own lines at the member's
// indentation, statements one tab deeper, as the decompiler writes every other body in the file.
static SyntaxNode Indent(SyntaxNode stubbed, SyntaxNode original)
{
    var line = original.SyntaxTree.GetText().Lines.GetLineFromPosition(original.SpanStart).ToString();
    var indent = line[..(line.Length - line.TrimStart().Length)];
    return stubbed.ReplaceNodes(stubbed.DescendantNodes().OfType<BlockSyntax>().Where(b => b.Parent == stubbed || b.Parent?.Parent?.Parent == stubbed),
        (_, block) => block
            .WithOpenBraceToken(SyntaxFactory.Token(SyntaxKind.OpenBraceToken).WithLeadingTrivia(OpenBraceLead(block, stubbed, indent)).WithTrailingTrivia(SyntaxFactory.EndOfLine("\n")))
            .WithStatements(SyntaxFactory.List(block.Statements.Select(st => st.NormalizeWhitespace("\t", "\n").WithLeadingTrivia(SyntaxFactory.Whitespace(BlockIndent(block, stubbed, indent) + "\t")).WithTrailingTrivia(SyntaxFactory.EndOfLine("\n")))))
            .WithCloseBraceToken(SyntaxFactory.Token(SyntaxKind.CloseBraceToken).WithLeadingTrivia(SyntaxFactory.Whitespace(BlockIndent(block, stubbed, indent)))
                .WithTrailingTrivia(block.Parent == stubbed && original.GetTrailingTrivia().Any() ? original.GetTrailingTrivia() : SyntaxFactory.TriviaList(SyntaxFactory.EndOfLine("\n")))));
}

static string BlockIndent(BlockSyntax block, SyntaxNode member, string indent) => block.Parent == member ? indent : indent + "\t\t";

// The open brace starts its own line; the newline is added only when the token before it does not already end one.
static SyntaxTriviaList OpenBraceLead(BlockSyntax block, SyntaxNode stubbed, string indent)
{
    var previous = block.GetFirstToken().GetPreviousToken();
    bool lineEnded = previous.TrailingTrivia.Any(t => t.IsKind(SyntaxKind.EndOfLineTrivia));
    return lineEnded
        ? SyntaxFactory.TriviaList(SyntaxFactory.Whitespace(BlockIndent(block, stubbed, indent)))
        : SyntaxFactory.TriviaList(SyntaxFactory.EndOfLine("\n"), SyntaxFactory.Whitespace(BlockIndent(block, stubbed, indent)));
}

// The folder an exported script's assembly lives in: Assets/Scripts/<assembly>.
static string? AssemblyRoot(string path)
{
    var marker = Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "Scripts" + Path.DirectorySeparatorChar;
    int at = path.IndexOf(marker, StringComparison.Ordinal);
    if (at < 0) return null;
    int start = at + marker.Length;
    int end = path.IndexOf(Path.DirectorySeparatorChar, start);
    return end < 0 ? null : path[..end];
}

// A statement Repair asked to have removed: it is replaced by this marker first, then dropped.
static bool IsRemovalMarker(ExpressionStatementSyntax statement)
    => statement.Expression is InvocationExpressionSyntax { Expression: IdentifierNameSyntax { Identifier.Text: RemovalMarker } };

// The mechanical repair for an error, if it has one: the node to rewrite and how. Only shapes whose repair is
// exact belong here - a repair that guessed would hide a defect the stub at least reports.
static (SyntaxNode node, Func<SyntaxNode, SyntaxNode?> rewrite)? Repair(string code, string message, SyntaxToken token, ISet<string> aliases)
{
    switch (code)
    {
        // `Debug` with both System.Diagnostics and UnityEngine imported. A decompiler writes the simple name when
        // the file's usings make it unique, and the game's own code meant Unity's: System.Diagnostics.Debug is
        // compiled out of a player build entirely.
        case "CS0104" when Regex.Match(message, @"^'(?<name>\w+)' is an ambiguous reference between '(?<a>[\w.]+)' and '(?<b>[\w.]+)'$") is { Success: true } m:
        {
            string name = m.Groups["name"].Value, a = m.Groups["a"].Value, b = m.Groups["b"].Value;
            string? chosen = (a, b) switch
            {
                _ when name == "Debug" && (a == "UnityEngine.Debug" || b == "UnityEngine.Debug") => "UnityEngine.Debug",
                _ when name == "Object" && (a == "UnityEngine.Object" || b == "UnityEngine.Object") => "UnityEngine.Object",
                _ => null,
            };
            if (chosen is null) return null;
            aliases.Add(name + "=" + chosen);
            // The error is repaired by the alias; the node is the token's own, rewritten to itself.
            return (token.Parent!, static node => node);
        }
        // `base._002Ector()` / `x._002Ector()`: a constructor call C# cannot write. The object was already
        // constructed (by `new`, or by the constructor this sits in), so the statement is the leftover.
        case "CS0117" or "CS1061" when message.Contains("'_002Ector'") && token.Parent?.AncestorsAndSelf().OfType<ExpressionStatementSyntax>().FirstOrDefault() is { } statement:
            return (statement, static _ => SyntaxFactory.ExpressionStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName(RemovalMarker))));
        // A constructor whose base has no parameterless one: il2cpp inlined the base call into the body, so the
        // decompiled constructor has no initializer. CS7036 names the base constructor's parameter types and each
        // is passed the first unused parameter of that type; CS1729 names nothing, and the parameters are passed
        // through as they are, which is the shape of every wrapper and exception constructor.
        case "CS7036" or "CS1729" when token.Parent?.AncestorsAndSelf().OfType<ConstructorDeclarationSyntax>().FirstOrDefault() is { Initializer: null } ctor
            && !ctor.Modifiers.Any(SyntaxKind.StaticKeyword) && ctor.Identifier.Span.Contains(token.Span):
        {
            var parameters = ctor.ParameterList.Parameters.ToList();
            List<string>? arguments = null;
            if (code == "CS1729")
                arguments = parameters.Select(p => p.Identifier.Text).ToList();
            else if (Regex.Match(message, @"of '[^']*\((?<types>[^)]*)\)'$") is { Success: true } signature)
            {
                var used = new HashSet<ParameterSyntax>();
                arguments = new();
                foreach (var type in signature.Groups["types"].Value.Split(", ", StringSplitOptions.RemoveEmptyEntries))
                {
                    var match = parameters.FirstOrDefault(p => !used.Contains(p) && p.Type is { } t && (t.ToString() == type || type.EndsWith("." + t.ToString(), StringComparison.Ordinal)));
                    if (match is null) { arguments = null; break; }
                    used.Add(match);
                    arguments.Add(match.Identifier.Text);
                }
            }
            if (arguments is null) return null;
            return (ctor, node => ((ConstructorDeclarationSyntax)node).WithInitializer(
                SyntaxFactory.ConstructorInitializer(SyntaxKind.BaseConstructorInitializer,
                    SyntaxFactory.ParseArgumentList("(" + string.Join(", ", arguments) + ")"))
                    .WithColonToken(SyntaxFactory.Token(SyntaxKind.ColonToken).WithTrailingTrivia(SyntaxFactory.Space))
                    .WithLeadingTrivia(SyntaxFactory.Whitespace((ctor.Body?.OpenBraceToken.LeadingTrivia.ToFullString() ?? "") + "\t"))
                    .WithTrailingTrivia(SyntaxFactory.EndOfLine("\n"))));
        }
        // `System.Linq.EmptyEnumerable<T>.Instance`, internal to the framework, is what Enumerable.Empty<T>() returns.
        case "CS0234" when message.StartsWith("The type or namespace name 'EmptyEnumerable' does not exist in the namespace 'System.Linq'")
            && token.Parent?.AncestorsAndSelf().OfType<MemberAccessExpressionSyntax>().FirstOrDefault(x => x.Name.Identifier.Text == "Instance") is { Expression: MemberAccessExpressionSyntax { Name: GenericNameSyntax generic } } instance:
            return (instance, node => SyntaxFactory.ParseExpression($"global::System.Linq.Enumerable.Empty<{generic.TypeArgumentList.Arguments}>()").WithTriviaFrom(node));
    }
    return null;
}

sealed partial class Program
{
    const string RemovalMarker = "__RecoveryStubberRemove";

    const string HelperSource = """
        // Written by Test/Tools/RecoveryStubber. A member whose recovered body did not compile was given a stub that calls
        // Missing() and returns the default; the list of them, with the errors that caused each, is the repair worklist.
        namespace AssetRipperInjected
        {
            internal static class RecoveryStub
            {
                private static readonly global::System.Collections.Generic.HashSet<string> reported = new global::System.Collections.Generic.HashSet<string>();

                public static void Missing(string member)
                {
                    lock (reported)
                    {
                        if (!reported.Add(member)) return;
                    }
                    global::UnityEngine.Debug.LogWarning("[Recovery] body not recovered yet: " + member);
                }
            }
        }

        """;
}

sealed record StubRecord(string File, string Member, List<string> Errors);
