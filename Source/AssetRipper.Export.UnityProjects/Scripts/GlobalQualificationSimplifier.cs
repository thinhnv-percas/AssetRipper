using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Transforms;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.TypeSystem;
using System.Globalization;
using System.Text;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// What <see cref="GlobalQualificationSimplifier"/> needs to know about the names a compilation declares, so the rule
/// can be tested without one.
/// </summary>
public interface IGlobalNameScope
{
	/// <summary>Whether a namespace of this full name exists in any module.</summary>
	bool NamespaceExists(string fullName);

	/// <summary>Whether a type of this simple name, of any arity, is declared directly in the namespace ("" is the global one).</summary>
	bool TypeExists(string namespaceFullName, string name);

	/// <summary>
	/// Every name a simple-name lookup inside this type's body finds as a member of the type: its type parameters, its
	/// nested types and its members, its base types' included. Null when the type cannot be identified, which keeps the
	/// qualifier.
	/// </summary>
	IReadOnlyCollection<string>? MemberNames(TypeDeclaration declaration);
}

/// <summary>
/// Iteration 067 - drops <c>global::</c> where the shorter name means the same thing at that point in the file.
/// </summary>
/// <remarks>
/// <para>
/// This is name resolution, not text editing. ILSpy already writes <c>global::</c> only where its own lookup failed;
/// what remains is a mixture of genuine collisions (<c>global::Unity.IL2CPP…</c> inside <c>Spine.Unity</c>, where
/// <c>Unity</c> alone is <c>Spine.Unity</c>) and names ILSpy could not look up at all (compiler-generated types in the
/// global namespace). Removing the qualifier from the first changes what the code means; the second is noise.
/// </para>
/// <para>
/// <c>global::A.B</c> becomes <c>A.B</c> only when <c>A</c> exists in the global namespace and C#'s simple-name lookup
/// from that point reaches the global namespace before finding anything else called <c>A</c>: no namespace or type
/// <c>N.A</c> for an enclosing namespace <c>N</c>, no member, nested type or type parameter <c>A</c> of an enclosing
/// type or its bases, no local, parameter or type parameter <c>A</c> in the enclosing member, no alias <c>A</c>, and no
/// type <c>A</c> imported by a <c>using</c> inside a namespace declaration. Whatever cannot be established keeps the
/// qualifier.
/// </para>
/// </remarks>
public sealed class GlobalQualificationSimplifier : IAstTransform
{
	private readonly IGlobalNameScope? fixedScope;

	public GlobalQualificationSimplifier() { }

	public GlobalQualificationSimplifier(IGlobalNameScope scope) => fixedScope = scope;

	/// <summary>How many qualifiers the last run removed and kept, for the log and for tests.</summary>
	public int Simplified { get; private set; }

	public int Kept { get; private set; }

	public void Run(AstNode rootNode, TransformContext context)
	{
		Run(rootNode, fixedScope ?? new CompilationNameScope(context.TypeSystem));
	}

	public void Run(AstNode rootNode, IGlobalNameScope scope)
	{
		Simplified = 0;
		Kept = 0;

		// innermost first is not needed: only the `global::X` node itself is rewritten, never its ancestors
		foreach (MemberType qualified in rootNode.Descendants.OfType<MemberType>().Where(IsGlobalQualified).ToList())
		{
			if (CanDropQualifier(qualified, scope))
			{
				SimpleType shortened = new(qualified.MemberName, qualified.TypeArguments.Detach());
				shortened.CopyAnnotationsFrom(qualified);
				qualified.ReplaceWith(shortened);
				Simplified++;
			}
			else
			{
				Kept++;
			}
		}
	}

	private static bool IsGlobalQualified(MemberType node)
		=> node.IsDoubleColon && node.Target is SimpleType { Identifier: "global" } alias && alias.TypeArguments.Count == 0;

