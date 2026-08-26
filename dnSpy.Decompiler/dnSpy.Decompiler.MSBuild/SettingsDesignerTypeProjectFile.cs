using System;
using System.IO;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class SettingsDesignerTypeProjectFile : ProjectFile
{
	private readonly string filename;

	private readonly SettingsTypeProjectFile typeFile;

	private readonly Func<TextWriter, IDecompilerOutput> createDecompilerOutput;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateSettingsDesignerTypeFile;

	public override BuildAction BuildAction => BuildAction.Compile;

	public override string Filename => filename;

	public SettingsDesignerTypeProjectFile(SettingsTypeProjectFile typeFile, string filename, Func<TextWriter, IDecompilerOutput> createDecompilerOutput)
	{
		this.typeFile = typeFile;
		this.filename = filename;
		this.createDecompilerOutput = createDecompilerOutput;
	}

	public override void Create(DecompileContext ctx)
	{
		using StreamWriter arg = new StreamWriter(Filename, append: false, Encoding.UTF8);
		if (typeFile.Decompiler.CanDecompile(DecompilationType.PartialType))
		{
			IDecompilerOutput output = createDecompilerOutput(arg);
			DecompilePartialType decompilePartialType = new DecompilePartialType(output, typeFile.DecompilationContext, typeFile.Type);
			IMemberDef[] defsToRemove = typeFile.GetDefsToRemove();
			foreach (IMemberDef item in defsToRemove)
			{
				decompilePartialType.Definitions.Add(item);
			}
			decompilePartialType.ShowDefinitions = true;
			typeFile.Decompiler.Decompile(DecompilationType.PartialType, decompilePartialType);
		}
	}
}
