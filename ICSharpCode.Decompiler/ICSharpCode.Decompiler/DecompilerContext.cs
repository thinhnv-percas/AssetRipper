using System.Collections.Generic;
using System.Threading;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.Decompiler.ILAst;

namespace ICSharpCode.Decompiler;

public class DecompilerContext
{
	public MetadataTextColorProvider MetadataTextColorProvider;

	public ModuleDef CurrentModule;

	public CancellationToken CancellationToken;

	public TypeDef CurrentType;

	public MethodDef CurrentMethod;

	public DecompilerSettings Settings = new DecompilerSettings();

	public readonly int SettingsVersion;

	public bool CurrentMethodIsAsync;

	public bool CurrentMethodIsYieldReturn;

	public readonly DecompilerCache Cache;

	public bool CalculateILSpans;

	public bool AsyncMethodBodyDecompilation;

	public readonly List<string> UsingNamespaces = new List<string>();

	internal FieldToVariableMap variableMap;

	internal List<string> ReservedVariableNames = new List<string>();

	internal FieldToVariableMap VariableMap
	{
		get
		{
			if (variableMap == null)
			{
				variableMap = new FieldToVariableMap();
			}
			return variableMap;
		}
	}

	public DecompilerContext(int settingsVersion, ModuleDef currentModule, MetadataTextColorProvider metadataTextColorProvider = null)
		: this(settingsVersion, currentModule, metadataTextColorProvider, calculateILSpans: false)
	{
	}

	public DecompilerContext(int settingsVersion, ModuleDef currentModule, MetadataTextColorProvider metadataTextColorProvider, bool calculateILSpans)
	{
		SettingsVersion = settingsVersion;
		CurrentModule = currentModule;
		CalculateILSpans = calculateILSpans;
		Cache = new DecompilerCache(this);
		MetadataTextColorProvider = metadataTextColorProvider ?? CSharpMetadataTextColorProvider.Instance;
	}

	private DecompilerContext(DecompilerContext other)
	{
		MetadataTextColorProvider = other.MetadataTextColorProvider;
		CurrentModule = other.CurrentModule;
		CancellationToken = other.CancellationToken;
		CurrentType = other.CurrentType;
		CurrentMethod = other.CurrentMethod;
		Settings = other.Settings.Clone();
		SettingsVersion = other.SettingsVersion;
		CurrentMethodIsAsync = other.CurrentMethodIsAsync;
		CurrentMethodIsYieldReturn = other.CurrentMethodIsYieldReturn;
		Cache = new DecompilerCache(this);
		CalculateILSpans = other.CalculateILSpans;
		AsyncMethodBodyDecompilation = other.AsyncMethodBodyDecompilation;
		UsingNamespaces.AddRange(other.UsingNamespaces);
		ReservedVariableNames.AddRange(other.ReservedVariableNames);
		variableMap = null;
	}

	internal DecompilerContext CloneDontUse()
	{
		DecompilerContext decompilerContext = (DecompilerContext)MemberwiseClone();
		decompilerContext.ReservedVariableNames = new List<string>(decompilerContext.ReservedVariableNames);
		return decompilerContext;
	}

	internal DecompilerContext Clone()
	{
		return new DecompilerContext(this);
	}

	public void Reset()
	{
		CurrentModule = null;
		CancellationToken = CancellationToken.None;
		CurrentType = null;
		CurrentMethod = null;
		Settings = new DecompilerSettings();
		CurrentMethodIsAsync = false;
		CurrentMethodIsYieldReturn = false;
		UsingNamespaces.Clear();
		Cache.Reset();
		variableMap = null;
	}
}
