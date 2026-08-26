using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class DecompileTypeMethods : DecompileTypeBase
{
	public TypeDef Type { get; }

	public HashSet<MethodDef> Methods { get; }

	public HashSet<TypeDef> Types { get; }

	public bool ShowAll { get; set; }

	public bool DecompileHidden { get; set; }

	public DecompileTypeMethods(IDecompilerOutput output, DecompilationContext ctx, TypeDef type)
		: base(output, ctx)
	{
		Type = type ?? throw new ArgumentNullException("type");
		Methods = new HashSet<MethodDef>();
		Types = new HashSet<TypeDef>();
		DecompileHidden = false;
	}
}