	public static bool CanDropQualifier(MemberType qualified, IGlobalNameScope scope)
	{
		if (!IsGlobalQualified(qualified))
		{
			return false;
		}

		string name = qualified.MemberName;
		string[] names = NamesOf(name);

		// what `global::name` refers to must exist, or nothing can be said about what `name` would refer to
		bool isGlobalType = qualified.GetResolveResult() is TypeResolveResult { Type: var resolved } && resolved.GetDefinition() is { DeclaringTypeDefinition: null, Namespace: "" };
		if (!isGlobalType && !names.Any(n => scope.NamespaceExists(n) || scope.TypeExists("", n)))
		{
			return false;
		}

		// enclosing namespaces, innermost first: N.name as a namespace or a type wins over the global one
		string enclosingNamespace = EnclosingNamespace(qualified);
		for (string current = enclosingNamespace; current.Length > 0; current = ParentNamespace(current))
		{
			if (names.Any(n => scope.NamespaceExists(current + "." + n) || scope.TypeExists(current, n)))
			{
				return false;
			}
		}

		SyntaxTree? tree = qualified.Ancestors.OfType<SyntaxTree>().FirstOrDefault();
		AstNode root = tree ?? qualified.Ancestors.LastOrDefault() ?? qualified;

		// aliases and extern aliases are looked up alongside the namespace's members
		if (root.Descendants.OfType<UsingAliasDeclaration>().Any(a => names.Contains(a.Alias))
			|| root.Descendants.OfType<ExternAliasDeclaration>().Any(a => names.Contains(a.Name)))
		{
			return false;
		}

		// a using inside a namespace declaration is consulted before the global namespace is reached
		foreach (UsingDeclaration import in root.Descendants.OfType<UsingDeclaration>().Where(u => u.Parent is NamespaceDeclaration))
		{
			if (names.Any(n => scope.TypeExists(import.Namespace, n)))
			{
				return false;
			}
		}

		// enclosing types: members, nested types, type parameters, inherited ones included
		foreach (TypeDeclaration declaration in qualified.Ancestors.OfType<TypeDeclaration>())
		{
			if (declaration.TypeParameters.Any(p => names.Contains(p.Name)))
			{
				return false;
			}

			if (declaration.Members.Any(m => names.Contains(m.Name)))
			{
				return false;
			}

			if (scope.MemberNames(declaration) is not { } memberNames || names.Any(memberNames.Contains))
			{
				return false;
			}
		}

		// the enclosing member: parameters, locals, lambda and query variables, its own type parameters
		if (qualified.Ancestors.OfType<EntityDeclaration>().FirstOrDefault(e => e is not TypeDeclaration) is { } member
			&& member.Descendants.OfType<Identifier>().Any(identifier => names.Contains(identifier.Name) && IsDeclaringIdentifier(identifier)))
		{
			return false;
		}

		return true;
	}

	/// <summary>An identifier that introduces a name rather than one that names a type in a type position.</summary>
	private static bool IsDeclaringIdentifier(Identifier identifier) => identifier.Parent is not (MemberType or SimpleType or PrimitiveType);

	private static string EnclosingNamespace(AstNode node)
	{
		List<string> parts = [];
		foreach (NamespaceDeclaration declaration in node.Ancestors.OfType<NamespaceDeclaration>())
		{
			parts.Insert(0, declaration.Name);
		}

		// a file-scoped namespace is a sibling of what it contains rather than an ancestor
		if (node.Ancestors.OfType<SyntaxTree>().FirstOrDefault() is { } tree
			&& tree.Children.OfType<NamespaceDeclaration>().FirstOrDefault(n => n.IsFileScoped) is { } fileScoped
			&& !node.Ancestors.Contains(fileScoped))
		{
			parts.Insert(0, fileScoped.Name);
		}

		return string.Join(".", parts.Where(p => p.Length > 0));
	}

	private static string ParentNamespace(string fullName)
	{
		int dot = fullName.LastIndexOf('.');
		return dot < 0 ? "" : fullName[..dot];
	}

	/// <summary>The name as written, and as metadata spells it when ILSpy escaped it (<c>_003C</c> is <c>&lt;</c>).</summary>
	private static string[] NamesOf(string written)
	{
		string metadata = Unescape(written);
		return metadata == written ? [written] : [written, metadata];
	}

	private static string Unescape(string written)
	{
		if (!written.Contains("_00", StringComparison.Ordinal))
		{
			return written;
		}

		StringBuilder builder = new(written.Length);
		for (int i = 0; i < written.Length; i++)
		{
			if (i + 4 < written.Length && written[i] == '_' && written[i + 1] == '0' && written[i + 2] == '0'
				&& int.TryParse(written.AsSpan(i + 3, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int code))
			{
				builder.Append((char)code);
				i += 4;
			}
			else
			{
				builder.Append(written[i]);
			}
		}
		return builder.ToString();
	}

	/// <summary>The production scope: the decompiler's own type system, every module included.</summary>
	private sealed class CompilationNameScope(ICompilation compilation) : IGlobalNameScope
	{
		public bool NamespaceExists(string fullName) => Find(fullName) is not null;

		public bool TypeExists(string namespaceFullName, string name)
			=> (namespaceFullName.Length == 0 ? compilation.RootNamespace : Find(namespaceFullName)) is { } ns
				&& ns.Types.Any(t => t.Name == name);

		public IReadOnlyCollection<string>? MemberNames(TypeDeclaration declaration)
		{
			if (declaration.GetSymbol() is not ITypeDefinition definition)
			{
				return null;
			}

			HashSet<string> names = new(StringComparer.Ordinal);
			foreach (ITypeDefinition type in definition.GetAllBaseTypeDefinitions().Append(definition))
			{
				foreach (ITypeParameter parameter in type.TypeParameters)
				{
					names.Add(parameter.Name);
				}

				foreach (ITypeDefinition nested in type.NestedTypes)
				{
					names.Add(nested.Name);
				}

				foreach (IMember member in type.Members)
				{
					names.Add(member.Name);
				}
			}
			return names;
		}

		private INamespace? Find(string fullName)
		{
			INamespace? current = compilation.RootNamespace;
			foreach (string part in fullName.Split('.'))
			{
				current = current?.GetChildNamespace(part);
				if (current is null)
				{
					return null;
				}
			}
			return current;
		}
	}
}
