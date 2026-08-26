using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class BamlResourceProjectFile : ProjectFile
{
	private readonly byte[] bamlData;

	private readonly Func<byte[], Stream, IList<string>> decompileBaml;

	private readonly HashSet<IAssembly> asmRefs;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_DecompileBaml;

	public bool IsAppDef { get; set; }

	public override BuildAction BuildAction => IsAppDef ? BuildAction.ApplicationDefinition : BuildAction.Page;

	public override string Filename { get; }

	public string TypeFullName { get; }

	public bool IsSatelliteFile { get; set; }

	public IEnumerable<IAssembly> AssemblyReferences => asmRefs;

	public BamlResourceProjectFile(string filename, byte[] bamlData, string typeFullName, Func<byte[], Stream, IList<string>> decompileBaml)
	{
		Filename = filename;
		this.bamlData = bamlData;
		TypeFullName = typeFullName;
		base.SubType = "Designer";
		base.Generator = "MSBuild:Compile";
		this.decompileBaml = decompileBaml;
		asmRefs = new HashSet<IAssembly>(AssemblyNameComparer.CompareAll);
	}

	public override void Create(DecompileContext ctx)
	{
		IList<string> list;
		using (FileStream arg = File.Create(Filename))
		{
			list = decompileBaml(bamlData, arg);
		}
		foreach (string item in list)
		{
			AssemblyNameInfo assemblyNameInfo = new AssemblyNameInfo(item);
			if (!UTF8String.IsNullOrEmpty(assemblyNameInfo.Name))
			{
				asmRefs.Add(assemblyNameInfo);
			}
		}
	}
}
