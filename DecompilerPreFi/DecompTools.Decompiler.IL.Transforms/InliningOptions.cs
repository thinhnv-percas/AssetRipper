using System;

namespace DecompTools.Decompiler.IL.Transforms;

[Flags]
public enum InliningOptions
{
	None = 0,
	Aggressive = 1,
	IntroduceNamedArguments = 2
}
