using System;
using System.IO;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class WinFormsDesignerProjectFile : ProjectFile
{
	private readonly string filename;

	private readonly WinFormsProjectFile winFormsFile;

	private readonly Func<TextWriter, IDecompilerOutput> createDecompilerOutput;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateWinFormsDesignerFile;

	public override BuildAction BuildAction => BuildAction.Compile;

	public override string Filename => filename;

	public WinFormsDesignerProjectFile(WinFormsProjectFile winFormsFile, string filename, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
	{
		this.winFormsFile = winFormsFile;
		this.filename = filename;
		this.createDecompilerOutput = createDecompilerOutput;
	}

	public override void Create(DecompileContext ctx)
	{
		using StreamWriter arg = new StreamWriter(Filename, append: false, Encoding.UTF8);
		if (winFormsFile.Decompiler.CanDecompile(DecompilationType.PartialType))
		{
			IDecompilerOutput output = createDecompilerOutput(arg);
			DecompilePartialType decompilePartialType = new DecompilePartialType(output, winFormsFile.DecompilationContext, winFormsFile.Type);
			IMemberDef[] defsToRemove = winFormsFile.GetDefsToRemove();
			foreach (IMemberDef item in defsToRemove)
			{
				decompilePartialType.Definitions.Add(item);
			}
			decompilePartialType.ShowDefinitions = true;
			decompilePartialType.UseUsingDeclarations = false;
			winFormsFile.Decompiler.Decompile(DecompilationType.PartialType, decompilePartialType);
		}
	}
}
