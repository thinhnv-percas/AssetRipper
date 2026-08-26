using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ProjectModuleOptions
{
	public Func<ModuleDef, byte[], CancellationToken, Stream, IList<string>> DecompileBaml;

	public ModuleDef Module { get; }

	public IDecompiler Decompiler { get; }

	public DecompilationContext DecompilationContext { get; }

	public bool DontReferenceStdLib { get; set; }

	public ProjectVersion? ProjectVersion { get; set; }

	public Guid ProjectGuid { get; set; }

	public bool UnpackResources { get; set; }

	public bool CreateResX { get; set; }

	public bool DecompileXaml { get; set; }

	public ProjectModuleOptions(ModuleDef module, IDecompiler decompiler, DecompilationContext decompilationContext)
	{
		Module = module ?? throw new ArgumentNullException("module");
		Decompiler = decompiler ?? throw new ArgumentNullException("decompiler");
		DecompilationContext = decompilationContext ?? throw new ArgumentNullException("decompilationContext");
		ProjectGuid = Guid.NewGuid();
		UnpackResources = true;
		CreateResX = true;
		DecompileXaml = true;
	}
}
