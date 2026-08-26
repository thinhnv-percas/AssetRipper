using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class DecompilePartialType : DecompileTypeBase
{
	public TypeDef Type { get; }

	public bool AddPartialKeyword { get; set; }

	public HashSet<IMemberDef> Definitions { get; }

	public bool ShowDefinitions { get; set; }

	public bool UseUsingDeclarations { get; set; }

	public List<ITypeDefOrRef> InterfacesToRemove { get; }

	public DecompilePartialType(IDecompilerOutput output, DecompilationContext ctx, TypeDef type)
		: base(output, ctx)
	{
		Type = type ?? throw new ArgumentNullException("type");
		AddPartialKeyword = true;
		UseUsingDeclarations = true;
		Definitions = new HashSet<IMemberDef>();
		InterfacesToRemove = new List<ITypeDefOrRef>();
	}
}
