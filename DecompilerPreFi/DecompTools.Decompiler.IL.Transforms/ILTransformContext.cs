using System;
using System.Diagnostics;
using System.Threading;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL.Transforms;

public class ILTransformContext
{
	public ILFunction Function { get; }

	public IDecompilerTypeSystem TypeSystem { get; }

	public IDebugInfoProvider DebugInfo { get; }

	public DecompilerSettings Settings { get; }

	public CancellationToken CancellationToken { get; set; }

	public Stepper Stepper { get; set; }

	public PEFile PEFile => TypeSystem.MainModule.PEFile;

	internal DecompileRun DecompileRun { get; set; }

	internal ResolvedUsingScope UsingScope => DecompileRun.UsingScope.Resolve(TypeSystem);

	public ILTransformContext(ILFunction function, IDecompilerTypeSystem typeSystem, IDebugInfoProvider debugInfo, DecompilerSettings settings = null)
	{
		Function = function ?? throw new ArgumentNullException("function");
		TypeSystem = typeSystem ?? throw new ArgumentNullException("typeSystem");
		Settings = settings ?? new DecompilerSettings();
		DebugInfo = debugInfo;
		Stepper = new Stepper();
	}

	public ILTransformContext(ILTransformContext context, ILFunction function = null)
	{
		Function = function ?? context.Function;
		TypeSystem = context.TypeSystem;
		DebugInfo = context.DebugInfo;
		Settings = context.Settings;
		DecompileRun = context.DecompileRun;
		CancellationToken = context.CancellationToken;
		Stepper = context.Stepper;
	}

	internal ILReader CreateILReader()
	{
		return new ILReader(TypeSystem.MainModule)
		{
			UseDebugSymbols = Settings.UseDebugSymbols,
			DebugInfo = DebugInfo
		};
	}

	[Conditional("STEP")]
	internal void Step(string description, ILInstruction near)
	{
		Stepper.Step(description, near);
	}

	[Conditional("STEP")]
	internal void StepStartGroup(string description, ILInstruction near = null)
	{
		Stepper.StartGroup(description, near);
	}

	[Conditional("STEP")]
	internal void StepEndGroup(bool keepIfEmpty = false)
	{
		Stepper.EndGroup(keepIfEmpty);
	}
}
