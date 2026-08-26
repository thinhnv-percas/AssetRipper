using System.Collections.Generic;
using System.Text;
using dnlib.DotNet;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;

namespace dnSpy.Decompiler.ILSpy.Core.CSharp;

internal sealed class AstBuilderState
{
	public readonly AstBuilder AstBuilder;

	public readonly StringBuilder XmlDoc_StringBuilder;

	private readonly Dictionary<ModuleDef, bool> hasXmlDocFile;

	private ModuleDef lastModule;

	private bool lastModuleResult;

	public AstBuilderState(int settingsVersion)
	{
		AstBuilder = new AstBuilder(new DecompilerContext(settingsVersion, null, null, calculateILSpans: true));
		XmlDoc_StringBuilder = new StringBuilder();
		hasXmlDocFile = new Dictionary<ModuleDef, bool>();
	}

	public bool? HasXmlDocFile(ModuleDef module)
	{
		if (lastModule == module)
		{
			return lastModuleResult;
		}
		if (hasXmlDocFile.TryGetValue(module, out var value))
		{
			lastModule = module;
			lastModuleResult = value;
			return value;
		}
		return null;
	}

	public void SetHasXmlDocFile(ModuleDef module, bool value)
	{
		lastModule = module;
		lastModuleResult = value;
		hasXmlDocFile.Add(module, value);
	}

	public void Reset()
	{
		AstBuilder.Reset();
	}
}
