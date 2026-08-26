using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class TransformContext
{
	public readonly IDecompilerTypeSystem TypeSystem;

	public readonly CancellationToken CancellationToken;

	public readonly TypeSystemAstBuilder TypeSystemAstBuilder;

	public readonly DecompilerSettings Settings;

	internal readonly DecompileRun DecompileRun;

	private readonly ITypeResolveContext decompilationContext;

	public IMember CurrentMember => decompilationContext.CurrentMember;

	public ITypeDefinition CurrentTypeDefinition => decompilationContext.CurrentTypeDefinition;

	public IModule CurrentModule => decompilationContext.CurrentModule;

	public IImmutableSet<string> RequiredNamespacesSuperset => ((IEnumerable<string>)DecompileRun.Namespaces).ToImmutableHashSet();

	internal TransformContext(IDecompilerTypeSystem typeSystem, DecompileRun decompileRun, ITypeResolveContext decompilationContext, TypeSystemAstBuilder typeSystemAstBuilder)
	{
		TypeSystem = typeSystem;
		DecompileRun = decompileRun;
		this.decompilationContext = decompilationContext;
		TypeSystemAstBuilder = typeSystemAstBuilder;
		CancellationToken = decompileRun.CancellationToken;
		Settings = decompileRun.Settings;
	}
}
