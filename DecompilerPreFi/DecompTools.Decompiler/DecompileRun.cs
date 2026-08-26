using System;
using System.Collections.Generic;
using System.Threading;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Documentation;

namespace DecompTools.Decompiler;

internal class DecompileRun
{
	public HashSet<string> DefinedSymbols { get; private set; } = new HashSet<string>();

	public HashSet<string> Namespaces { get; private set; } = new HashSet<string>();

	public CancellationToken CancellationToken { get; set; }

	public DecompilerSettings Settings { get; }

	public IDocumentationProvider DocumentationProvider { get; set; }

	private Lazy<UsingScope> usingScope => new Lazy<UsingScope>(() => CreateUsingScope(Namespaces));

	public UsingScope UsingScope => usingScope.Value;

	public DecompileRun(DecompilerSettings settings)
	{
		Settings = settings ?? throw new ArgumentNullException("settings");
	}

	private UsingScope CreateUsingScope(HashSet<string> requiredNamespacesSuperset)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		UsingScope usingScope = new UsingScope();
		var enumerator = requiredNamespacesSuperset.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				string[] array = current.Split(new char[1] { '.' });
				AstType astType = new SimpleType(array[0]);
				for (int i = 1; i < array.Length; i = checked(i + 1))
				{
					astType = new MemberType
					{
						Target = astType,
						MemberName = array[i]
					};
				}
				if (astType.ToTypeReference(NameLookupMode.TypeInUsingDeclaration) is TypeOrNamespaceReference item)
				{
					usingScope.Usings.Add(item);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		return usingScope;
	}
}
